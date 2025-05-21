using System;
using UnityEngine;

namespace Core.Player
{
    public class AnimatorPlayer : MonoBehaviour
    {
        [SerializeField] private Animator _animatorPlayer;
        public delegate void HitedResourceHandler();
        public event HitedResourceHandler HitedResource;

        public void PlayMiningStoneAnimation()
        {
            _animatorPlayer.SetBool("MiningTriggerStone", true);
        }

        public void PlayMiningWoodAnimation()
        {
            _animatorPlayer.SetBool("MiningTriggerWood", true);

        }

        public void StopAllAnimationMining()
        {
            _animatorPlayer.SetBool("MiningTriggerStone", false);
            _animatorPlayer.SetBool("MiningTriggerWood", false);
        }

        public void ResourceExtraction()
        {
            HitedResource?.Invoke();
        }
    }
}
