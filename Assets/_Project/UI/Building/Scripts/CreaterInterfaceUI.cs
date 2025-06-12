using Core.Building;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Zenject;
using Data.Building;
using Core.Wallets;
using UI.Building;

namespace Ui.Building
{
    public class CreaterInterfaceUI : MonoBehaviour, IUIController
    {
        [SerializeField] private GameObject _interfacePrefab;
        [SerializeField] private Transform _parent;
        [SerializeField] private BuildingContainerForUI _buildingContainer;
        //[SerializeField] private GameObject resourceSlotPrefab;

        private DiContainer _container;
        private GameObject _currentInterface;
        private IBuildingData _buildingData;

        [Inject]
        public void Construct(DiContainer container, IBuildingData buildingData)
        {
            _container = container;
            _buildingData = buildingData;
        }

        public void CreateUI()
        {
            if (_currentInterface != null)
            {
                Destroy(_currentInterface);
            }

            _currentInterface = _container.InstantiatePrefab(_interfacePrefab, _parent);

            string buildingId = _buildingContainer.BuildingId;

            BuildingInfo buildingInfo = _buildingData.GetByName(buildingId);

            //Transform buildUIPanel = _currentInterface.transform.Find("BuildUIPanel");

            
            //TMP_Text titleText = buildUIPanel.Find("TitleText")?.GetComponent<TMP_Text>();
            //if (titleText != null)
            //{
                //titleText.text = buildingInfo.Name;
                //titleText.enabled = true; 
            //}

           
            //Transform resourceContainer = buildUIPanel.Find("ResourceContainer");
            
            //ClearAndUpdateResources(resourceContainer, buildingInfo);

            //Button buildButton = buildUIPanel.Find("Button")?.GetComponent<Button>();
            //if (buildButton != null)
            //{
                //ButtonStartBuild buttonScript = buildButton.GetComponent<ButtonStartBuild>();
                //if (buttonScript != null)
                //{
                    //buttonScript.SetBuildingName(buildingInfo.Name);
                //}
            //}
        }

        private void ClearAndUpdateResources(Transform resourceContainer, BuildingInfo buildingInfo)
        {
            foreach (Transform child in resourceContainer)
            {
                child.gameObject.SetActive(false);
            }

            if (buildingInfo.Costs == null || buildingInfo.Costs.Count == 0)
            {
                return; 
            }

            //for (int i = 0; i < buildingInfo.Costs.Count; i++)
            //{
                //Transform resourceSlot = i < resourceContainer.childCount ?
                    //resourceContainer.GetChild(i) : CreateResourceSlot(resourceContainer);

                //if (resourceSlot != null)
                //{
                    //resourceSlot.gameObject.SetActive(true);

                    //ResourceCost cost = buildingInfo.Costs[i];
                    //Image iconImage = resourceSlot.Find("ResourceIcon")?.GetComponent<Image>();
                    //TMP_Text amountText = resourceSlot.Find("ResourceAmount")?.GetComponent<TMP_Text>();

                    //if (iconImage != null && amountText != null)
                    //{
                        //Sprite resourceIcon = GetResourceIcon(cost.ResourceType);
                        //if (resourceIcon != null)
                        //{
                            //iconImage.sprite = resourceIcon;
                            //iconImage.preserveAspect = true;
                        //}
                        //amountText.text = cost.Amount.ToString();
                    //}
                //}
            //}
        }

        //private Transform CreateResourceSlot(Transform parent)
        //{
            //GameObject slot = Instantiate(resourceSlotPrefab, parent, false);
            //slot.name = $"ResourceSlot_{parent.childCount}";
            //return slot.transform;
        //}

        public void HideUI()
        {
            if (_currentInterface != null)
            {
                Destroy(_currentInterface);
                _currentInterface = null;
            }
        }

        private void OnDestroy()
        {
            if (_currentInterface != null)
            {
                Destroy(_currentInterface);
                _currentInterface = null;
            }
        }

        private Sprite GetResourceIcon(CurrencyType resourceType)
        {
            switch (resourceType)
            {
                case CurrencyType.wood:
                    return Resources.Load<Sprite>("Wood");
                case CurrencyType.stone:
                    return Resources.Load<Sprite>("Stone");
                case CurrencyType.branch:
                    return Resources.Load<Sprite>("Branch");
                default:
                    Debug.LogWarning("Icon not found for " + resourceType);
                    return null;
            }
        }
    }

}