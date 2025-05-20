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
            _animatorPlayer.SetTrigger("MiningTrigger");
        }

        public void StopAllAnimationMining()
        {
            _animatorPlayer.SetTrigger("MiningTrigger");
        }

        public void ResourceExtraction()
        {
            HitedResource?.Invoke();
        }
    }
}
