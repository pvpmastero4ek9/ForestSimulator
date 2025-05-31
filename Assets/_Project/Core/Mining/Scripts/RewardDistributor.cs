using Core.Wallets;
using UnityEngine;
using Zenject;

namespace Core.Mining
{
    public class RewardDistributor : MonoBehaviour
    {
        [Inject] Wallet _wallet;

        public void GetReward(CurrencyType currencyType, int rewardValue)
        {
            _wallet.GetCurrency(currencyType).Value += rewardValue;
        }
    }
}
