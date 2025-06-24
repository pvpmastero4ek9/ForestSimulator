using UnityEngine;
using Zenject;

namespace ListExtentions
{
    public class TimerManagerInstaller : MonoInstaller
    {
        [SerializeField] private TimerManager _timerManager;
        public override void InstallBindings()
        {
            Container
                .Bind<TimerManager>()
                .FromInstance(_timerManager)
                .AsSingle();
        }
    }
}
