using System;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Wallets
{
    public class Wallet : MonoBehaviour
    {
        public Dictionary<CurrencyType, Currency> _currencys = new();

        public Wallet()
        {
            foreach (CurrencyType currencyType in Enum.GetValues(typeof(CurrencyType)))
            {
                _currencys.Add(currencyType, new(0, currencyType));
            }
        }

        public Currency GetCurrency(CurrencyType currencyType)
        {
            if (_currencys.TryGetValue(currencyType, out Currency result))
            {
                return result;
            }
            throw new CurrencyNotFoundException();
        }
    }
}
