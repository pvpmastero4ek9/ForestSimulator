using Core.Player;
using UnityEngine;
using Zenject;

namespace Core.Fishing
{
    public class EffectFishing : MonoBehaviour
    {
        [Inject] private InfoPlayer _infoPlayer;

        [SerializeField] private Transform _positionCreateEffect;
        [SerializeField] private GameObject _effect_PREFAB;
        private AnimatorPlayer _animatorPlayer => _infoPlayer.AnimatorPlayer;

        private void OnEnable()
        {
            _animatorPlayer.SwimedFallen += CreateEffect;
        }

        private void OnDisable()
        {
            _animatorPlayer.SwimedFallen -= CreateEffect;
        }

        private void CreateEffect()
        {
            GameObject particleInstance = Instantiate(_effect_PREFAB, _positionCreateEffect.position, Quaternion.identity);

            ParticleSystem ps = particleInstance.GetComponent<ParticleSystem>();

            Destroy(particleInstance, ps.main.duration + ps.main.startLifetime.constantMax);
        }
    }
}
