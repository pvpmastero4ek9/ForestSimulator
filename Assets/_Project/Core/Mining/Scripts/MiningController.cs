using UnityEngine;
using Core.Player;
using Data.Mining;
using System.Collections;

namespace Core.Mining
{
    public class MiningController : MonoBehaviour
    {
        [SerializeField] private CheckerResourceClick _checkerResourceClick;
        [SerializeField] private AutoMoveToResource _autoMoveToResource;
        [SerializeField] private AnimatorPlayer _animatorPlayer;
        private ResourceNode _resourceNode;

        private void OnEnable()
        {
            _checkerResourceClick.OnToolSelected += HandleMining;
            _animatorPlayer.HitedResource += ResourceExtraction;
        }

        private void OnDisable()
        {
            _checkerResourceClick.OnToolSelected -= HandleMining;
            _animatorPlayer.HitedResource -= ResourceExtraction;
        }

        private void HandleMining(Tool tool, ResourceNode resourceNode)
        {
            _resourceNode = resourceNode;
            _autoMoveToResource.MoveTo(resourceNode.GetPosition());
            StartCoroutine(MineSequence(tool));
        }

        private void ResourceExtraction()
        {
            _resourceNode.Mine();
            //Здесь можно сделать эффект потряхивания камня
        }

        private void StopMine()
        {
            _animatorPlayer.StopAllAnimationMining();
        }

        private IEnumerator MineSequence(Tool tool)
        {
            while (Vector3.Distance(_autoMoveToResource.GetPosition(), _resourceNode.GetPosition()) > 2f)
                yield return null;

            _autoMoveToResource.Stop();
            _animatorPlayer.PlayMiningStoneAnimation();

            while (_resourceNode.Durability > 0)
                yield return null;

            StopMine();
        }
    }
}