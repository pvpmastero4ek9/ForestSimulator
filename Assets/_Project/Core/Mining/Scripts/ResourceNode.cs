using Core.Wallets;
using UnityEngine;
using ListExtentions;
using System;

using UnityEngine.AI;

namespace Core.Mining
{
    public class ResourceNode : MonoBehaviour
    {
        [field: SerializeField] public CurrencyType CurrencyType { get; private set; }
        [field: SerializeField] public int RewardAmount { get; private set; }
        [field: SerializeField] private int _startDurability = 3;
        public event Action DestroyedResource;
        public event Action RecoveredResource;
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

            RecoveredResource?.Invoke();
        }

        public Vector3 GetPosition() => transform.position;
    }
}
