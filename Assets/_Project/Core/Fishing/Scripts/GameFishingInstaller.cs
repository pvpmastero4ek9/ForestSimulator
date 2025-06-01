using UnityEngine;
using Zenject;

namespace Core.Fishing
{
    public class GameFishingInstaller : MonoInstaller
    {
        [SerializeField] private GameFishing _gameFishing;

        public override void InstallBindings()
        {
            Container
                .Bind<GameFishing>()
                .FromInstance(_gameFishing)
                .AsSingle();
        }
    }
}
