using System;
using Core.Wallets;
using UnityEngine;
using Zenject;

namespace Core.Fishing
{
    public class RewardDistributorFishing : MonoBehaviour
    {
        [Inject] private Wallet _wallet;
        [SerializeField] private int _countFishReward = 1;

        public void GetCurrency(float speed)
        {
            _wallet.GetCurrency(CurrencyType.fish).Value += (int)Math.Round(speed, MidpointRounding.AwayFromZero) * _countFishReward;
        }
    }
}
