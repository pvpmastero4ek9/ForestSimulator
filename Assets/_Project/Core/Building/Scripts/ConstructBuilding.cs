using System;
using System.Collections.Generic;
using Core.Wallets;
using Data.Building;
using UnityEngine;
using Zenject;

namespace Core.Building
{
    public class ConstructBuilding : MonoBehaviour
    {
        [Inject] private Wallet _wallet;

        [SerializeField] private Transform _positionSpawn;

        public event Action CreatedBuilding;

        public void Createbuilding(GameObject buildingPrefab, List<ResourceCost> resourceCostList)
        {
            foreach (ResourceCost resourceCost in resourceCostList)
            {
                _wallet.GetCurrency(resourceCost.ResourceType).Value -= resourceCost.Amount;
            }

            Instantiate(buildingPrefab, _positionSpawn.position, _positionSpawn.rotation);

            CreatedBuilding?.Invoke();
        }
    }
}