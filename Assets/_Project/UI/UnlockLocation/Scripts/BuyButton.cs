using System.Collections.Generic;
using Core.UnlockLocations;
using Core.Wallets;
using UI.Common;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.UnlockLocations
{
    public class BuyButton : MonoBehaviour
    {
        [Inject] private Wallet _wallet;

        [SerializeField] private Button _button;
        [SerializeField] private UnlockLocationContainerForUI _unlockLocationContainer;
        [SerializeField] private CloseButton _closeButton;
        private InfoUnlockLocation _infoUnlockLocation => _unlockLocationContainer.InfoUnlockLocation;

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
            CurrencyCalculator();

            _unlockLocationContainer.FunctionCreateLocation?.Invoke();
            _closeButton.CloseObject();
        }

        private void CurrencyCalculator()
        {
            foreach (KeyValuePair<CurrencyType, int> pair in _infoUnlockLocation.CoastUnlockDictionary)
            {
                Currency currency = _wallet.GetCurrency(pair.Key);
                currency.Value -= pair.Value;
            }
        }
    }
}
