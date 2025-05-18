using System;
using System.Collections.Generic;
using UnityEngine;
using Core.Wallets;

[CreateAssetMenu(fileName = "DataBuilding", menuName = "Scriptable Objects/DataBuilding")]
public class DataBuilding : ScriptableObject
{
    [field: SerializeField] public string BuildingName { get; private set; }
    [field: SerializeField] public GameObject BuildingPrefab { get; private set; }
    [field: SerializeField] public List<ResourceCost> CostList { get; private set; }

    [Serializable]
    public class ResourceCost
    {
        public CurrencyType ResourceType;
        public int Amount;
    }
}
