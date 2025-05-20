using UnityEngine;
using UnityEngine.UI;
using Data.Building;
using TMPro;
using Core.Building;
using UnityEngine.UIElements;

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
            nameText.text = data.BuildingName;
            descriptionText.text = data.Description;

            foreach (Transform child in resourceListParent)
                Destroy(child.gameObject);

            foreach (var cost in data.Costs)
            {
                var icon = Instantiate(resourceIconPrefab, resourceListParent);
                icon.GetComponent<ResourceIconView>().Setup(cost.Type, cost.Amount);
            }

            buildButton.interactable = data.CanBuild;
        }
    }
}
