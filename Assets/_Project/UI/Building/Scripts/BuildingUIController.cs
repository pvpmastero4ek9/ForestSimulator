using UnityEngine;
<<<<<<< Updated upstream
using UnityEngine.UIElements;
using Zenject;
using Core.Interfaces;
=======
>>>>>>> Stashed changes

namespace UI.Building
{
    public class BuildUIController : MonoBehaviour, IBuildUIController
    {
        [SerializeField] private GameObject panel;

        public void Show()
        {
            panel.SetActive(true);
        }

        public void Hide()
        {
<<<<<<< Updated upstream
            selectionService.OnBuildingSelected += ShowBuildingInfo;
        }

        private void OnDisable()
        {
            selectionService.OnBuildingSelected -= ShowBuildingInfo;
        }

        private void ShowBuildingInfo(DataBuilding data)
        {
            infoPanelView.Show(data);
=======
            panel.SetActive(false);
>>>>>>> Stashed changes
        }
    }
}
