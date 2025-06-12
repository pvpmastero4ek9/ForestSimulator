using System;
using UnityEngine;
using Zenject;

namespace Core.Pointer
{
    public class DisplayingPointerAnObject : MonoBehaviour
    {
        [SerializeField] private Sprite _iconObject;
        [Inject] private CreaterPointer _createrPointer;
        private GameObject _pointer;

        public void CreatePointer()
        {
            _pointer = _createrPointer.CreatePointer(transform, _iconObject);
        }

        public void DelitePointer()
        {
            Destroy(_pointer);
        }
    }
}
