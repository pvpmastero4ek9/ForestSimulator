using System;
using UnityEngine;
using AYellowpaper.SerializedCollections;
using Core.Wallets;

namespace Core.UnlockLocations
{
    [Serializable]
    public class InfoUnlockLocation
    {
        [SerializedDictionary("CurrencyType", "Count")]
        public SerializedDictionary<CurrencyType, int> CoastUnlockDictionary;
    }
}
