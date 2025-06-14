using Core.Building;
using UnityEngine;
using Zenject;
using Data.Building;
using Core.Wallets;
using UI.Building;

namespace Ui.Building
{
    public class CreaterInterfaceUI : MonoBehaviour, IUIController
    {
        [SerializeField] private GameObject _interfacePrefab;
        [SerializeField] private Transform _parent;
        [SerializeField] private BuildingContainerForUI _buildingContainer;

        private DiContainer _container;
        private GameObject _currentInterface;
        private IBuildingData _buildingData;

        [Inject]
        public void Construct(DiContainer container, IBuildingData buildingData)
        {
            _container = container;
            _buildingData = buildingData;
        }

        public void CreateUI()
        {
            if (_currentInterface != null)
            {
                Destroy(_currentInterface);
            }

            _currentInterface = _container.InstantiatePrefab(_interfacePrefab, _parent);

            string buildingId = _buildingContainer.BuildingId;
            BuildingInfo buildingInfo = _buildingData.GetByName(buildingId);

            if (buildingInfo != null)
            {
               
                ButtonStartBuild buildButton = _currentInterface.GetComponentInChildren<ButtonStartBuild>();
                if (buildButton != null)
                {
                    buildButton.SetBuildingName(buildingId);
                }

                
                CloseButton closeButton = _currentInterface.GetComponentInChildren<CloseButton>();
                if (closeButton != null)
                {
                    closeButton.Initialize(); 
                }
            }
        }

        private void ClearAndUpdateResources(Transform resourceContainer, BuildingInfo buildingInfo)
        {
            foreach (Transform child in resourceContainer)
            {
                child.gameObject.SetActive(false);
            }

            if (buildingInfo.Costs == null || buildingInfo.Costs.Count == 0)
            {
                return;
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
        }

        private void HideUI()
        {
            _uiController?.HideUI();
        }
    }
}