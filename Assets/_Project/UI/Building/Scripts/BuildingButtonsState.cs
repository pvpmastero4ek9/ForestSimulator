using AYellowpaper.SerializedCollections;
using Core.Building;
using Core.Wallets;
using UI.Common;
using UnityEngine;
using Zenject;

namespace UI.Building
{
    public class BuildingButtonsState : MonoBehaviour
    {
        [Inject] private Wallet _wallet;

        [SerializeField] private BuildingContainerForUI _buildingContainer;

        [SerializedDictionary("ButtonState", "Tab")]
        [SerializeField] private SerializedDictionary<StateButton, Tab> _tabsButtons;

        private InsufficientResourcesChecking _insufficientResourcesChecking = new();

        private void OnEnable()
        {
            _buildingContainer.Inited += ActivatedStateButton;
        }

        private void OnDisable()
        {
            _buildingContainer.Inited -= ActivatedStateButton;
        }

        private void ActivatedStateButton()
        {
            Tab State = _insufficientResourcesChecking.CheckCurrency(_buildingContainer.BuildingInfo.Costs, _wallet) ? _tabsButtons[StateButton.ActiveButton] : _tabsButtons[StateButton.NotActiveButton];
            State.Enable();
        }
    }

    public enum StateButton
    {
        ActiveButton,
        NotActiveButton
    }
}