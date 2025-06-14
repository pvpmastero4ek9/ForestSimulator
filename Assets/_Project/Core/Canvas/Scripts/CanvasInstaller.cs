using UnityEngine;
using Zenject;

namespace Canvase
{
    public class CanvasInstaller : MonoInstaller
    {
        [SerializeField] private Canvas _canvas;

        public override void InstallBindings()
        {
            Container
                .Bind<Canvas>()
                .FromInstance(_canvas)
                .AsSingle();
        }
    }
}
