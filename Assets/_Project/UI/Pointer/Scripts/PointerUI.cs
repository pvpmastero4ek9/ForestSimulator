using UnityEngine;
using Core.Pointer;
using UnityEngine.UI;

namespace UI.Pointer
{
    public class PointerUI : MonoBehaviour
    {
        [SerializeField] private PointerContainerForUI _pointerContainer;
        [SerializeField] private Image _icon;
        [SerializeField] private Vector3 _offset = new Vector3(0, 2f, 0);
        [SerializeField] private float _floatSpeed = 1f;
        [SerializeField] private float _floatHeight = 20f;
        private RectTransform _rectTransform;
        private Transform _target;

        private void Start()
        {
            _rectTransform = GetComponent<RectTransform>();
            _target = _pointerContainer.Target;
            _icon.sprite = _pointerContainer.SpriteIcon;
        }
        
        private void Update()
        {
            if (_target != null)
            {
                Vector3 worldPosition = _target.position + _offset;
                Vector3 screenPos = Camera.main.WorldToScreenPoint(worldPosition);

                float floatY = Mathf.Sin(Time.time * _floatSpeed) * _floatHeight;
                screenPos.y += floatY;

                _rectTransform.position = screenPos;
            }
        }
    }
}
