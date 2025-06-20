using System;
using System.Collections.Generic;
using Core.Wallets;
using UnityEngine;
using UnityEngine.Localization;

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
        public Buildings Building;
        public LocalizedString Name;
        public GameObject Prefab;
        public string Description;
        public List<ResourceCost> Costs = new List<ResourceCost>();
    }
}