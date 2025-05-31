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
            if (!didStart)
            {
                _currency.ChangedValue += UpdateInformation;
                UpdateInformation();
            }
        }

        private void UpdateInformation()
        {
            if (_currency.Value == 0)
            {
                gameObject.SetActive(false);
            }
            else
            {
                gameObject.SetActive(true);
            }

            _text.text = _currency.Value.ToString();
        }
    }
}
