using UnityEngine;
using Core.Wallets;
using AYellowpaper.SerializedCollections;
using System.Collections.Generic;
using System.Linq;

namespace Data.Wallets
{
    [CreateAssetMenu(fileName = "IconsCurrency", menuName = "Wallet/Icons")]
    public class IconsCurrency : ScriptableObject
    {
        [SerializedDictionary("CurrencyType", "Icons")]
        [SerializeField] private SerializedDictionary<CurrencyType, Sprite> _iconsCurrencyList;

        public Dictionary<CurrencyType, Sprite> GetIconsCurrencyList => _iconsCurrencyList.ToDictionary(x => x.Key, y => y.Value);
        public Sprite GetSprite(CurrencyType currencyType)
        {
            return _iconsCurrencyList[currencyType];
        }
    }
}
