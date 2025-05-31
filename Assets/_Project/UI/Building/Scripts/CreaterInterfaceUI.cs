using Core.Building;
using UnityEngine;
using Zenject;

namespace UI.Building
{
    public class CreaterInterfaceUI : MonoBehaviour
    {
        [SerializeField] private GameObject _interfacePrefab;
        [SerializeField] private Transform _parent;
        [SerializeField] private BuildingContainerForUI _buildingContainer;

        private DiContainer _container;

        [Inject]
        private void Construct(DiContainer container)
        {
            _container = container;
        }

        private void Start()
        {
            _buildingContainer.PostTransferred += Create;
        }

        private void Create(Transform target)
        {
            GameObject instance = _container.InstantiatePrefab(_interfacePrefab, _parent);
        }

        private void OnDestroy()
        {
            _buildingContainer.PostTransferred -= Create;
        }
    }
}