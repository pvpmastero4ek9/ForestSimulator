using UnityEngine;
using UnityEngine.UI;
using Core.Building;

namespace UI.Building
{
    public class ButtonStartBuild : MonoBehaviour
    {
        [SerializeField] private Button _button;
        public BuildingContainerForUI _buildingContainer;

        private void Awake()
        {
            if (_button == null)
            {
                _button = GetComponent<Button>();
            }
            _button.onClick.AddListener(OnClick);
        }

        public void Initialize(BuildingContainerForUI container)
        {
            _buildingContainer = container;
        }

        private void OnClick()
        {
            if (_buildingContainer != null)
            {
                Debug.Log("Starting build for BuildingId: " + _buildingContainer.BuildingId);
            }
        }
    }
}