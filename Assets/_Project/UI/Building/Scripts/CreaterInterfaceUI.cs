using Core.Building;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Zenject;
using Data.Building;
using Core.Wallets;

namespace Ui.Building
{
    public class CreaterInterfaceUI : MonoBehaviour, IUIController
    {
        [SerializeField] private GameObject _interfacePrefab;
        [SerializeField] private Transform _parent;
        [SerializeField] private BuildingContainerForUI _buildingContainer;

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
            if (_currentInterface == null)
            {
                Debug.LogError("Failed to instantiate _interfacePrefab!");
                return;
            }

            // Добавляем Vertical Layout Group на _currentInterface
            VerticalLayoutGroup vLayout = _currentInterface.AddComponent<VerticalLayoutGroup>();
            vLayout.padding = new RectOffset(10, 10, 10, 10);
            vLayout.spacing = 10f;
            vLayout.childAlignment = TextAnchor.UpperCenter;
            vLayout.childControlHeight = true;
            vLayout.childControlWidth = true;
            vLayout.childForceExpandHeight = false;
            vLayout.childForceExpandWidth = true;

            // Добавляем фоновое изображение
            Image background = _currentInterface.AddComponent<Image>();
            background.color = new Color(0.2f, 0.2f, 0.2f, 0.8f);

            if (_buildingContainer == null)
            {
                Debug.LogWarning("BuildingContainer is null!");
                return;
            }
            if (_buildingData == null)
            {
                Debug.LogWarning("BuildingData is null!");
                return;
            }

            string buildingId = _buildingContainer.BuildingId;
            Debug.Log($"Attempting to get BuildingInfo for: {buildingId}");

            BuildingInfo buildingInfo = _buildingData.GetByName(buildingId);
            if (buildingInfo == null)
            {
                Debug.LogWarning($"BuildingInfo not found for {buildingId}");
                return;
            }

            // Создаем текстовое поле для названия
            GameObject titleObject = new GameObject("Title");
            titleObject.transform.SetParent(_currentInterface.transform, false);
            TMP_Text titleText = titleObject.AddComponent<TMP_Text>();
            titleText.text = buildingInfo.Name; // Название берётся из BuildingInfo
            titleText.fontSize = 24;
            titleText.alignment = TextAlignmentOptions.Center;
            titleText.color = Color.white;

            // Проверяем Costs
            if (buildingInfo.Costs == null)
            {
                Debug.LogWarning($"Costs is null for building {buildingId}");
                return;
            }

            // Создаем элементы для каждого ресурса
            foreach (var cost in buildingInfo.Costs)
            {
                if (cost == null)
                {
                    Debug.LogWarning($"Found null cost in building {buildingInfo.Name}");
                    continue;
                }

                GameObject resourceItem = new GameObject("ResourceItem");
                resourceItem.transform.SetParent(_currentInterface.transform, false);

                HorizontalLayoutGroup hLayout = resourceItem.AddComponent<HorizontalLayoutGroup>();
                hLayout.childAlignment = TextAnchor.MiddleLeft;
                hLayout.spacing = 5f;
                hLayout.padding = new RectOffset(5, 5, 5, 5);
                hLayout.childControlWidth = true;
                hLayout.childControlHeight = true;
                hLayout.childForceExpandWidth = false;
                hLayout.childForceExpandHeight = false;

                // Иконка ресурса
                GameObject iconObject = new GameObject("Icon");
                iconObject.transform.SetParent(resourceItem.transform, false);
                Image iconImage = iconObject.AddComponent<Image>();
                Sprite resourceIcon = GetResourceIcon(cost.ResourceType);
                if (resourceIcon != null)
                {
                    iconImage.sprite = resourceIcon;
                    iconImage.preserveAspect = true;
                    iconImage.rectTransform.sizeDelta = new Vector2(30, 30);
                }

                // Текст количества
                GameObject amountObject = new GameObject("Amount");
                amountObject.transform.SetParent(resourceItem.transform, false);
                TMP_Text amountText = amountObject.AddComponent<TMP_Text>();
                amountText.text = cost.Amount.ToString();
                amountText.fontSize = 18;
                amountText.alignment = TextAlignmentOptions.MidlineLeft;
                amountText.color = Color.white;
            }
        }

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
                default:
                    Debug.LogWarning("Icon not found for " + resourceType);
                    return null;
            }
        }
    }
}