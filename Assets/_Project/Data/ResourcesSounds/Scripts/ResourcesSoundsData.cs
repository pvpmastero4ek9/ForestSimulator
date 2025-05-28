using UnityEngine;
using Core.Wallets;
using AYellowpaper.SerializedCollections;
using System.Collections.Generic;

namespace Data.ResourcesSounds
{
    [CreateAssetMenu(fileName = "ResourcesSoundsData", menuName = "ResourcesSounds/ResourcesSoundsData")]
    public class ResourcesSoundsData : ScriptableObject
    {
        [SerializedDictionary("CurrencyType", "Sounds")]
        [SerializeField] private SerializedDictionary<CurrencyType, List<AudioClip>> ResourcesSoundsDictionary;

        public AudioClip GetResourceRandomSound(CurrencyType currencyType)
        {
            return ResourcesSoundsDictionary[currencyType][Random.Range(0, ResourcesSoundsDictionary[currencyType].Count)];
        }
    }
}
