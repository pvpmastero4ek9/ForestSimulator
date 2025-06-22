using Core.Pointer;
using UnityEngine;

namespace Core.Fishing
{
    public class PointerTutorial : MonoBehaviour
    {
        [SerializeField] private DisplayingPointerAnObject _displayingPointerAnObject;
        [SerializeField] private MovementToFishing _movementToFishing;

        private void OnEnable()
        {
            _displayingPointerAnObject.CreatePointer();
            _movementToFishing.EndedMove += DestoyObject;
        }

        private void OnDisable()
        {
            _movementToFishing.EndedMove -= DestoyObject;
        }

        private void DestoyObject()
        {
            _displayingPointerAnObject.DelitePointer();
            Destroy(this);
        }
    }
}
