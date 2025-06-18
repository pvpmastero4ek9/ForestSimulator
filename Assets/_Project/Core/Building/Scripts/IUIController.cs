namespace Core.Building
{
    public interface IUIController
    {
        void CreateUI();
        void CreateUI(string buildingName);
        void UpdateUI(string buildingName);
        void HideUI();
    }
}