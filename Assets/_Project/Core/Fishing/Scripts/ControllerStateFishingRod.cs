using UnityEngine;
using Zenject;

namespace Core.Fishing
{
    public class ControllerStateFishingRod : MonoBehaviour
    {
        [Inject] GameFishing _gameFishing;
        [SerializeField] private MovementToFishing _movementToFishing;
        [SerializeField] private GameObject _fishingRod;

        private void OnEnable()
        {
            _movementToFishing.EndedMove += DisableFishingRod;
            _gameFishing.StopedFishing += EnableFishingRod;
        }

        private void OnDisable()
        {
            _movementToFishing.EndedMove -= DisableFishingRod;
            _gameFishing.StopedFishing -= EnableFishingRod;
        }

        private void DisableFishingRod()
        {
            _fishingRod.SetActive(false);
        }

        private void EnableFishingRod()
        {
            _fishingRod.SetActive(true);
        }
    }
}
