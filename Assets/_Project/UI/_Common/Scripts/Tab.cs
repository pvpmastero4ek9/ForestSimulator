using UnityEngine;
using UnityEngine.Events;

namespace UI.Common
{
    public class Tab : MonoBehaviour
    {
        public delegate void DisabledListener();

        [SerializeField] private UnityEvent _enabled;

        public event UnityAction Enabled
        {
            add => _enabled.AddListener(value);
            remove => _enabled.RemoveListener(value);
        }

        public event DisabledListener Disabled;

        public void Enable()
        {
            if (gameObject.activeSelf)
            {
                return;
            }

            DisableAllOtherTabs();
            gameObject.SetActive(true);
        }

        public void OnEnable()
        {
            _enabled.Invoke();
        }

        public void OnDisable()
        {
            Disabled?.Invoke();
        }

        private void DisableAllOtherTabs()
        {
            foreach (Transform child in transform.parent)
            {
                child.gameObject.SetActive(false);
            }
        }
    }
}
