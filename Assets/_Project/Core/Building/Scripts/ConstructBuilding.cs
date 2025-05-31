using Data.Building;
using Zenject;

namespace Core.Building
{
    public class ConstructBuilding : IConstructBuilding
    {
        private readonly IBuildingData _buildingData;

        [Inject]
        public ConstructBuilding(IBuildingData buildingData)
        {
            _buildingData = buildingData;
        }

        public void Build(string name)
        {
            var info = _buildingData.GetByName(name);
            if (info == null)
            {
                _buildingData.AddOrUpdate(new BuildingInfo
                {
                    Name = name,
                    State = BuildingState.Built
                });
            }
        }
    }
}