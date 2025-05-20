using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Core.Building;
using Data.Building;

namespace UI.Building
{
    public class BuildingInfoPanelView : MonoBehaviour
    {
        [SerializeField] private TMP_Text nameText;
        [SerializeField] private TMP_Text descriptionText;
        [SerializeField] private Transform resourceListParent;
        [SerializeField] private GameObject resourceIconPrefab;
        [SerializeField] private Button buildButton;

        public void Show(DataBuilding data)
        {
            nameText.text = data.Title;
            descriptionText.text = data.Description;

            foreach (Transform child in resourceListParent)
                Destroy(child.gameObject);

            foreach (ResourceCost cost in data.Cost)
            {
                var icon = Instantiate(resourceIconPrefab, resourceListParent);
                // icon.GetComponent<ResourceIconView>().Setup(cost.Type, cost.Amount);
            }

            // buildButton.interactable = data.CanBuild;
        }
    }
}
