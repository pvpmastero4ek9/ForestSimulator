using System.Collections.Generic;
using Data.Mining;
using Data.PlayerInventory;
using UnityEngine;

namespace UI.PlayerInventory
{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] private InventoryData _inventoryData;
        [SerializeField] private List<InventoryContainerUI> _inventoryContainerList;
        [SerializeField] private Sprite _spriteNull;

        private void OnEnable()
        {
            _inventoryData.AddedTool += UpdateInventoryUI;
        }

        private void Start()
        {
            UpdateInventiryOnStart();  
        }

        private void OnDisable()
        {
            _inventoryData.AddedTool -= UpdateInventoryUI;
        }

        private void UpdateInventoryUI(Tool tool)
        {
            foreach (InventoryContainerUI el in _inventoryContainerList)
            {
                if (el.Icon.sprite == _spriteNull)
                {
                    el.Icon.sprite = tool.Icon;
                    break;
                }
            }
        }

        private void UpdateInventiryOnStart()
        {
            for (var i = 0; i < _inventoryData.InventoryList.Count; i++)
            {
                if (_inventoryData.InventoryList[i].Icon == null) return;
                _inventoryContainerList[i].Icon.sprite = _inventoryData.InventoryList[i].Icon;
            }
        }
    }
}
