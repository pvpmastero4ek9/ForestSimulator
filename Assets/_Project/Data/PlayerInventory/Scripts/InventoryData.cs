using UnityEngine;
using Data.Mining;
using System.Linq;
using System.Collections.Generic;

namespace Data.PlayerInventory
{
    [CreateAssetMenu(fileName = "InventoryData", menuName = "Inventory/InventoryData")]
    public class InventoryData : ScriptableObject
    {
        private const int LengthInventoryArray = 3;
        [SerializeField] private Tool[] _inventoryArray = new Tool[LengthInventoryArray];
        public List<Tool> InventoryArray => _inventoryArray.ToList();

        public void AddTool(Tool tool)
        {
            for (var i = 0; i < _inventoryArray.Length; i++)
            {
                if (_inventoryArray[i].ToolName == "")
                {
                    _inventoryArray[i] = tool;
                    break;
                }
            }
        }

        public bool IsToolInInventory(string toolName)
        {
            return _inventoryArray.Any(x => x.ToolName == toolName);
        }
    }
}
