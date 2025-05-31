using System.Collections.Generic;
using Data.Building;

namespace Core.Building
{
    public class BuildingContainerForUI
    {
        private readonly List<BuildingInfo> _buildings;

        public BuildingContainerForUI(List<BuildingInfo> buildings)
        {
            _buildings = buildings;
        }

        public BuildingInfo GetInfo(string title)
        {
            foreach (BuildingInfo info in _buildings)
            {
                if (info.Title == title)
                    return info;
            }
            return null;
        }

        public List<ResourceCost> GetCosts(string title)
        {
            BuildingInfo info = GetInfo(title);
            return info != null ? new List<ResourceCost>(info.Cost) : new List<ResourceCost>();
        }

        public List<BuildingInfo> GetAll()
        {
            return _buildings;
        }
    }
}
