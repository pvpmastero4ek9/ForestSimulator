using System;
using System.Collections.Generic;
using Data.Building;

namespace Core.Building
{
    public class HandlerInfoBuilding
    {
        private readonly BuildingData _buildingData;

        public event Action<BuildingInfo> OnStateChanged;

        public HandlerInfoBuilding(BuildingData buildingData)
        {
            _buildingData = buildingData;
        }

        public void ChangeState(string title, BuildingState newState)
        {
            _buildingData.ChangeState(title, newState);

            BuildingInfo building = _buildingData.GetByTitle(title);
            if (building != null)
            {
                OnStateChanged?.Invoke(building);
            }
        }

        public void ApplyDamage(string title, int damage)
        {
            _buildingData.ApplyDamage(title, damage);

            BuildingInfo building = _buildingData.GetByTitle(title);
            if (building != null)
            {
                OnStateChanged?.Invoke(building);
            }
        }

        public BuildingInfo GetInfo(string title)
        {
            return _buildingData.GetByTitle(title);
        }

        public List<BuildingInfo> GetAll()
        {
            return _buildingData.GetAll();
        }

        public void Replace(BuildingInfo oldInfo, BuildingInfo newInfo)
        {
            _buildingData.Replace(oldInfo, newInfo);
        }
    }
}
