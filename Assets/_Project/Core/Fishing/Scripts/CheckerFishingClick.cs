using UnityEngine;

namespace Core.Fishing
{
    public class CheckerFishingClick : MonoBehaviour
    {
        [SerializeField] private float _range = 3f;
        [SerializeField] private LayerMask _mineableMask;

        public delegate void OnToolSelectedHandler(Vector3 targetPosition);
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
                        OnToolSelected?.Invoke(hit.collider.gameObject.transform.position);
                    }
                }
            }
        }
    }
}
