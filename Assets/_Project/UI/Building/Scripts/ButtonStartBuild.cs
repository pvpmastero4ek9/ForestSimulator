using UnityEngine;
using UnityEngine.UI;
using Core.Building;

namespace UI.Building
{
    public class ButtonStartBuild : MonoBehaviour
    {
        [SerializeField] private Button _button;
        public BuildingContainerForUI _buildingContainer; // Сделали публичным для инициализации

        private void Awake()
        {
            if (_button == null)
            {
                _button = GetComponent<Button>();
                if (_button == null)
                {
                    Debug.LogError("Button component not found on ButtonStartBuild");
                    return;
                }
            }
            _button.onClick.AddListener(OnClick);
        }

        public void Initialize(BuildingContainerForUI container)
        {
            _buildingContainer = container;
            Debug.Log("ButtonStartBuild initialized with BuildingContainer: " + (_buildingContainer != null));
        }

        private void OnClick()
        {
            if (_buildingContainer == null)
            {
                Debug.LogError("One or more dependencies are null in ButtonStartBuild");
                return;
            }

            // Логика начала строительства
            Debug.Log("Starting build for BuildingId: " + _buildingContainer.BuildingId);
            // Здесь добавьте вашу логику строительства
        }
    }
}