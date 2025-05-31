using Data.Building;
using Core.Wallets;
using Zenject;
using UnityEngine;
using System.Collections.Generic;

namespace Core.Building
{
    public class InsufficientResourcesChecking : IResourceChecker
    {
        private readonly IWalletService _walletService;
        private readonly IBuildingData _buildingData;

        [Inject]
        public InsufficientResourcesChecking(IWalletService walletService, IBuildingData buildingData)
        {
            _walletService = walletService;
            _buildingData = buildingData;
        }

        public bool HasEnoughResources(string buildingName, BuildingState state)
        {
            // Если здание уже построено или разрушено, ресурсы не нужны
            if (state != BuildingState.Notbuilt && state != BuildingState.Repaired)
            {
                return true;
            }

            // Получаем информацию о здании
            BuildingInfo buildingInfo = _buildingData.GetByName(buildingName);
            if (buildingInfo == null)
            {
                Debug.LogError($"Building {buildingName} not found in BuildingData");
                return false;
            }

            // Проверяем стоимость
            foreach (KeyValuePair<CurrencyType, int> costEntry in buildingInfo.Cost)
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