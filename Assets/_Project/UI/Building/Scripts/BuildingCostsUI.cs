using UnityEngine;
using Core.Building;
using Core.Wallets;
using Data.Building;
using System.Collections.Generic;
using TMPro;
using UI.UnlockLocations;

namespace UI.Building
{
    public class BuildingCostsUI : MonoBehaviour
    {
        [SerializeField] private CoastLocationItem CoastLocationItem_PREFAB;
        [SerializeField] private BuildingData _buildingData;
        [SerializeField] private TMP_Text buildingNameText;

        private BuildingContainerForUI _buildingContainer;
        private BuildingInfo _buildingInfo;

        private void OnEnable()
        {
            _buildingContainer = GetComponentInParent<BuildingContainerForUI>();
            if (_buildingContainer != null)
            {
                _buildingContainer.Inited += UpdateUI;
            }
            UpdateUI();
        }

        private void OnDisable()
        {
            if (_buildingContainer != null)
            {
                _buildingContainer.Inited -= UpdateUI;
            }
        }

        private void UpdateUI()
        {
            if (_buildingContainer != null && _buildingData != null)
            {
                _buildingInfo = _buildingData.GetByName(_buildingContainer.BuildingId);
                if (_buildingInfo != null)
                {
                    UpdateBuildingName();
                    CreateCostItems();
                }
            }
        }

        private void UpdateBuildingName()
        {
            if (buildingNameText != null)
            {
                buildingNameText.text = _buildingInfo.Name;
            }
        }

        private void CreateCostItems()
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }

            if (_buildingInfo != null)
            {
                foreach (ResourceCost cost in _buildingInfo.Costs)
                {
                    CoastLocationItem item = Instantiate(CoastLocationItem_PREFAB, transform);
                    item.Init(cost.ResourceType, cost.Amount);
                }
            }
        }
    }
}