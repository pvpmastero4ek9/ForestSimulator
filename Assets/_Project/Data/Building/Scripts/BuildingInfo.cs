using System;
using System.Collections.Generic;
using Core.Wallets;
using UnityEngine;

namespace Data.Building
{
    [Serializable]
    public class ResourceCost
    {
        public CurrencyType ResourceType;
        public int Amount;
    }

    [Serializable]
    public class BuildingInfo
    {
        public string Name;
        public GameObject Prefab;
        public string Description;
        public string Reward;
        public BuildingState State;
        public int Health;
        public List<ResourceCost> Costs = new List<ResourceCost>();
    }
}