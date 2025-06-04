using UnityEngine;
using Zenject;
using Data.Building;
using Core.Building;
using Core.Wallets;
using Ui.Building;

public class GameInstaller : MonoInstaller
{
    [SerializeField] private BuildingData _buildingData;
    [SerializeField] private CreaterInterfaceUI _uiController;

    public override void InstallBindings()
    {
        Container.Bind<BuildingData>().FromInstance(_buildingData).AsSingle();
        Container.Bind<IBuildingData>().To<BuildingRuntimeData>().AsSingle();
        Container.Bind<IResourceChecker>().To<InsufficientResourcesChecking>().AsSingle();
        Container.Bind<IBuildingStateManager>().To<HandlerInfoBuilding>().AsSingle();
        Container.Bind<IWalletService>().To<WalletService>().AsSingle();
        Container.Bind<IUIController>().FromInstance(_uiController).AsSingle();
    }
}