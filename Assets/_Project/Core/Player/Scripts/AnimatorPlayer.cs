using System;
using UnityEngine;

namespace Core.Player
{
    public class AnimatorPlayer : MonoBehaviour
    {
        [SerializeField] private Animator _animatorPlayer;
        public event Action HitedResource;
        public event Action SwimedFallen;
        public event Action EndedFailOrSuccessFishing;

        public void PlayMiningStoneAnimation()
        {
            _animatorPlayer.SetBool("MiningTriggerStone", true);
        }

        public void PlayMiningWoodAnimation()
        {
            _animatorPlayer.SetBool("MiningTriggerWood", true);
        }

        public void PlayMiningBranchAnimation()
        {
            _animatorPlayer.SetBool("MiningTriggerBranch", true);
        }

        public void CastFishingrod()
        {
            _animatorPlayer.SetTrigger("FishingStart");
        }

        public void FailFishing()
        {
            _animatorPlayer.SetTrigger("FailFishing");
        }

        public void SuccessFishing()
        {
            _animatorPlayer.SetTrigger("SuccessFishing");
        }

        public void EndFailOrSuccessFishing()
        {
            EndedFailOrSuccessFishing?.Invoke();
        }

        public void SwimFallen()
        {
            SwimedFallen?.Invoke();
        }

        public void StopAllAnimationMining()
        {
            _animatorPlayer.SetBool("MiningTriggerStone", false);
            _animatorPlayer.SetBool("MiningTriggerWood", false);
            _animatorPlayer.SetBool("MiningTriggerBranch", false);
        }

        public void ResourceExtraction()
        {
            HitedResource?.Invoke();
        }
    }
}
