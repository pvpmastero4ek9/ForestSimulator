using UnityEngine;
using Zenject;

namespace Core.CamerasController
{
    public class CameraControllerInstaller : MonoInstaller
    {
        [SerializeField] private CameraController _cameraController;
        public override void InstallBindings()
        {
            Container
                .Bind<CameraController>()
                .FromInstance(_cameraController)
                .AsSingle();
        }
    }
}
