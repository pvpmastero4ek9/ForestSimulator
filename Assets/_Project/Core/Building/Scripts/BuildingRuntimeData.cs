using System.Collections.Generic;
using System.Linq;
using Data.Building;
using UnityEngine;
using Zenject;

namespace Core.Building
{
    public class BuildingRuntimeData : IBuildingData
    {
        private readonly BuildingData _templateData;
        private readonly Dictionary<string, BuildingInfo> _runtimeBuildings = new();

        [Inject]
        public BuildingRuntimeData(BuildingData templateData)
        {
            _templateData = templateData;
            InitializeFromTemplate();
        }

        private void InitializeFromTemplate()
        {
            foreach (var building in _templateData.Buildings)
            {
                _runtimeBuildings[building.Name] = new BuildingInfo
                {
                    Name = building.Name,
                    Description = building.Description,
                    Reward = building.Reward,
                    State = building.State,
                    Health = building.Health
                };
            }
        }

        public BuildingInfo GetByName(string name)
        {
            if (_runtimeBuildings.TryGetValue(name, out var building))
            {
                return building;
            }
            var template = _templateData.GetByName(name);
            if (template != null)
            {
                _runtimeBuildings[name] = new BuildingInfo
                {
                    Name = template.Name,
                    Description = template.Description,
                    Reward = template.Reward,
                    State = template.State,
                    Health = template.Health
                };
                return _runtimeBuildings[name];
            }
            return null;
        }

        public void AddOrUpdate(BuildingInfo info)
        {
            if (!_runtimeBuildings.ContainsKey(info.Name))
            {
                _runtimeBuildings[info.Name] = new BuildingInfo();
            }
            var existing = _runtimeBuildings[info.Name];
            existing.Name = info.Name;
            existing.Description = info.Description;
            existing.Reward = info.Reward;
            existing.State = info.State;
            existing.Health = info.Health;
        }

        public void ChangeState(string name, BuildingState newState)
        {
            var building = GetByName(name);
            if (building != null)
            {
                building.State = newState;
            }
        }
    }
}