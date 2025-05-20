using Core.Interfaces;
using Data.Building;
using UnityEngine;

namespace Core.Building
{
    public class BuildingSelectionService : IBuildingSelectionService
    {
        public DataBuilding SelectedBuilding { get; private set; }

        public void SelectBuilding(DataBuilding buildingData)
        {
            SelectedBuilding = buildingData;
        }

        public void ClearSelection()
        {
            SelectedBuilding = null;
        }
    }
}
