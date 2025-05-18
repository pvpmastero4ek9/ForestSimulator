using UnityEngine;

namespace Core.Building
{
    public class BuildPoint : MonoBehaviour
    {
        [SerializeField] private bool isOccupied = false;
        [SerializeField] private GameObject currentBuilding;

        public bool getIsOccupied() => isOccupied;

        public void buildSetBuildibg(GameObject buildingPrefab)
        {
            if (isOccupied) return;

            currentBuilding = Instantiate(buildingPrefab, transform.position, Quaternion.identity);
            isOccupied = true;
        }

        public GameObject getCurrentBuilding() => currentBuilding;
    }
}
