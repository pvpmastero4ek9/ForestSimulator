using UnityEngine;

namespace Core.Building
{
    public class BuildingPlacer
    {
        public void PlaceBuilding(Vector3 position, GameObject prefab)
        {
            Object.Instantiate(prefab, position, Quaternion.identity);
        }
    }
}
