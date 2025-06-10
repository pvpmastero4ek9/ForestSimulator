using System.Collections;
using Core.Player;
using UnityEngine;
using Zenject;
using ListExtentions;

namespace Core.Fishing
{
    public class MovementToFishing : MonoBehaviour
    {
        private const float DistanceFishingRod = 2f;
        [Inject] InfoPlayer _infoPlayer;

        private AutoMove _autoMove => _infoPlayer.AutoMove;
        [SerializeField] private CheckerFishingClick _checkerFishingClick;
        [SerializeField] private Transform _targetTowards;
        private RotateTowardsTarget _rotateTowardsTarget = new();

        public delegate void EndedMoveHandler();
        public event EndedMoveHandler EndedMove;

        private void OnEnable()
        {
            _checkerFishingClick.OnToolSelected += MovePlayer;
        }

        private void OnDisable()
        {
            _checkerFishingClick.OnToolSelected -= MovePlayer;
        }

        private void MovePlayer(Vector3 positionTarget)
        {
            StopAllCoroutines(); // По другому?

            _autoMove.MoveTo(positionTarget);
            StartCoroutine(CheckStartingFishing(positionTarget));
        }

        private IEnumerator CheckStartingFishing(Vector3 positionTarget)
        {
            while (Vector3.Distance(_autoMove.GetPosition(), positionTarget) > DistanceFishingRod)
                yield return null;

            _autoMove.Stop();
            StartCoroutine(_rotateTowardsTarget.RotateTowards(_autoMove.gameObject.transform, _targetTowards));
            while (_rotateTowardsTarget.Rotate)
                yield return null;

            EndedMove?.Invoke();
        }
    }
}
