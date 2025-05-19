using Core.Wallets;
using Data.Building;
using System.Collections.Generic;

namespace Core.Building
{
    public class BuildingCostChecker
    {
        private readonly Wallet _wallet;

        public BuildingCostChecker(Wallet wallet)
        {
            _wallet = wallet;
        }

        public bool CanAfford(List<ResourceCost> costs)
        {
            foreach (var cost in costs)
            {
                if (_wallet.GetCurrency(cost.CurrencyType).Value < cost.Amount)
                    return false;
            }
            return true;
        }

        public void Deduct(List<ResourceCost> costs)
        {
            foreach (var cost in costs)
            {
                var currency = _wallet.GetCurrency(cost.CurrencyType);
                currency.Value -= cost.Amount;
            }
        }
    }
}
