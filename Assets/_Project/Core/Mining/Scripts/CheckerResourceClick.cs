using UnityEngine;
using Data.Mining;
using Data.PlayerInventory;
using System.Linq;

namespace Core.Mining
{
    public class CheckerResourceClick : MonoBehaviour
    {
        [SerializeField] private float _range = 3f;
        [SerializeField] private InventoryData _inventoryData;
        [SerializeField] private MiningData _miningData;
        [SerializeField] private LayerMask _mineableMask;

        public delegate void OnToolSelectedHandler(Tool tool, ResourceNode resourceNode);
        public event OnToolSelectedHandler OnToolSelected;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0)) // Здесь возможно придётся через интерфейсы делать, если будем добавлять управление с телефонов
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit, _range, _mineableMask))
                {
                    int hitLayerMask = hit.collider.gameObject.layer;
                    if (((1 << hitLayerMask) & _mineableMask.value) != 0)
                    {
                        Tool tool = _miningData.ToolsList.FirstOrDefault(x => (x.LayerMask.value & (1 << hitLayerMask)) != 0);
                        if (_inventoryData.IsToolInInventory(tool.ToolName))
                        {
                            ResourceNode resourceNode = hit.collider.GetComponent<ResourceNode>();
                            if (resourceNode.CanBeMined)
                            {
                                OnToolSelected?.Invoke(tool, resourceNode);
                            }
                        }
                    }
                }
            }   
        }
    }
}
