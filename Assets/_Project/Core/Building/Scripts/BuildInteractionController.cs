using Core.Wallets;
using UnityEngine;
using Zenject;

namespace Core.Building
{
    public class BuildInteractionController : MonoBehaviour
    {
        [Inject] private Wallet _wallet;
        [SerializeField] private BuildPoint _buildPoint;
        private BuildingPlacer _placer;
        private BuildingCostChecker _costChecker;

        public void TryBuild()
        {
            _costChecker = new(_wallet);

            // var data = _buildPoint.DataBuilding;
            // if (_costChecker.CanAfford(data.Costs))
            // {
            //     _costChecker.Deduct(data.Costs);
            //     _placer.PlaceBuilding(_buildPoint.GetPosition(), data.Prefab);
            // }
            // else
            // {
            //     Debug.Log("������������ ��������.");
            // }
        }
    }
}
