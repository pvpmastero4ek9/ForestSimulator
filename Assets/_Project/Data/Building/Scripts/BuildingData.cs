using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Data.Building
{
    [CreateAssetMenu(fileName = "BuildingData", menuName = "Building/BuildingData", order = 1)]
    public class BuildingData : ScriptableObject
    {
        [SerializeField] private List<BuildingInfo> _buildings = new();

        public IReadOnlyList<BuildingInfo> Buildings => _buildings.AsReadOnly();

        public BuildingInfo GetByName(string name)
        {
            return _buildings.FirstOrDefault(building => building.Name == name);
        }
    }
}