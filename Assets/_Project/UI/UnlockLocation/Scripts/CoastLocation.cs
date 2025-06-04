using UnityEngine;
using Core.UnlockLocations;
using Core.Wallets;
using System.Collections.Generic;

namespace UI.UnlockLocations
{
    public class CoastLocation : MonoBehaviour
    {
        [SerializeField] private UnlockLocationContainerForUI _unlockLocationContainer;
        [SerializeField] private CoastLocationItem CoastLocationItem_PREFAB;
        private InfoUnlockLocation _infoUnlockLocation => _unlockLocationContainer.InfoUnlockLocation;

        private void OnEnable()
        {
            _unlockLocationContainer.Inited += CreateCoastsItem;
        }

        private void OnDisable()
        {
            _unlockLocationContainer.Inited -= CreateCoastsItem;
        }

        private void CreateCoastsItem()
        {
            foreach (KeyValuePair<CurrencyType, int> pair in _infoUnlockLocation.CoastUnlockDictionary)
            {
                Instantiate(CoastLocationItem_PREFAB, gameObject.transform).Init(pair.Key, pair.Value);
            }
        }
    }
}
