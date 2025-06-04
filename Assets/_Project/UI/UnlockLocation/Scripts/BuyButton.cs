using Core.UnlockLocations;
using UI.Common;
using UnityEngine;
using UnityEngine.UI;

namespace UI.UnlockLocations
{
    public class BuyButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private UnlockLocationContainerForUI _unlockLocationContainer;
        [SerializeField] private CloseButton _closeButton;

        private void OnEnable()
        {
            _button.onClick.AddListener(CreateLocation);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(CreateLocation);
        }

        private void CreateLocation()
        {
            _unlockLocationContainer.FunctionCreateLocation?.Invoke();
            _closeButton.CloseObject();
        }
    }
}
