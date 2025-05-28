using UnityEngine;
using Core.Player;
using Data.Mining;
using System.Collections;

namespace Core.Mining
{
    public class MiningController : MonoBehaviour
    {
        private const float DistanceResource = 1.5f;
        [SerializeField] private CheckerResourceClick _checkerResourceClick;
        [SerializeField] private AutoMove _autoMoveToResource;
        [SerializeField] private AnimatorPlayer _animatorPlayer;
        [SerializeField] private RewardDistributor _rewardDistributor;
        [SerializeField] private CreaterSounds _createrSounds;
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

        private void HandleMining(ResourceNode resourceNode)
        {
            _resourceNode = resourceNode;
            StopAllCoroutines();

            _autoMoveToResource.MoveTo(resourceNode.GetPosition());
            StartCoroutine(MineSequence());
        }

        private void ResourceExtraction()
        {
            _resourceNode.Mine();
            _createrSounds.CreateSound(_resourceNode.CurrencyType, _resourceNode.GetPosition());
            //Здесь можно сделать эффект потряхивания камня
        }

        private void StopMine()
        {
            _animatorPlayer.StopAllAnimationMining();
            _rewardDistributor.GetReward(_resourceNode.CurrencyType, _resourceNode.RewardAmount);
        }

        private IEnumerator MineSequence()
        {
            while (Vector3.Distance(_autoMoveToResource.GetPosition(), _resourceNode.GetPosition()) > DistanceResource)
                yield return null;

            _autoMoveToResource.Stop();
            PlayAnimation();

            while (_resourceNode.Durability > 0)
                yield return null;

            StopMine();
        }

        private void PlayAnimation()
        {
            if (_resourceNode.CurrencyType == Wallets.CurrencyType.stone)
            {
                _animatorPlayer.PlayMiningStoneAnimation();
            }
            else if (_resourceNode.CurrencyType == Wallets.CurrencyType.wood)
            {
                _animatorPlayer.PlayMiningWoodAnimation();
            }
            else if (_resourceNode.CurrencyType == Wallets.CurrencyType.branch)
            {
                _animatorPlayer.PlayMiningBranchAnimation();
            }
        }
    }
}