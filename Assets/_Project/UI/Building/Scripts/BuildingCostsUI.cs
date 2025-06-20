using UnityEngine;
using Core.Building;
using Data.Building;
using UI.UnlockLocations;

namespace UI.Building
{
    public class BuildingCostsUI : MonoBehaviour
    {
        [SerializeField] private BuildingContainerForUI _buildingContainer;
        [SerializeField] private CoastLocationItem CoastLocationItem_PREFAB;

        private BuildingInfo _buildingInfo;

        private void OnEnable()
        {
            _buildingContainer.Inited += CreateCostItems;
        }

        private void OnDisable()
        {
            _buildingContainer.Inited -= CreateCostItems;
        }

        private void CreateCostItems()
        {
            _buildingInfo = _buildingContainer.BuildingInfo;

            foreach (ResourceCost cost in _buildingInfo.Costs)
            {
                Instantiate(CoastLocationItem_PREFAB, transform)
                    .Init(cost.ResourceType, cost.Amount);
            }
        }
    }
}