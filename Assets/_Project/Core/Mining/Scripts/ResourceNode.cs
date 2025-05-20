using Core.Wallets;
using UnityEngine;

namespace Core.Mining
{
    public class ResourceNode : MonoBehaviour
    {
        [SerializeField] private CurrencyType _currencyType;
        [SerializeField] private int _rewardAmount;
        [SerializeField] private int _durability = 3;
        public delegate void DestroyedResourceHandler();
        public event DestroyedResourceHandler DestroyedResource;
        public bool CanBeMined { get; private set; } = true;
        public int Durability => _durability;

        public void Mine()
        {
            if (CanBeMined)
            {
                _durability--;
                if (_durability <= 0)
                {
                    DestroyedResource?.Invoke();
                    gameObject.SetActive(false);
                    CanBeMined = false;
                }
            }
        }

        public Vector3 GetPosition() => transform.position;
    }
}
