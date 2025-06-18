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

        [SerializeField] private GameObject _containerForUIObject;
        private BuildingContainerForUI _buildingContainer;

        [SerializedDictionary("ButtonState", "Tab")]
        [SerializeField] private SerializedDictionary<StateButton, Tab> _tabsButtons;

        private BuildingInfo _info => _buildingData.GetByName(_buildingContainer.BuildingId);

        private void OnEnable()
        {
            _buildingContainer = _containerForUIObject.GetComponent<BuildingContainerForUI>();
            if (_buildingContainer != null)
            {
                _buildingContainer.Inited += UpdateButtonState;
                UpdateButtonState();
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
            if (_buildingContainer != null && _buildingData != null && _tabsButtons != null)
            {
                BuildingInfo info = _info;
                if (info != null)
                {
                    Button buildButton = GetComponentInChildren<Button>();
                    if (buildButton != null)
                    {
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
                            buildButton.interactable = hasEnoughResources;
                        }
                    }
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