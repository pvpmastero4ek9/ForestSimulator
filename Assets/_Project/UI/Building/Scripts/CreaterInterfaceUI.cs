using Core.Building;
using UnityEngine;
using Zenject;
using Data.Building;
using Core.Wallets;
using UnityEngine.UI;
using UI.Building;
using TMPro;

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
            CreateUI(null); // Вызов перегрузки с параметром по умолчанию
        }

        public void CreateUI(string buildingName)
        {
            if (_currentInterface != null)
            {
                Destroy(_currentInterface);
            }

            if (_interfacePrefab == null)
            {
                Debug.LogError("Interface Prefab is not assigned in CreaterInterfaceUI");
                return;
            }

            _currentInterface = Instantiate(_interfacePrefab, _parent);
            Debug.Log("Interface instantiated: " + _currentInterface.name);

            if (_buildingContainer != null)
            {
                string buildingId = string.IsNullOrEmpty(buildingName) ? _buildingContainer.BuildingId : buildingName;
                _buildingContainer.BuildingId = buildingId;
                Debug.Log("Set BuildingId to " + buildingId + " in BuildUI instance");

                BuildingContainerForUI instanceContainer = _currentInterface.GetComponent<BuildingContainerForUI>();
                if (instanceContainer != null)
                {
                    instanceContainer.BuildingId = buildingId;
                }
                else
                {
                    instanceContainer = _currentInterface.AddComponent<BuildingContainerForUI>();
                    instanceContainer.BuildingId = buildingId;
                    Debug.LogWarning("BuildingContainerForUI not found, added dynamically with BuildingId: " + buildingId);
                }

                BuildingCostsUI costsUI = _currentInterface.GetComponentInChildren<BuildingCostsUI>();
                if (costsUI != null)
                {
                    costsUI.Initialize(_buildingContainer);
                }
                else
                {
                    Debug.LogError("BuildingCostsUI not found in instantiated BuildUI");
                }

                ButtonStartBuild buildButton = _currentInterface.GetComponentInChildren<ButtonStartBuild>();
                if (buildButton != null)
                {
                    buildButton.Initialize(_buildingContainer);
                }
                else
                {
                    Debug.LogError("ButtonStartBuild not found in instantiated BuildUI");
                }

                BuildingButtonsState buttonsState = _currentInterface.GetComponentInChildren<BuildingButtonsState>();
                if (buttonsState != null)
                {
                    BuildingContainerForUI stateContainer = _currentInterface.GetComponent<BuildingContainerForUI>();
                    if (stateContainer != null)
                    {
                        buttonsState._buildingContainer = stateContainer;
                    }
                    else
                    {
                        Debug.LogError("BuildingContainerForUI not found for BuildingButtonsState");
                    }
                }
                else
                {
                    Debug.LogError("BuildingButtonsState not found in instantiated BuildUI");
                }

                UpdateUIComponents(_currentInterface, buildingId);
            }
            else
            {
                Debug.LogError("BuildingContainer is null in CreaterInterfaceUI");
            }
        }

        public void UpdateUI(string buildingName)
        {
            if (_currentInterface != null && _buildingContainer != null)
            {
                string buildingId = string.IsNullOrEmpty(buildingName) ? _buildingContainer.BuildingId : buildingName;
                _buildingContainer.BuildingId = buildingId;
                Debug.Log("Updating UI with BuildingId: " + buildingId);

                BuildingContainerForUI instanceContainer = _currentInterface.GetComponent<BuildingContainerForUI>();
                if (instanceContainer != null)
                {
                    instanceContainer.BuildingId = buildingId;
                    Debug.Log("Updated BuildingId to " + buildingId + " in BuildUI instance");
                }
                else
                {
                    instanceContainer = _currentInterface.AddComponent<BuildingContainerForUI>();
                    instanceContainer.BuildingId = buildingId;
                    Debug.LogWarning("BuildingContainerForUI not found, added dynamically with BuildingId: " + buildingId);
                }

                BuildingCostsUI costsUI = _currentInterface.GetComponentInChildren<BuildingCostsUI>();
                if (costsUI != null)
                {
                    costsUI.Initialize(_buildingContainer);
                }

                ButtonStartBuild buildButton = _currentInterface.GetComponentInChildren<ButtonStartBuild>();
                if (buildButton != null)
                {
                    buildButton.Initialize(_buildingContainer);
                }

                BuildingButtonsState buttonsState = _currentInterface.GetComponentInChildren<BuildingButtonsState>();
                if (buttonsState != null)
                {
                    BuildingContainerForUI stateContainer = _currentInterface.GetComponent<BuildingContainerForUI>();
                    if (stateContainer != null)
                    {
                        buttonsState._buildingContainer = stateContainer;
                    }
                }

                UpdateUIComponents(_currentInterface, buildingId);
            }
        }

        private void UpdateUIComponents(GameObject uiInstance, string buildingId)
        {
            BuildingInfo buildingInfo = _buildingData.GetByName(buildingId);
            if (buildingInfo != null)
            {
                BuildingCostsUI costsUI = uiInstance.GetComponentInChildren<BuildingCostsUI>();
                if (costsUI != null)
                {
                    costsUI.UpdateBuildingName();
                    costsUI.CreateCostItems();
                    Debug.Log("BuildingCostsUI updated with: " + buildingId);
                }
                else
                {
                    Debug.LogWarning("BuildingCostsUI not found in children of " + uiInstance.name);
                }

                ButtonStartBuild buildButton = uiInstance.GetComponentInChildren<ButtonStartBuild>();
                if (buildButton != null)
                {
                    if (buildButton._buildingContainer == null)
                    {
                        buildButton._buildingContainer = _buildingContainer;
                        Debug.LogWarning("BuildingContainer manually assigned to ButtonStartBuild");
                    }
                }
                else
                {
                    Debug.LogWarning("ButtonStartBuild component not found in children of " + uiInstance.name);
                }

                CloseButton closeButton = uiInstance.GetComponentInChildren<CloseButton>();
                if (closeButton != null)
                {
                    closeButton.Initialize();
                }
                else
                {
                    Debug.LogWarning("CloseButton component not found in children of " + uiInstance.name);
                }
            }
            else
            {
                Debug.LogWarning("BuildingInfo not found for BuildingId: " + buildingId);
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

        private Sprite GetResourceIcon(CurrencyType resourceType)
        {
            switch (resourceType)
            {
                case CurrencyType.wood:
                    return Resources.Load<Sprite>("Wood");
                case CurrencyType.stone:
                    return Resources.Load<Sprite>("Stone");
                case CurrencyType.branch:
                    return Resources.Load<Sprite>("Branch");
                default:
                    Debug.LogWarning("Icon not found for " + resourceType);
                    return null;
            }
        }
    }

    public class CloseButton : MonoBehaviour
    {
        private IUIController _uiController;

        [Inject]
        public void Construct(IUIController uiController)
        {
            _uiController = uiController;
        }

        public void Initialize()
        {
            UnityEngine.UI.Button button = GetComponent<UnityEngine.UI.Button>();
            if (button != null)
            {
                button.onClick.AddListener(HideUI);
            }
            else
            {
                Debug.LogError("Button component not found on CloseButton");
            }
        }

        private void HideUI()
        {
            _uiController?.HideUI();
        }
    }
}