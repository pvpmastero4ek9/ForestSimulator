using UnityEngine;
using UnityEngine.UI;

namespace UI.PlayerInventory
{
    public class InventoryContainerUI : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        public Image Icon
        {
            get => _icon;
            set => _icon = value;
        }
    }
}
