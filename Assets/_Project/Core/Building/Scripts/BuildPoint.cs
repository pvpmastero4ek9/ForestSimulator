using System.Linq;
using UnityEngine;
using Core.Wallets;
using Zenject;

namespace Core.Building
{
    [RequireComponent(typeof(Collider))]
    public class BuildPoint : MonoBehaviour
    {
        [SerializeField] private DataBuilding buildingData;
        [SerializeField] private GameObject hammerIcon;
        [SerializeField] private GameObject uiPanelPrefab;

        private Wallet _wallet;
        private GameObject _activeUiPanel;

        [Inject]
        private void Construct(Wallet wallet)
        {
            _wallet = wallet;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;

            hammerIcon.SetActive(true);
            ShowBuildUI();
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.CompareTag("Player")) return;

            hammerIcon.SetActive(false);
            HideBuildUI();
        }

        private void ShowBuildUI()
        {
            if (_activeUiPanel != null) return;

            _activeUiPanel = Instantiate(uiPanelPrefab, transform.position + Vector3.up * 2f, Quaternion.identity);
            var uiComponent = _activeUiPanel.GetComponent<IBuildUI>();
            uiComponent.Initialize(buildingData, AttemptToBuild);
        }

        private void HideBuildUI()
        {
            if (_activeUiPanel != null)
            {
                Destroy(_activeUiPanel);
                _activeUiPanel = null;
            }
        }

        private void AttemptToBuild()
        {
            if (!HasEnoughResources()) return;

            SpendResources();
            Instantiate(buildingData.BuildingPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject); // удаляем точку постройки
        }

        public interface IBuildUI
        {
            void Initialize(DataBuilding data, System.Action onBuildPressed);
        }

        private bool HasEnoughResources()
        {
            return buildingData.CostList.All(cost =>
            {
                Currency currency = _wallet.GetCurrency(cost.ResourceType);
                return currency.Value >= cost.Amount;
            });
        }

        private void SpendResources()
        {
            foreach (var cost in buildingData.CostList)
            {
                Currency currency = _wallet.GetCurrency(cost.ResourceType);
                currency.Value -= cost.Amount;
            }
        }
    }
}
