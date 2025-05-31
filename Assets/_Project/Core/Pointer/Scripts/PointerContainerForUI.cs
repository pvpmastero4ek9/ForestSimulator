using UnityEngine;

namespace Core.Pointer
{
    public class PointerContainerForUI : MonoBehaviour
    {
        public Transform Target { get; private set; }
        public Sprite SpriteIcon { get; private set; }
        public delegate void PosTransferredHandler(Transform target);
        public event PosTransferredHandler PosTransferred;

        public PointerContainerForUI Init(Transform target, Sprite iconObject)
        {
            Target = target;
            SpriteIcon = iconObject;

            PosTransferred?.Invoke(target);
            return this;
        }
    }
}
