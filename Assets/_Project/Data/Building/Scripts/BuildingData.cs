using System.Collections.Generic;

namespace Data.Building
{
    public class BuildingData
    {
        private readonly List<BuildingInfo> _allBuildings = new();

        public List<BuildingInfo> GetAll()
        {
            return _allBuildings;
        }

        public BuildingInfo GetByTitle(string title)
        {
            return _allBuildings.Find(b => b.Title == title);
        }

        public void Replace(BuildingInfo oldInfo, BuildingInfo newInfo)
        {
            int index = _allBuildings.IndexOf(oldInfo);
            if (index != -1)
            {
                _allBuildings[index] = newInfo;
            }
        }

        public void ChangeState(string title, BuildingState newState)
        {
            BuildingInfo info = GetByTitle(title);
            if (info != null)
            {
                info.State = newState;
            }
        }

        public void ApplyDamage(string title, int damage)
        {
            BuildingInfo info = GetByTitle(title);
            if (info != null)
            {
                info.CurrentHealth -= damage;
            }
        }

        public void Add(BuildingInfo building)
        {
            _allBuildings.Add(building);
        }
    }
}
