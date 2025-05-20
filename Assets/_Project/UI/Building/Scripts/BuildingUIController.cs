using System;
using Data.Building;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

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
            // infoPanelView.Show(data);
        }
    }
}
