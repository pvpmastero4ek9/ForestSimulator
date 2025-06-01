using UnityEngine;
using Zenject;
using Data.Building;

namespace Core.Building
{
    public class PlayerLocationChecker : MonoBehaviour
    {
        [SerializeField] private string _buildingName;
        [SerializeField] private BuildingContainerForUI _buildingContainer;

        private IUIController _uiController;
        private IBuildingData _buildingData;
        private IBuildingStateManager _stateManager;
        private GameObject _currentBuilding;
        private bool _isPlayerInside;

        [Inject]
        private void Construct(IUIController uiController, IBuildingData buildingData, IBuildingStateManager stateManager)
        {
            _uiController = uiController;
            _buildingData = buildingData;
            _stateManager = stateManager;
        }

        private void Start()
        {
            _stateManager.OnStateChanged.AddListener(OnStateChanged);

            BuildingInfo info = _buildingData.GetByName(_buildingName);
            if (info != null && info.State == BuildingState.Built)
            {
                SpawnBuilding(info);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player") && !_isPlayerInside)
            {
                _isPlayerInside = true;
                _uiController?.CreateUI();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player") && _isPlayerInside)
            {
                _isPlayerInside = false;
                _uiController?.HideUI();
            }
        }

        public void OnStateChanged(string buildingName, BuildingState newState)
        {
            if (buildingName != _buildingName) return;

            if (newState == BuildingState.Built)
            {
                BuildingInfo info = _buildingData.GetByName(buildingName);
                if (info != null)
                {
                    SpawnBuilding(info);
                }
            }
            else if (newState == BuildingState.Destroyed && _currentBuilding != null)
            {
                Destroy(_currentBuilding);
                _currentBuilding = null;
            }
        }

        private void SpawnBuilding(BuildingInfo info)
        {
            if (_currentBuilding != null)
            {
                Destroy(_currentBuilding);
            }
            if (info.Prefab == null)
            {
                return;
            }
            _currentBuilding = Instantiate(info.Prefab, transform.position, transform.rotation);
            Debug.Log($"Building {info.Name} spawned at {transform.position}");
        }

        private void OnDestroy()
        {
            _stateManager?.OnStateChanged.RemoveListener(OnStateChanged);
        }
    }
}