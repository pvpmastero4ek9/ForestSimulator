using Data.Mining;
using UnityEngine;

namespace Data.PlayerInventory
{
    public class DELITE_ME : MonoBehaviour
    {
        [SerializeField] private MiningData _miningData;
        [SerializeField] private InventoryData _inventoryData;
        private void Start()
        {
            _inventoryData.ClearAllSlots();
            _inventoryData.AddTool(_miningData.ToolsList[0]);
            _inventoryData.AddTool(_miningData.ToolsList[1]);
        }
    }
}
