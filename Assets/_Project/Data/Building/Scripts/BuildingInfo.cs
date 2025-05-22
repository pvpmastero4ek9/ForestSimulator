using System;
using UnityEngine;
using Core.Wallets;

namespace Data.Building
{
    [Serializable]
    public class ResourceCost
    {
        public CurrencyType Type;
        public int Amount;
    }

    [Serializable]
    public class BuildingInfo
    {
        public string Title;
        public string Description;
        public GameObject Prefab;
        public Sprite Icon;
        public BuildingState State;
        public int MaxHealth;
        public int CurrentHealth;
        public ResourceCost[] Cost;
    }
}
