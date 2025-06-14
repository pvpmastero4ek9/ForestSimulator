using UnityEngine;
using Zenject;
using Data.Building;

namespace Core.Building
{
    public class PlayerLocationChecker : MonoBehaviour
    {
        [SerializeField] private string _buildingName;
        [SerializeField] private BuildingContainerForUI _buildingContainer;
        [SerializeField] private GameObject _buildIndicatorPrefab;
        [SerializeField] private Vector3 _buildOffset = new Vector3(0, 0, 2);
        [SerializeField] private Vector3 _indicatorScale = new Vector3(0.5f, 0.5f, 0.5f); // Новый параметр для масштаба

        private IUIController _uiController;
        private IBuildingData _buildingData;
        private IBuildingStateManager _stateManager;
        private GameObject _currentBuilding;
        private bool _isPlayerInside;
        private GameObject _currentIndicator;

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
                ShowBuildIndicator(other.transform);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player") && _isPlayerInside)
            {
                _isPlayerInside = false;
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
                    _uiController?.HideUI();
                    Destroy(gameObject);
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
                _currentIndicator.transform.localScale = _indicatorScale; 
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
            if (_currentIndicator != null)
            {
                _currentBuilding = Instantiate(info.Prefab, _currentIndicator.transform.position, _currentIndicator.transform.rotation);
                Destroy(_currentIndicator);
                _currentIndicator = null;
            }
            else
            {
                _currentBuilding = Instantiate(info.Prefab, transform.position, transform.rotation);
            }
        }

        private void OnDestroy()
        {
            _stateManager?.OnStateChanged.RemoveListener(OnStateChanged);
            HideBuildIndicator();
        }
    }
}