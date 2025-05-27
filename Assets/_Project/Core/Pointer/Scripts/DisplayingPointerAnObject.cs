using System;
using UnityEngine;
using Zenject;

namespace Core.Pointer
{
    public class DisplayingPointerAnObject : MonoBehaviour
    {
        [SerializeField] private Sprite _iconObject;
        [Inject] private CreaterPointer _createrPointer;

        public void CreatePointer()
        {
            _createrPointer.CreatePointer(transform, _iconObject);
        }
    }
}
