using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using Core.Building;
using Core.Wallets;
using Data.Building;
using UI.Common;
using UnityEngine;
using Zenject;

namespace UI.Building
{
    public class BuildingButtonsState : MonoBehaviour
    {
        [Inject] private Wallet _wallet;

        [SerializeField] private BuildingData _buildingData;
        [SerializeField] private BuildingContainerForUI _buildingContainer;

        [SerializedDictionary("ButtonState", "Tab")]
        [SerializeField] private SerializedDictionary<StateButton, Tab> _tabsButtons;

        private BuildingInfo _info => _buildingData.GetByName(_buildingContainer.BuildingId);

        private void OnEnable()
        {
            ActivatedStateButton();
        }

        private void ActivatedStateButton()
        {
            if (_info == null)
            {
                Debug.LogWarning("BuildingInfo не найден по ID: " + _buildingContainer.BuildingId);
                return;
            }

            _tabsButtons[StateButton.ActiveButton].Enable();

            foreach (ResourceCost cost in _info.Costs)
            {
                Currency currency = _wallet.GetCurrency(cost.ResourceType);
                if (currency.Value < cost.Amount)
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
