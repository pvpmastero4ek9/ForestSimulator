using Core.Wallets;
using UnityEngine;
using ListExtentions;
using System;

namespace Core.Mining
{
    public class ResourceNode : MonoBehaviour
    {
        [field: SerializeField] public CurrencyType CurrencyType { get; private set; }
        [field: SerializeField] public int RewardAmount { get; private set; }
        [field: SerializeField] private int _startDurability = 3;
        public delegate void DestroyedResourceHandler();
        public event DestroyedResourceHandler DestroyedResource;
        public bool CanBeMined { get; private set; } = true;
        public int Durability { get; private set; }

        [field: SerializeField] private float RecoveryTimeMinutes = 1;
        public CountdownTimer CountdownTimer { get; private set; } = new();


        public void Mine()
        {
            if (CanBeMined)
            {
                Durability++;
                if (Durability >= _startDurability)
                {
                    DestroyedResource?.Invoke();
                    gameObject.SetActive(false);
                    CanBeMined = false;

                    Durability = 0;
                    StartTimer();
                }
            }
        }

        public async void StartTimer()
        {
            DateTime dateTime = DateTime.Now + TimeSpan.FromMinutes(RecoveryTimeMinutes);
            await CountdownTimer.WaitUntil(dateTime, Recovery);
        }

        public void Recovery()
        {
            gameObject.SetActive(true);
            CanBeMined = true;
        }

        public Vector3 GetPosition() => transform.position;
    }
}
