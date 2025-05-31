using Data.Building;
using UnityEngine.Events;

namespace Core.Building
{
    public interface IBuildingStateManager
    {
        BuildingState GetCurrentState(string name);
        void ChangeState(string name);
        UnityEvent<string, BuildingState> OnStateChanged { get; } 
    }
}