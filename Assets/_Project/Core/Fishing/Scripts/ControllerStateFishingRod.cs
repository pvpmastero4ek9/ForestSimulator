using UnityEngine;

namespace Core.Fishing
{
    public class ControllerStateFishingRod : MonoBehaviour
    {
        [SerializeField] MovementToFishing _movementToFishing;

        private void OnEnable()
        {
            _movementToFishing.EndedMove += DisableFishingRod;
        }

        private void OnDisable()
        {
            _movementToFishing.EndedMove -= DisableFishingRod;
        }

        private void DisableFishingRod()
        {
            gameObject.SetActive(false);
        }

        private void EnableFishingRod()
        {
            gameObject.SetActive(true);
        }
    }
}
