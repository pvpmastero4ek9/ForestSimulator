using UnityEngine;
using System;

namespace Core.Building
{
    public class PlayerLocationChecker : MonoBehaviour
    {
        [SerializeField] private string _buildingName;

        public event Action OnPlayerEntered;

        public string BuildingName => _buildingName;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                OnPlayerEntered?.Invoke();
            }
        }
    }
}