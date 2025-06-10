using UnityEngine;
using Core.Player;
using System.Collections;
using Zenject;
using System;

namespace Core.Mining
{
    public class MiningController : MonoBehaviour
    {
        [Inject] private InfoPlayer _infoPlayer;
        private AnimatorPlayer _animatorPlayer => _infoPlayer.AnimatorPlayer;
        private AutoMove _autoMoveToResource => _infoPlayer.AutoMove;

        [SerializeField] private RewardDistributor _rewardDistributor;
        [SerializeField] private CreaterSounds _createrSounds;
        [SerializeField] private CreaterEffects _createrEffects;
        public ResourceNode ResourceNode { get; private set; }

        public event Action HandledMining;

        private void OnEnable()
        {
            _autoMoveToResource.StopedAgent += StopMine;
            _animatorPlayer.HitedResource += ResourceExtraction;
        }

        private void OnDisable()
        {
            _autoMoveToResource.StopedAgent -= StopMine;
            _animatorPlayer.HitedResource -= ResourceExtraction;
        }

        public void HandleMining(ResourceNode resourceNode)
        {
            ResourceNode = resourceNode;
            StopAllCoroutines();

            StartCoroutine(WaitMined());
            HandledMining?.Invoke();
        }

        private void ResourceExtraction()
        {
            ResourceNode.Mine();
            _createrSounds.CreateSound(ResourceNode.CurrencyType, ResourceNode.GetPosition());
            _createrEffects.CreateEffect(ResourceNode.GetPosition(), ResourceNode.CurrencyType);
            //Здесь можно сделать эффект потряхивания камня
        }

        private void StopMine()
        {
            StopAllCoroutines();

            _animatorPlayer.StopAllAnimationMining();

            if (ResourceNode == null) return;
            if (!CheckResourceNodeCanBeMined())
            {
                _createrSounds.CreateSoundBreaking(ResourceNode.CurrencyType, ResourceNode.GetPosition());
                _rewardDistributor.GetReward(ResourceNode.CurrencyType, ResourceNode.RewardAmount);

                ResourceNode = null;
            }
        }

        private bool CheckResourceNodeCanBeMined()
        {
            return ResourceNode.CanBeMined;
        }

        private IEnumerator WaitMined()
        {
            while (ResourceNode.CanBeMined)
                yield return null;

            StopMine();
        }
    }
}