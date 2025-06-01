using UnityEngine;
using Zenject;

namespace Core.Player
{
    public class InfoPlayerInstaller : MonoInstaller
    {
        [SerializeField] private InfoPlayer _infoPlayer;

        public override void InstallBindings()
        {
            Container
                .Bind<InfoPlayer>()
                .FromInstance(_infoPlayer)
                .AsSingle();
        }
    }
}
