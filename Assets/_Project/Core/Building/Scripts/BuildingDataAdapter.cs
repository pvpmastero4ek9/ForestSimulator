using Core.Building;
using Data.Building;
using UnityEngine;

namespace Core.Building
{
    public class BuildingDataAdapter : IBuildingData
    {
        private readonly BuildingData _buildingData;

        public BuildingDataAdapter(BuildingData buildingData)
        {
            _buildingData = buildingData;
        }

        public BuildingInfo GetByName(string name)
        {
            return _buildingData.GetByName(name);
        }

        public void AddOrUpdate(BuildingInfo info)
        {
            Debug.LogWarning("AddOrUpdate is not implemented in BuildingDataAdapter, as BuildingData is read-only.");
            
        }

        public void ChangeState(string name, BuildingState newState)
        {
            Debug.LogWarning("ChangeState is not implemented in BuildingDataAdapter, as BuildingData is read-only.");
            
        }
    }
}