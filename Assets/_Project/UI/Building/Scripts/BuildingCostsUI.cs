using UnityEngine;
using Core.Wallets;
using Data.Building;
using System.Collections.Generic;
using Core.Building;
using UI.UnlockLocations;
using TMPro; 

namespace UI.Building
{
    public class BuildingCostsUI : MonoBehaviour
    {
        [SerializeField] private BuildingContainerForUI _buildingContainer;
        [SerializeField] private CoastLocationItem CoastLocationItem_PREFAB;
        [SerializeField] private BuildingData _buildingData;
        [SerializeField] private TMP_Text buildingNameText; 

        private BuildingInfo _buildingInfo;

        private void OnEnable()
        {
            UpdateBuildingName();
            CreateCostItems();
        }

        private void UpdateBuildingName()
        {
            _buildingInfo = _buildingData.GetByName(_buildingContainer.BuildingId);
            if (_buildingInfo != null && buildingNameText != null)
            {
                buildingNameText.text = _buildingInfo.Name; 
            }
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