using UnityEngine;
using Zenject;
using Data.Building;

namespace Core.Building
{
    public class PreperCreaterUI : MonoBehaviour
    {
        [Inject] private CreaterInterfaceUI _createrInterfaceUI;

        [SerializeField] private Buildings _buildings;
        [SerializeField] private PlayerLocationChecker _playerLocationChecker;
        [SerializeField] private ConstructBuilding _constructBuilding;

        public void OnEnable()
        {
            _playerLocationChecker.PlayerCamed += Create;
            _playerLocationChecker.PlayerCamedOut += Delite;
        }

        private void OnDisable()
        {
            _playerLocationChecker.PlayerCamed -= Create;
            _playerLocationChecker.PlayerCamedOut -= Delite;
        }

        private void Create()
        {
            _createrInterfaceUI.CreateUI(_buildings, _constructBuilding);
        }

        private void Delite()
        {
            _createrInterfaceUI.DeliteUI();
        }
    }
}
