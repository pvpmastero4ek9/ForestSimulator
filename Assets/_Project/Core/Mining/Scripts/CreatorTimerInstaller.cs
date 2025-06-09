using UnityEngine;
using Zenject;

namespace Core.Mining
{
    public class CreatorTimerInstaller : MonoInstaller
    {
        [SerializeField] private CreatorTimer _creatorTimer;
        public override void InstallBindings()
        {
            Container
                .Bind<CreatorTimer>()
                .FromInstance(_creatorTimer)
                .AsSingle();
        }
    }
}
