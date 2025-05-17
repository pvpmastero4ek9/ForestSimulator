using UnityEngine;
using Zenject;
using Core.Wallets;
using TMPro;

namespace UI.Wallets
{
    public class CurrencyCount: MonoBehaviour
    {
        [SerializeField] private CurrencyType _currencyType;
        [SerializeField] private TMP_Text _text;
        [Inject] private Wallet _wallet;
        private Currency _currency => _wallet.GetCurrency(_currencyType);

        private void OnEnable()
        {
            if (didStart)
            {
                UpdateInformation();
            }
            _currency.ChangedValue += UpdateInformation;
        }

        private void OnDisable()
        {
            _currency.ChangedValue -= UpdateInformation;
        }

        private void UpdateInformation()
        {
            _text.text = _currency.Value.ToString();
        }
    }
}
