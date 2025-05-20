using UnityEngine;
using Data.Mining;
using System.Linq;
using System.Collections.Generic;

namespace Data.PlayerInventory
{
    public class InventoryData : ScriptableObject
    {
        private const int LengthInventoryArray = 3;
        [SerializeField] private Tool[] _inventoryArray = new Tool[LengthInventoryArray];
        public List<Tool> InventoryArray => _inventoryArray.ToList();

        public void AddTool(Tool tool)
        {
            for (var i = 0; i < _inventoryArray.Length; i++)
            {
                if (_inventoryArray[i] == null)
                {
                    _inventoryArray[i] = tool;
                }
            }
        }
    }
}
