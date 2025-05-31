using Data.Building;

namespace Core.Building
{
    public interface IResourceChecker
    {
        bool HasEnoughResources(string buildingName, BuildingState state);
    }
}