using UnityEngine;
using Zenject;
using Data.Building;

namespace Core.Building
{
    public class PlayerLocationChecker : MonoBehaviour
    {
        [SerializeField] private string _buildingName;
        [SerializeField] private BuildingContainerForUI _buildingContainer;
        [SerializeField] private GameObject _buildIndicatorPrefab; // Префаб индикатора (например, прозрачная платформа)
        [SerializeField] private Vector3 _buildOffset = new Vector3(0, 0, 2); // Смещение от игрока

        private IUIController _uiController;
        private IBuildingData _buildingData;
        private IBuildingStateManager _stateManager;
        private GameObject _currentBuilding;
        private bool _isPlayerInside;
        private GameObject _currentIndicator; // Текущий индикатор

        [Inject]
        private void Construct(IUIController uiController, IBuildingData buildingData, IBuildingStateManager stateManager)
        {
            _uiController = uiController;
            _buildingData = buildingData;
            _stateManager = stateManager;
            Debug.Log("UIController injected: " + (_uiController != null));
            Debug.Log("BuildingData injected: " + (_buildingData != null));
            Debug.Log("StateManager injected: " + (_stateManager != null));
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
                Debug.Log("Player entered trigger for " + _buildingName);
                _uiController?.CreateUI();
                ShowBuildIndicator(other.transform);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player") && _isPlayerInside)
            {
                _isPlayerInside = false;
                Debug.Log("Player exited trigger for " + _buildingName);
                _uiController?.HideUI();
                HideBuildIndicator();
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
                    Destroy(gameObject); // Удаляем BuildPoint после постройки
                }
            }
            else if (newState == BuildingState.Destroyed && _currentBuilding != null)
            {
                Destroy(_currentBuilding);
                _currentBuilding = null;
            }
        }

        private void ShowBuildIndicator(Transform player)
        {
            if (_buildIndicatorPrefab != null && _currentIndicator == null)
            {
                Vector3 indicatorPosition = player.position + _buildOffset;
                _currentIndicator = Instantiate(_buildIndicatorPrefab, indicatorPosition, Quaternion.identity);
            }
        }

        private void HideBuildIndicator()
        {
            if (_currentIndicator != null)
            {
                Destroy(_currentIndicator);
                _currentIndicator = null;
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
                Debug.LogError($"Prefab for building {info.Name} is null");
                return;
            }
            if (_currentIndicator != null)
            {
                _currentBuilding = Instantiate(info.Prefab, _currentIndicator.transform.position, _currentIndicator.transform.rotation);
                Destroy(_currentIndicator); // Удаляем индикатор после спавна
                _currentIndicator = null;
            }
            else
            {
                Debug.LogWarning("Build indicator not found, using default position");
                _currentBuilding = Instantiate(info.Prefab, transform.position, transform.rotation);
            }
            Debug.Log($"Building {info.Name} spawned at {_currentBuilding.transform.position}");
        }

        private void OnDestroy()
        {
            _stateManager?.OnStateChanged.RemoveListener(OnStateChanged);
            HideBuildIndicator();
        }
    }
}