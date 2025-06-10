using System.Collections;
using Core.Player;
using UnityEngine;
using Zenject;
using ListExtentions;

namespace Core.Mining
{
    public class PreperMining : MonoBehaviour
    {
        private const float DistanceResource = 1.8f;
        [Inject] private InfoPlayer _infoPlayer;

        [SerializeField] private CheckerResourceClick _checkerResourceClick;
        [SerializeField] private MiningController _miningController;

        private RotateTowardsTarget _rotateTowardsTarget = new();
        private AutoMove _autoMoveToResource => _infoPlayer.AutoMove;
        private ResourceNode _resourceNode;

        private void OnEnable()
        {
            _checkerResourceClick.OnToolSelected += PrepForMining;
        }

        private void OnDisable()
        {
            _checkerResourceClick.OnToolSelected -= PrepForMining;
        }

        private void PrepForMining(ResourceNode resourceNode)
        {
            _resourceNode = resourceNode;

            _autoMoveToResource.MoveTo(resourceNode.GetPosition());
            StartCoroutine(WaitingPlayer());
        }

        private IEnumerator WaitingPlayer()
        {
            while (Vector3.Distance(_autoMoveToResource.GetPosition(), _resourceNode.GetPosition()) > DistanceResource)
                yield return null;

            _autoMoveToResource.Stop();
            StartCoroutine(RotatePlayer());
        }

        private IEnumerator RotatePlayer()
        {
            StartCoroutine(_rotateTowardsTarget.RotateTowards(_autoMoveToResource.transform, _resourceNode.transform));
            while (_rotateTowardsTarget.Rotate)
                yield return null;

            StartMining();
        }

        private void StartMining()
        {
            _miningController.HandleMining(_resourceNode);
        }
    }
}
