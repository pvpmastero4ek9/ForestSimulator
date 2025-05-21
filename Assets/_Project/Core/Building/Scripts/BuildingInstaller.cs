using UnityEngine;
using Zenject;
using Core.Wallets;

namespace Core.Building
{
<<<<<<< Updated upstream
    //public class BuildingInstaller : MonoInstaller
    //{
        //public override void InstallBindings()
        //{
            //Container.Bind<BuildingPlacer>().AsSingle();
            //Container.Bind<BuildingCostChecker>().AsSingle().WithArguments(Container.Resolve<Wallet>());
        //}
    //}
=======
    public class BuildingInstaller : MonoInstaller
    {
        [Inject] private Wallet _wallet;

        public override void InstallBindings()
        {
            var costChecker = new BuildingCostChecker(_wallet);

            Container
                .Bind<BuildingCostChecker>()
                .FromInstance(costChecker)
                .AsSingle();
        }
    }
>>>>>>> Stashed changes
}
