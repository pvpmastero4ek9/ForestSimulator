using Core.Player;
using UnityEngine;
using Zenject;

namespace Core.Fishing
{
    public class AnimatorFishing : MonoBehaviour
    {
        [Inject] InfoPlayer _infoPlayer;
        [Inject] GameFishing _gameFishing;

        [SerializeField] private MovementToFishing _movementToFishing;
        private AnimatorPlayer _animatorPlayer => _infoPlayer.AnimatorPlayer;

        private void OnEnable()
        {
            _movementToFishing.EndedMove += ActivateCastFishingrod;
            _animatorPlayer.EndedFailOrSuccessFishing += ActivateCastFishingrod;
            _gameFishing.OnFail += ActivateFailFishing;
            _gameFishing.OnSuccess += ActivateSuccessFishing;
        }

        private void OnDisable()
        {
            _movementToFishing.EndedMove -= ActivateCastFishingrod;
            _animatorPlayer.EndedFailOrSuccessFishing -= ActivateCastFishingrod;
            _gameFishing.OnFail -= ActivateFailFishing;
            _gameFishing.OnSuccess -= ActivateSuccessFishing;
        }

        private void ActivateCastFishingrod()
        {
            _animatorPlayer.CastFishingrod();
        }

        private void ActivateFailFishing()
        {
            _animatorPlayer.FailFishing();
        }

        private void ActivateSuccessFishing()
        {
            _animatorPlayer.SuccessFishing();
        }
    }
}
