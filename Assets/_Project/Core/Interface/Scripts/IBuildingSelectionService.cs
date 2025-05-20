using Data.Building;
using UnityEngine.UIElements;

namespace Core.Interfaces
{
    public interface IBuildingSelectionService
    {
        DataBuilding SelectedBuilding { get; }
        void SelectBuilding(DataBuilding buildingData);
        void ClearSelection();
    }
}
