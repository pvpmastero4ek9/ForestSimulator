using UnityEngine;
using Zenject;
using Core.Player;
using Core.Wallets;

namespace Core.Mining
{
    public class MiningAnimator : MonoBehaviour
    {
        [Inject] private InfoPlayer _infoPlayer;

        [SerializeField] private MiningController _miningController;
        private AnimatorPlayer _animatorPlayer => _infoPlayer.AnimatorPlayer;

        private void OnEnable()
        {
            _miningController.HandledMining += OnStartAnimation;
        }

        private void OnDisable()
        {
            _miningController.HandledMining -= OnStartAnimation;
        }

        private void OnStartAnimation() => PlayAnimation(_miningController.ResourceNode.CurrencyType);

        public void PlayAnimation(CurrencyType currencyType)
        {
            if (currencyType == CurrencyType.stone)
            {
                _animatorPlayer.PlayMiningStoneAnimation();
            }
            else if (currencyType == CurrencyType.wood)
            {
                _animatorPlayer.PlayMiningWoodAnimation();
            }
            else if (currencyType == CurrencyType.branch)
            {
                _animatorPlayer.PlayMiningBranchAnimation();
            }
        }
    }
}
