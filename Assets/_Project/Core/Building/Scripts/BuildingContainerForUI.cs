using UnityEngine;

namespace Core.Building
{
    public class BuildingContainerForUI : MonoBehaviour
    {
        [SerializeField] private string _buildingId;
        public GameObject Target { get; set; } 
        public string BuildingId => _buildingId; 
    }
}