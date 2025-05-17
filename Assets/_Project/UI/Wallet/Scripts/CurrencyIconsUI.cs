using UnityEngine;
using Data.Wallets;
using Core.Wallets;
using UnityEngine.UI;

namespace UI.Wallets
{
    public class CurrencyIconsUI : MonoBehaviour
    {
        [SerializeField] private Image _spriteRenderer;
        [SerializeField] private IconsCurrency _iconsCurrency;
        [SerializeField] private CurrencyType _currencyType;

        private void OnEnable()
        {
            if (!didStart)
            {
                UpdateIcon();
            }
        }

        private void UpdateIcon()
        {
            _spriteRenderer.sprite = _iconsCurrency.GetSprite(_currencyType);
        }
    }
}
