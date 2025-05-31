using UnityEngine;
using Zenject;

namespace Data.ResourcesSounds
{
    public class ResourcesSoundsInstaller : MonoInstaller
    {
        [SerializeField] private ResourcesSoundsData _resourcesSoundsData;
        public override void InstallBindings()
        {
            Container
                .Bind<ResourcesSoundsData>()
                .FromInstance(_resourcesSoundsData)
                .AsSingle();
        }
    }
}
