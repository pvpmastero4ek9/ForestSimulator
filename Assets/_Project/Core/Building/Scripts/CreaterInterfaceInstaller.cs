using UnityEngine;
using Zenject;

namespace Core.Building
{
    public class CreaterInterfaceInstaller : MonoInstaller
    {
        [SerializeField] private CreaterInterfaceUI _createrInterfaceUI;
        public override void InstallBindings()
        {
            Container
                .Bind<CreaterInterfaceUI>()
                .FromInstance(_createrInterfaceUI)
                .AsSingle();
        }
    }
}
