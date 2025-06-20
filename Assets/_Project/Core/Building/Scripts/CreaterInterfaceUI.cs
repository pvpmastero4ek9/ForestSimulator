using UnityEngine;
using Data.Building;

namespace Core.Building
{
    public class CreaterInterfaceUI : MonoBehaviour
    {
        [SerializeField] private BuildingContainerForUI _interaceUI_PREFAB;
        [SerializeField] private Canvas _canvasParent;
        [SerializeField] private BuildingData _buildingData;

        private BuildingContainerForUI _buildingCurrentContainer;

        public void CreateUI(Buildings buildings, ConstructBuilding constructBuilding)
        {
            BuildingInfo buildingInfo = GetBuilding(buildings);
            _buildingCurrentContainer = Instantiate(_interaceUI_PREFAB, _canvasParent.transform).Init(buildingInfo, constructBuilding);
        }

        public void DeliteUI()
        {
            Destroy(_buildingCurrentContainer.gameObject);
        }

        private BuildingInfo GetBuilding(Buildings buildings)
        {
            return _buildingData.GetBuildingData(buildings);
        }
    }

}