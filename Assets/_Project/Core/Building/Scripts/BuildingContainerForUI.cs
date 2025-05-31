using UnityEngine;

namespace Core.Building
{
    public class BuildingContainerForUI : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private Sprite _spriteIcon;

        
        public Transform Target => _target;
        public Sprite SpriteIcon => _spriteIcon;
    }
}