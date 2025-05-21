using UnityEngine;

namespace Core.Building
{
    public class BuildingPlacer
    {
        public GameObject PlaceBuilding(GameObject buildingPrefab, Vector3 position)
        {
            return Object.Instantiate(buildingPrefab, position, Quaternion.identity);
        }
    }
}
