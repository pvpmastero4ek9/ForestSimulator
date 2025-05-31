using UnityEngine;
using Data.PlayerInventory;
using Data.Mining;

namespace Core.SelectionTools
{
    public class ToolLocation : MonoBehaviour
    {
        [SerializeField] private InventoryData _inventoryData;
        [SerializeField] private MiningData _miningData;
        [SerializeField] private string _toolName;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                _inventoryData.AddTool(_miningData.GetTool(_toolName));
                Destroy(gameObject);
            }
        }
    }
}
