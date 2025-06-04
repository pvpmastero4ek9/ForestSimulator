using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using Core.UnlockLocations;
using Core.Wallets;
using UI.Common;
using UnityEngine;
using Zenject;

namespace UI.UnlockLocations
{
    public class ButtonsState : MonoBehaviour
    {
        [Inject] private Wallet _wallet;

        [SerializeField] private UnlockLocationContainerForUI _unlockLocationContainer;

        [SerializedDictionary("ButtonState", "Tab")]
        [SerializeField] private SerializedDictionary<StateButton, Tab> _tabsButtons;

        private InfoUnlockLocation _infoUnlockLocation => _unlockLocationContainer.InfoUnlockLocation;

        private void OnEnable()
        {
            _unlockLocationContainer.Inited += ActivatedStateButton;
        }

        private void OnDisable()
        {
            _unlockLocationContainer.Inited -= ActivatedStateButton;
        }

        private void ActivatedStateButton()
        {
            _tabsButtons[StateButton.ActiveButton].Enable();

            foreach (KeyValuePair<CurrencyType, int> pair in _infoUnlockLocation.CoastUnlockDictionary)
            {
                Currency currency = _wallet.GetCurrency(pair.Key);
                if (currency.Value < pair.Value)
                {
                    _tabsButtons[StateButton.NotActiveButton].Enable();
                    break;
                }
            }
        }
    }

    public enum StateButton
    {
        ActiveButton,
        NotActiveButton
    }
}
