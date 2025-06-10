using System;
using UnityEngine;
using UnityEngine.AI;

namespace Core.Player
{
    public class AnimatorPlayer : MonoBehaviour
    {
        [SerializeField] private Animator _animatorPlayer;
        [SerializeField] private NavMeshAgent _agent;
        public event Action HitedResource;
        public event Action SwimedFallen;
        public event Action EndedFailOrSuccessFishing;

        private void Update()
        {
            if (!_agent.isStopped)
            {
                _animatorPlayer.SetFloat("MoveX", 0.5f);
            }
            else
            {
                _animatorPlayer.SetFloat("MoveX", Input.GetAxis("Horizontal")); 
                _animatorPlayer.SetFloat("MoveZ", Input.GetAxis("Vertical")); 
            }
        }

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

        public void IdleFishing()
        {
            _animatorPlayer.SetBool("FishingIdle", true);
        }

        public void IdleFishingStop()
        {
            _animatorPlayer.SetBool("FishingIdle", false);
        }

        public void EndFailOrSuccessFishing()
        {
            EndedFailOrSuccessFishing?.Invoke();
        }

        public void SwimFallen()
        {
            IdleFishing();
            SwimedFallen?.Invoke();
        }

        public void StopAllAnimationMining()
        {
            _animatorPlayer.SetBool("MiningTriggerStone", false);
            _animatorPlayer.SetBool("MiningTriggerWood", false);
            _animatorPlayer.SetBool("MiningTriggerBranch", false);
        }

        public void StartRun()
        {
            _animatorPlayer.SetTrigger("Run");
        }

        public void ResourceExtraction()
        {
            HitedResource?.Invoke();
        }
    }
}
