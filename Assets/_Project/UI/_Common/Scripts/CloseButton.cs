using UnityEngine;
using UnityEngine.UI;

namespace UI.Common
{
    public class CloseButton : MonoBehaviour
    {
        [SerializeField] private GameObject _closedObject;
        [SerializeField] private Button _button;

        private void OnEnable()
        {
            _button.onClick.AddListener(CloseObject);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(CloseObject);
        }

        public void CloseObject()
        {
            Destroy(_closedObject);
        }
    }
}
