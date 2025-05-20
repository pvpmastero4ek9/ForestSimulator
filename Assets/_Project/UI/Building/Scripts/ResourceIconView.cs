using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Core.Wallets;
using Mono.Cecil;

namespace UI.Building
{
    public class ResourceIconView : MonoBehaviour
    {
        [SerializeField] private Image iconImage;
        [SerializeField] private TMP_Text amountText;

        public void Setup(ResourceType type, int amount)
        {
            // iconImage.sprite = ResourceIconDatabase.GetIcon(type); // ��������, ����� ScriptableObject ��� ������
            // amountText.text = amount.ToString();
        }
    }
}
