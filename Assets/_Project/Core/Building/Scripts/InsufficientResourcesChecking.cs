using Data.Building;
using Core.Wallets;
using System.Collections.Generic;

namespace Core.Building
{
    public class InsufficientResourcesChecking
    {
        private Wallet _wallet;

        private bool _isCheckTrue;

        public bool CheckCurrency(List<ResourceCost> resourceCostList, Wallet wallet) // name change potomy 4to bool vozvratit, no mne leni pridumivat - sam
        {
            _wallet = wallet;
            
            _isCheckTrue = true;
            foreach (ResourceCost resourceCost in resourceCostList)
            {
                if (_wallet.GetCurrency(resourceCost.ResourceType).Value - resourceCost.Amount < 0)
                {
                    _isCheckTrue = false;
                    break;
                }
            }

            return _isCheckTrue;
        }
    }
}