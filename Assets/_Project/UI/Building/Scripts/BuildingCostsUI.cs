using UnityEngine;
using Core.Wallets;
using Data.Building;
using System.Collections.Generic;
using Core.Building;
using UI.UnlockLocations;

namespace UI.Building
{
    public class BuildingCostsUI : MonoBehaviour
    {
        [SerializeField] private BuildingContainerForUI _buildingContainer;
        [SerializeField] private CoastLocationItem CoastLocationItem_PREFAB;
        [SerializeField] private BuildingData _buildingData;

        private BuildingInfo _buildingInfo;

        private void OnEnable()
        {
            CreateCostItems();
        }

        private void CreateCostItems()
        {
            _buildingInfo = _buildingData.GetByName(_buildingContainer.BuildingId);
            if (_buildingInfo == null) return;

            foreach (ResourceCost cost in _buildingInfo.Costs)
            {
                Instantiate(CoastLocationItem_PREFAB, transform)
                    .Init(cost.ResourceType, cost.Amount);
            }
        }
    }
}
