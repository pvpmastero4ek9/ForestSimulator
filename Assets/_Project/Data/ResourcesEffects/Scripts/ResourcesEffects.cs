using UnityEngine;
using Core.Wallets;
using AYellowpaper.SerializedCollections;
using System.Collections.Generic;

namespace Data.ResourcesEffect
{
    [CreateAssetMenu(fileName = "ResourcesEffectsData", menuName = "ResourcesEffects/ResourcesEffectsData")]
    public class ResourcesEffects : ScriptableObject
    {
        [SerializedDictionary("CurrencyType", "Effect")]
        [SerializeField] private SerializedDictionary<CurrencyType, GameObject> ResourcesEffectsDictionary;

        public GameObject GetResourceEffectObj(CurrencyType currencyType)
        {
            return ResourcesEffectsDictionary[currencyType];
        }
    }
}
