using Data.Building;

namespace Core.Building
{
    public interface IBuildUIController
    {
        void Show(DataBuilding data, BuildPoint point);
        void Hide();
    }
}
