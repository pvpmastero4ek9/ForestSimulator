using Core.Building;
using UnityEngine;
using Zenject;
using Data.Building;

namespace UI.Building
{
    public class CreaterInterfaceUI : MonoBehaviour, IUIController
    {
        [SerializeField] private GameObject _interfacePrefab;
        [SerializeField] private Transform _parent;
        [SerializeField] private BuildingContainerForUI _buildingContainer;

        private GameObject _currentInterface;
        private IBuildingData _buildingData;

        [Inject]
        public void Construct(IBuildingData buildingData)
        {
            _buildingData = buildingData;
        }

        public void CreateUI()
        {
            CreateUI(null);
        }

        public void CreateUI(string buildingName)
        {
            if (_currentInterface != null)
            {
                Destroy(_currentInterface);
            }

            _currentInterface = Instantiate(_interfacePrefab, _parent);

            string buildingId = string.IsNullOrEmpty(buildingName) ? _buildingContainer.BuildingId : buildingName;
            _buildingContainer.BuildingId = buildingId;

            UpdateUIComponents(_currentInterface, buildingId);
        }

        public void UpdateUI(string buildingName)
        {
            if (_currentInterface != null && _buildingContainer != null)
            {
                string buildingId = string.IsNullOrEmpty(buildingName) ? _buildingContainer.BuildingId : buildingName;
                _buildingContainer.BuildingId = buildingId;

                UpdateUIComponents(_currentInterface, buildingId);
            }
        }

        private void UpdateUIComponents(GameObject uiInstance, string buildingId)
        {
            BuildingInfo buildingInfo = _buildingData.GetByName(buildingId);
            if (buildingInfo != null)
            {
                BuildingCostsUI costsUI = uiInstance.GetComponentInChildren<BuildingCostsUI>();
                ButtonStartBuild buildButton = uiInstance.GetComponentInChildren<ButtonStartBuild>();
                if (buildButton != null)
                {
                    buildButton._buildingContainer = _buildingContainer;
                }

                BuildingButtonsState buttonsState = uiInstance.GetComponentInChildren<BuildingButtonsState>();
            }
        }

        public void HideUI()
        {
            if (_currentInterface != null)
            {
                Destroy(_currentInterface);
                _currentInterface = null;
            }
        }

        private void OnDestroy()
        {
            if (_currentInterface != null)
            {
                Destroy(_currentInterface);
                _currentInterface = null;
            }
        }
    }

}