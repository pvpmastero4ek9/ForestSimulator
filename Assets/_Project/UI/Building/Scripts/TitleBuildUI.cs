using Core.Building;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;

namespace Ui.Building
{
    public class TitleBuildUI : MonoBehaviour
    {
        [SerializeField] BuildingContainerForUI _buildingContainer;
        [SerializeField] private TMP_Text _textTitle;

        private void OnEnable()
        {
            _buildingContainer.Inited += ChangeNameTitle;
        }

        private void OnDisable()
        {
            _buildingContainer.Inited -= ChangeNameTitle;
        }

        private void ChangeNameTitle()
        {
            _textTitle.text = _buildingContainer.BuildingInfo.Name.GetLocalizedString();
        }
    }
}
