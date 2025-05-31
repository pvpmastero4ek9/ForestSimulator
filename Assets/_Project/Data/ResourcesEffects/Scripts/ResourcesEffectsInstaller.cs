using UnityEngine;
using Zenject;

namespace Data.ResourcesEffect
{
    public class ResourcesEffectsInstaller : MonoInstaller
    {
        [SerializeField] private ResourcesEffects _resourcesEffectsData;

        public override void InstallBindings()
        {
            Container
                .Bind<ResourcesEffects>()
                .FromInstance(_resourcesEffectsData)
                .AsSingle();
        }
    }
}
