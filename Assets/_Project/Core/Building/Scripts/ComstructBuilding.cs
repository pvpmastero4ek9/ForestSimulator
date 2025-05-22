using Core.Building;
using Data.Building;
using UnityEngine;
using Core.Wallets;

public class ConstructBuilding
{
    private readonly IWalletService _walletService;
    private readonly BuildingContainerForUI _container;

    public ConstructBuilding(IWalletService walletService, BuildingContainerForUI container)
    {
        _walletService = walletService;
        _container = container;
    }

    public bool TryConstruct(string buildingTitle, Vector3 position)
    {
        BuildingInfo info = _container.GetInfo(buildingTitle);
        if (info == null) return false;

        foreach (ResourceCost cost in info.Cost)
        {
            if (!_walletService.HasEnough(cost.Type, cost.Amount))
                return false;
        }

        foreach (ResourceCost cost in info.Cost)
        {
            _walletService.Spend(cost.Type, cost.Amount);
        }

        GameObject.Instantiate(info.Prefab, position, Quaternion.identity);
        return true;
    }
}
