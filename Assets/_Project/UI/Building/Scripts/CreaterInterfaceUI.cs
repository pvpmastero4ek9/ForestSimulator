using Core.Building;
using UnityEngine;

namespace UI.Building
{
    public class CreaterInterfaceUI : MonoBehaviour
    {
        [SerializeField] private GameObject _interfacePrefab;
        [SerializeField] private Transform _parent;
        [SerializeField] private BuildingContainerForUI _buildingContainer;

        private void Start()
        {
            _buildingContainer.PostTransferred += Create;
        }

        private void Create(Transform target)
        {
            Instantiate(_interfacePrefab, _parent);
        }

        private void OnDestroy()
        {
            _buildingContainer.PostTransferred -= Create;
        }
    }
}