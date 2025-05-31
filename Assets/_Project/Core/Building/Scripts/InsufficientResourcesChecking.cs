using Core.Wallets;
using Data.Building;
using System.Collections.Generic;

namespace Core.Building
{
    public class InsufficientResourcesChecking
    {
        private readonly IWalletService _walletService;
        private readonly BuildingContainerForUI _container;

        public InsufficientResourcesChecking(IWalletService walletService, BuildingContainerForUI container)
        {
            _walletService = walletService;
            _container = container;
        }

        public bool HasEnoughResources(string buildingTitle)
        {
            List<ResourceCost> costs = _container.GetCosts(buildingTitle);
            foreach (ResourceCost cost in costs)
            {
                if (!_walletService.HasEnough(cost.Type, cost.Amount))
                    return false;
            }

            return true;
        }
    }
}
