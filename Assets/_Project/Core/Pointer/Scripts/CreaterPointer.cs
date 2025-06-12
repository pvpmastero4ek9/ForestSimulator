using System;
using UnityEngine;

namespace Core.Pointer
{
    public class CreaterPointer : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private PointerContainerForUI Pointer_PREFAB;

        public GameObject CreatePointer(Transform target, Sprite sprite)
        {
            PointerContainerForUI pointer = Instantiate(Pointer_PREFAB, _canvas.transform).Init(target, sprite);
            return pointer.gameObject;
        }
    }
}
