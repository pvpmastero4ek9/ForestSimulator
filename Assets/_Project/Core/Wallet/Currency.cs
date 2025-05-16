using Unity.VisualScripting.YamlDotNet.Core.Tokens;
using UnityEngine;

namespace Core.Wallets
{
    public class Currency
    {
        private int _value;
        public CurrencyType CurrencyType { get; private set; }
        public int Value
        {
            get => _value;
            set
            {
                if (value < 0)
                {
                    Debug.LogError($"{this} cannot be lesser then zero!");
                }
                _value = (int)Mathf.Clamp(value, 0, Mathf.Infinity);
            }
        }

        public Currency(int value, CurrencyType currencyType)
        {
            Value = value;
            CurrencyType = currencyType;
        }
    }
}
