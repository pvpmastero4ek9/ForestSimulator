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
        [field: SerializeField] public int Durability { get; private set; } = 3;
        public delegate void DestroyedResourceHandler();
        public event DestroyedResourceHandler DestroyedResource;
        public bool CanBeMined { get; private set; } = true;

        [field: SerializeField] private float RecoveryTimeMinutes = 1;
        private BoxCollider _boxCollider;
        public CountdownTimer CountdownTimer { get; private set; } = new();

        private void Start()
        {
            _boxCollider = GetComponent<BoxCollider>();
        }

        public void Mine()
        {
            if (CanBeMined)
            {
                Durability--;
                if (Durability <= 0)
                {
                    DestroyedResource?.Invoke();
                    gameObject.SetActive(false);
                    _boxCollider.isTrigger = true;
                    CanBeMined = false;

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
            _boxCollider.isTrigger = false;
            CanBeMined = true;
        }

        public Vector3 GetPosition() => transform.position;
    }
}
