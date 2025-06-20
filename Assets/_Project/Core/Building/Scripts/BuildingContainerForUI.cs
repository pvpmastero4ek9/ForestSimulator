using UnityEngine;
using System;
using Data.Building;

namespace Core.Building
{
    public class BuildingContainerForUI : MonoBehaviour
    {
        public BuildingInfo BuildingInfo { get; private set; }
        public ConstructBuilding ConstructBuilding { get; private set; }
        public event Action Inited;

        public BuildingContainerForUI Init(BuildingInfo buildingInfo, ConstructBuilding constructBuilding)
        {
            BuildingInfo = buildingInfo;
            ConstructBuilding = constructBuilding;

            Inited?.Invoke();
            return this;
        }
    }
}