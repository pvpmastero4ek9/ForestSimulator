using Core.Building;
using UnityEngine;
using Zenject;

namespace Ui.Building
{
    public class CreaterInterfaceUI : MonoBehaviour, IUIController
    {
        [SerializeField] private GameObject _interfacePrefab;
        [SerializeField] private Transform _parent;
        [SerializeField] private BuildingContainerForUI _buildingContainer; 

        private DiContainer _container;
        private GameObject _currentInterface;

        [Inject]
        private void Construct(DiContainer container)
        {
            _container = container;
        }

        public void CreateUI()
        {
            if (_currentInterface != null)
            {
                Destroy(_currentInterface);
            }
            _currentInterface = _container.InstantiatePrefab(_interfacePrefab, _parent);
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