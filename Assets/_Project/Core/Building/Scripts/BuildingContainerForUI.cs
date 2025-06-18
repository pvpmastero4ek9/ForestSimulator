using UnityEngine;
using TMPro; 

namespace Core.Building
{
    public class BuildingContainerForUI : MonoBehaviour
    {
        [SerializeField] private string _buildingId;
        

        public GameObject Target { get; set; }
        public string BuildingId
        {
            get => _buildingId;
            set
            {
                _buildingId = value;
                
            }
        }

        

        private void OnValidate()
        {
           
        }

        private void Start()
        {
            
        }
    }
}