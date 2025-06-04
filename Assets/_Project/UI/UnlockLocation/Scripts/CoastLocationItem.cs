using Core.Wallets;
using Data.Wallets;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.UnlockLocations
{
    public class CoastLocationItem : MonoBehaviour
    {
        [SerializeField] private IconsCurrency _iconsCurrency;
        [SerializeField] private TMP_Text _textCoast;
        [SerializeField] private Image _iconResource;
        
        public CoastLocationItem Init(CurrencyType currencyType, int valueCoast)
        {
            _iconResource.sprite = _iconsCurrency.GetSprite(currencyType);
            _textCoast.text = valueCoast.ToString();

            return this;
        }
    }
}
