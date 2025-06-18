using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using Core.Building;
using Core.Wallets;
using Data.Building;
using UI.Common;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.Building
{
    public class BuildingButtonsState : MonoBehaviour
    {
        [Inject] private Wallet _wallet;
        [Inject] private IBuildingData _buildingData;

        [SerializeField] private Button _buildButton; // Ссылка на кнопку "Строить"

        [SerializeField] public BuildingContainerForUI _buildingContainer;

        [SerializedDictionary("ButtonState", "Tab")]
        [SerializeField] private SerializedDictionary<StateButton, Tab> _tabsButtons;

        private BuildingInfo _info => _buildingData?.GetByName(_buildingContainer?.BuildingId);

        private void Awake()
        {
            if (_buildButton == null)
            {
                _buildButton = GetComponentInChildren<Button>();
                if (_buildButton == null)
                {
                    Debug.LogError("Build button not found in BuildingButtonsState");
                }
            }
        }

        private void OnEnable()
        {
            if (_buildingContainer != null)
            {
                _buildingContainer.Inited += UpdateButtonState;
                UpdateButtonState(); // Вызов при активации
            }
        }

        private void OnDisable()
        {
            if (_buildingContainer != null)
            {
                _buildingContainer.Inited -= UpdateButtonState;
            }
        }

        private void UpdateButtonState()
        {
            if (_buildingContainer == null || string.IsNullOrEmpty(_buildingContainer.BuildingId) || _buildingData == null || _tabsButtons == null)
            {
                return;
            }

            BuildingInfo info = _info;
            if (info == null)
            {
                return;
            }

            bool hasEnoughResources = true;
            foreach (ResourceCost cost in info.Costs)
            {
                Currency currency = _wallet.GetCurrency(cost.ResourceType);
                if (currency == null || currency.Value < cost.Amount)
                {
                    hasEnoughResources = false;
                    break;
                }
            }

            if (_tabsButtons.ContainsKey(StateButton.ActiveButton) && _tabsButtons.ContainsKey(StateButton.NotActiveButton))
            {
                _tabsButtons[StateButton.ActiveButton].gameObject.SetActive(hasEnoughResources);
                _tabsButtons[StateButton.NotActiveButton].gameObject.SetActive(!hasEnoughResources);

                if (_buildButton != null)
                {
                    _buildButton.interactable = hasEnoughResources;
                    Debug.Log($"Build button set to interactable: {hasEnoughResources} for BuildingId: {_buildingContainer.BuildingId}");
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