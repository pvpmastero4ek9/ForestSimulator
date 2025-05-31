using UnityEngine;

namespace Core.Wallets
{
    public class WalletService : IWalletService
    {
        private readonly Wallet _wallet;

        public WalletService(Wallet wallet)
        {
            _wallet = wallet;
        }

        public bool HasEnough(CurrencyType type, int amount)
        {
            Currency currency = _wallet.GetCurrency(type);
            return currency.Value >= amount;
        }

        public void Spend(CurrencyType type, int amount)
        {
            Currency currency = _wallet.GetCurrency(type);
            currency.Value -= amount;
        }
    }
}