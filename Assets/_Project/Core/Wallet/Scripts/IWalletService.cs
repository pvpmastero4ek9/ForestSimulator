using UnityEngine;

namespace Core.Wallets
{
    public interface IWalletService
    {
        bool HasEnough(CurrencyType type, int amount);
        void Spend(CurrencyType type, int amount);
    }

}
