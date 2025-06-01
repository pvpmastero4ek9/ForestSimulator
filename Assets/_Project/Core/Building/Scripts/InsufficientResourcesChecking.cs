using Data.Building;
using Core.Wallets;
using Zenject;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace Core.Building
{
    public class InsufficientResourcesChecking : IResourceChecker
    {
        private readonly IWalletService _walletService;
        private readonly IBuildingData _buildingData;

        [Inject]
        public InsufficientResourcesChecking(IWalletService walletService, IBuildingData buildingData)
        {
            if (walletService == null) Debug.LogError("IWalletService is null");
            if (buildingData == null) Debug.LogError("IBuildingData is null");
            _walletService = walletService;
            _buildingData = buildingData;
        }

        public bool HasEnoughResources(string buildingName, BuildingState state)
        {
            if (state != BuildingState.Notbuilt && state != BuildingState.Repaired)
            {
                return true;
            }

            if (_buildingData == null)
            {
                return false;
            }

            BuildingInfo buildingInfo = _buildingData.GetByName(buildingName);
            if (buildingInfo == null)
            {
                return false;
            }

           
            var costDictionary = buildingInfo.Costs.ToDictionary(rc => rc.ResourceType, rc => rc.Amount);

            foreach (KeyValuePair<CurrencyType, int> costEntry in costDictionary)
            {
                CurrencyType currencyType = costEntry.Key;
                int requiredAmount = costEntry.Value;
                if (!_walletService.HasEnough(currencyType, requiredAmount))
                {
                    return false;
                }
            }

            return true;
        }
    }
}