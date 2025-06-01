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
            foreach (BuildingInfo building in _templateData.Buildings)
            {
                _runtimeBuildings[building.Name] = new BuildingInfo
                {
                    Name = building.Name,
                    Prefab = building.Prefab,
                    Description = building.Description,
                    Reward = building.Reward,
                    State = building.State,
                    Health = building.Health,
                    Costs = new List<ResourceCost>(building.Costs) 
                };
            }
        }

        public BuildingInfo GetByName(string name)
        {
            BuildingInfo building;
            if (_runtimeBuildings.TryGetValue(name, out building))
            {
                return building;
            }
            BuildingInfo template = _templateData.Buildings.FirstOrDefault(b => b.Name == name);
            if (template != null)
            {
                _runtimeBuildings[name] = new BuildingInfo
                {
                    Name = template.Name,
                    Prefab = template.Prefab,
                    Description = template.Description,
                    Reward = template.Reward,
                    State = template.State,
                    Health = template.Health,
                    Costs = new List<ResourceCost>(template.Costs) 
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
            BuildingInfo existing = _runtimeBuildings[info.Name];
            existing.Name = info.Name;
            existing.Prefab = info.Prefab;
            existing.Description = info.Description;
            existing.Reward = info.Reward;
            existing.State = info.State;
            existing.Health = info.Health;
            existing.Costs = new List<ResourceCost>(info.Costs); 
        }

        public void ChangeState(string name, BuildingState newState)
        {
            BuildingInfo building = GetByName(name);
            if (building != null)
            {
                building.State = newState;
            }
        }
    }
}