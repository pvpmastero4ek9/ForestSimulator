using UnityEngine;
using Core.Wallets;
using Data.Building;
using System.Collections.Generic;
using Core.Building;
using UI.UnlockLocations;
using TMPro;
using Zenject;

namespace UI.Building
{
    public class BuildingCostsUI : MonoBehaviour
    {
        [SerializeField] private CoastLocationItem CoastLocationItem_PREFAB;
        [SerializeField] private BuildingData _buildingData;
        [SerializeField] private TMP_Text buildingNameText;

        private BuildingContainerForUI _buildingContainer;
        private BuildingInfo _buildingInfo;

        [Inject]
        public void Construct(BuildingContainerForUI buildingContainer)
        {
            _buildingContainer = buildingContainer;
            UpdateBuildingName();
            CreateCostItems();
        }

        public void UpdateBuildingName()
        {
            if (_buildingContainer != null && buildingNameText != null)
            {
                _buildingInfo = _buildingData.GetByName(_buildingContainer.BuildingId);
                if (_buildingInfo != null)
                {
                    buildingNameText.text = _buildingInfo.Name;
                    Debug.Log("Building name updated to: " + _buildingInfo.Name);
                }
            }
        }

        public void CreateCostItems()
        {
            // Очищаем предыдущие элементы
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }

            if (_buildingContainer != null)
            {
                _buildingInfo = _buildingData.GetByName(_buildingContainer.BuildingId);
                if (_buildingInfo == null) return;

                foreach (ResourceCost cost in _buildingInfo.Costs)
                {
                    CoastLocationItem item = Instantiate(CoastLocationItem_PREFAB, transform);
                    item.Init(cost.ResourceType, cost.Amount);
                    Debug.Log($"Created cost item: {cost.ResourceType} - {cost.Amount}");
                }
            }
        }

        private void OnEnable()
        {
            UpdateBuildingName();
            CreateCostItems();
        }
    }
}