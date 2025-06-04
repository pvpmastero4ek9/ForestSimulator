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
        public List<Tool> InventoryList => _inventoryArray.ToList();

        public delegate void AddedToolHandler(Tool tool);
        public event AddedToolHandler AddedTool;

        public void AddTool(Tool tool)
        {
            for (var i = 0; i < _inventoryArray.Length; i++)
            {
                if (_inventoryArray[i].ToolName == null)
                {
                    _inventoryArray[i] = tool;
                    AddedTool?.Invoke(tool);
                    break;
                }
            }
        }

        public bool IsToolInInventory(string toolName)
        {
            return _inventoryArray.Any(x => x.ToolName == toolName);
        }

        public void ClearAllSlots()
        {
            for (int i = 0; i < _inventoryArray.Length; i++)
            {
                _inventoryArray[i] = new();
            }
        }
    }
}
