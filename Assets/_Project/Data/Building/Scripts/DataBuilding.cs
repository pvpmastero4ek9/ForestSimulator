using UnityEngine;
using System.Collections.Generic;
using Core.Wallets;

namespace Data.Building
{
    [CreateAssetMenu(menuName = "Building/Building Data")]
    public class DataBuilding : ScriptableObject
    {
        [field: SerializeField] public string Title { get; private set; }
        [field: SerializeField] public string Description { get; private set; }
        [field: SerializeField] public GameObject BuildingPrefab { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
        [field: SerializeField] public List<ResourceCost> Cost { get; private set; }
    }

    [System.Serializable]
    public class ResourceCost
    {
        public CurrencyType Type;
        public int Amount;
    }
}
