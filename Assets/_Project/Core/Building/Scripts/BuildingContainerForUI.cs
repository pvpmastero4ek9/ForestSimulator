using UnityEngine;

namespace Core.Building
{
    public class BuildingContainerForUI : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Sprite spriteIcon;

        public Transform Target => target;
        public Sprite SpriteIcon => spriteIcon;

        public delegate void PostTransferHandler(Transform target);
        public event PostTransferHandler PostTransferred;

        private void Start()
        {
            PostTransferred?.Invoke(target);
        }
    }
}