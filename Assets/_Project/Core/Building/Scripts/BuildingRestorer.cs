using UnityEngine;

namespace Core.Building
{
    public class BuildingRestorer
    {
        public void Restore(GameObject building)
        {
            building.SetActive(true);
        }
    }
}
