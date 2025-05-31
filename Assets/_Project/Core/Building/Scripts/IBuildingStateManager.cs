using Data.Building;

namespace Core.Building
{
    public interface IBuildingStateManager
    {
        BuildingState GetCurrentState(string name);
        void ChangeState(string name);
    }
}