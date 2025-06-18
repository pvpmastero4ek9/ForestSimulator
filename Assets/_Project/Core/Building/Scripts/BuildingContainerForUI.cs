using UnityEngine;
using System;

namespace Core.Building
{
    public class BuildingContainerForUI : MonoBehaviour
    {
        [SerializeField] private string _buildingId;

        public string BuildingId
        {
            get => _buildingId;
            set
            {
                _buildingId = value;
                Inited?.Invoke(); // Используем правильное имя события Inited
            }
        }

        public event Action Inited;

        private void OnValidate()
        {
            if (string.IsNullOrEmpty(_buildingId))
            {
                _buildingId = "Default";
            }
        }
    }
}