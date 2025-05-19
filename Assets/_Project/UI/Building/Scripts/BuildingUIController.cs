using UnityEngine;
using UnityEngine.UIElements;
using Zenject;
using Core.Interfaces;

namespace UI.Building
{
    public class BuildingUIController : MonoBehaviour
    {
        [SerializeField] private BuildingInfoPanelView infoPanelView;
        private IBuildingSelectionService selectionService;

        [Inject]
        public void Construct(IBuildingSelectionService selectionService)
        {
            this.selectionService = selectionService;
        }

        private void OnEnable()
        {
            selectionService.OnBuildingSelected += ShowBuildingInfo;
        }

        private void OnDisable()
        {
            selectionService.OnBuildingSelected -= ShowBuildingInfo;
        }

        private void ShowBuildingInfo(DataBuilding data)
        {
            infoPanelView.Show(data);
        }
    }
}
