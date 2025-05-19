using UnityEngine;
using Zenject;

namespace Core.Building
{
    public class BuildInteractionController : MonoBehaviour
    {
        [SerializeField] private BuildPoint _buildPoint;
        private BuildingPlacer _placer;
        private BuildingCostChecker _costChecker;

        [Inject]
        public void Construct(BuildingPlacer placer, BuildingCostChecker costChecker)
        {
            _placer = placer;
            _costChecker = costChecker;
        }

        public void TryBuild()
        {
            var data = _buildPoint.DataBuilding;
            if (_costChecker.CanAfford(data.Costs))
            {
                _costChecker.Deduct(data.Costs);
                _placer.PlaceBuilding(_buildPoint.GetPosition(), data.Prefab);
            }
            else
            {
                Debug.Log("Недостаточно ресурсов.");
            }
        }
    }
}
