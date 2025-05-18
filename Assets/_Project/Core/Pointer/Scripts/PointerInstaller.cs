using UnityEngine;
using Zenject;

namespace Core.Pointer
{
    public class PointerInstaller : MonoInstaller
    {
        [field: SerializeField] public CreaterPointer CreaterPointer { get; private set; } 
        public override void InstallBindings()
        {
            Container
                .Bind<CreaterPointer>()
                .FromInstance(CreaterPointer)
                .AsSingle();
        }
    }
}
