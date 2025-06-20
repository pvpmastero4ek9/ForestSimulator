using UnityEngine;
using UnityEngine.UI;
using Core.Building;
using UI.Common;

namespace UI.Building
{
    public class ButtonStartBuild : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private CloseButton _buttonClose;
        [SerializeField] BuildingContainerForUI _buildingContainer;

        private void OnEnable()
        {
            _button.onClick.AddListener(CreateBuild);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(CreateBuild);
        }

        private void CreateBuild()
        {
            _buildingContainer.ConstructBuilding.Createbuilding(_buildingContainer.BuildingInfo.Prefab, _buildingContainer.BuildingInfo.Costs);
            Destroy(_buildingContainer.ConstructBuilding.gameObject);

            _buttonClose.CloseObject();
        }
    }
}