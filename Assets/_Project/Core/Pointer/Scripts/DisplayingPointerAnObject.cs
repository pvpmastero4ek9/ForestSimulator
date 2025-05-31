using UnityEngine;
using Zenject;

namespace Core.Pointer
{
    public class DisplayingPointerAnObject : MonoBehaviour
    {
        [SerializeField] private Sprite _iconObject;
        [Inject] private CreaterPointer _createrPointer;

        void Start()
        {
            _createrPointer.CreatePointer(transform, _iconObject);
        }
    }
}
