using Core.Wallets;
using UnityEngine;
using Zenject;
using Data.ResourcesEffect;

namespace Core.Mining
{
    public class CreaterEffects : MonoBehaviour
    {
        [Inject] private ResourcesEffects _resourcesEffects;
        public void CreateEffect(Vector3 position, CurrencyType currencyType)
        {
            GameObject effect_PREFAB = _resourcesEffects.GetResourceEffectObj(currencyType);
            if (effect_PREFAB == null) return;

            GameObject particleInstance = Instantiate(effect_PREFAB, position, Quaternion.identity);

            ParticleSystem ps = particleInstance.GetComponent<ParticleSystem>();

            Destroy(particleInstance, ps.main.duration + ps.main.startLifetime.constantMax);
        }
    }
}
