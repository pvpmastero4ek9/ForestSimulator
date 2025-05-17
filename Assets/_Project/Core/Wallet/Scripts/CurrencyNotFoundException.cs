using System;

namespace Core.Wallets
{
    public class CurrencyNotFoundException : Exception
    {
        internal CurrencyNotFoundException(string message) : base(message) { }
        internal CurrencyNotFoundException() { }
    }
}
