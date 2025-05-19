using UnityEngine;
using Data.Building;
using Zenject;

namespace Core.Building
{
    public class BuildPoint : MonoBehaviour
    {
        [SerializeField] private DataBuilding buildingData;
        [SerializeField] private GameObject hammerIcon;

        private IBuildUIController _ui;

        [Inject]
        public void Construct(IBuildUIController ui)
        {
            _ui = ui;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;

            hammerIcon.SetActive(true);
            _ui.Show(buildingData, this);
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag("Player")) return;

            hammerIcon.SetActive(false);
            _ui.Hide();
        }
    }
}
