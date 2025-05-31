using Data.Building;

namespace Core.Building
{
    public interface IBuildingData
    {
        BuildingInfo GetByName(string name);
        void AddOrUpdate(BuildingInfo info);
        void ChangeState(string name, BuildingState newState);
    }
}