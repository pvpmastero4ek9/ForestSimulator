using UnityEngine;
using UnityEngine.UI;
using Zenject;
using Core.Building;

namespace Ui.Building
{
    public class BuildUIButton : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private GameObject buildingPrefab;
        [SerializeField] private Transform buildPosition;

        private BuildingPlacer _placer;

        [Inject]
        public void Construct(BuildingPlacer placer)
        {
            _placer = placer;
        }

        private void Start()
        {
            button.onClick.AddListener(PlaceBuilding);
        }

        private void PlaceBuilding()
        {
            _placer.PlaceBuilding(buildingPrefab, buildPosition.position);
        }
    }
}
