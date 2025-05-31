using Data.Building;
using Core.Wallets;
using Zenject;
using System.Collections.Generic;

namespace Core.Building
{
    public class HandlerInfoBuilding : IBuildingStateManager
    {
        private readonly IBuildingData _buildingData;
        private readonly IWalletService _walletService;
        private readonly IResourceChecker _resourceChecker;

        [Inject]
        public HandlerInfoBuilding(IBuildingData buildingData, IWalletService walletService, IResourceChecker resourceChecker)
        {
            _buildingData = buildingData;
            _walletService = walletService;
            _resourceChecker = resourceChecker;
        }

        public BuildingState GetCurrentState(string name)
        {
            BuildingInfo info = _buildingData.GetByName(name);
            return info != null ? info.State : BuildingState.Notbuilt;
        }

        public void ChangeState(string name)
        {
            BuildingInfo info = _buildingData.GetByName(name);
            if (info == null) return;

            BuildingState currentState = info.State;
            if (!_resourceChecker.HasEnoughResources(name, currentState))
            {
                UnityEngine.Debug.Log("Not enough resources to change state for " + name);
                return;
            }

            BuildingState newState = currentState;
            switch (currentState)
            {
                case BuildingState.Notbuilt:
                    newState = BuildingState.Built;
                    SpendResources(name);
                    break;
                case BuildingState.Built:
                    newState = BuildingState.Repaired;
                    SpendResources(name);
                    break;
                case BuildingState.Repaired:
                    newState = BuildingState.Destroyed;
                    break;
                default:
                    newState = BuildingState.Destroyed;
                    break;
            }
            info.State = newState;
        }

        private void SpendResources(string name)
        {
            BuildingInfo info = _buildingData.GetByName(name);
            if (info == null) return;

            foreach (KeyValuePair<CurrencyType, int> costEntry in info.Cost)
            {
                CurrencyType currencyType = costEntry.Key;
                int amount = costEntry.Value;
                _walletService.Spend(currencyType, amount);
            }
        }
    }
}