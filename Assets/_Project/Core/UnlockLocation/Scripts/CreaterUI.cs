using UnityEngine;

namespace Core.UnlockLocations
{
    public class CreaterUI : MonoBehaviour
    {
        [SerializeField] private CheckerPlayerTouch _checkerPlayerTouch;
        [SerializeField] private UnlockLocationContainerForUI _unlockLocationUI_PREFAB;
        [SerializeField] private Canvas _canvasSpawn;
        [SerializeField] private InfoUnlockLocation _infoUnlockLocation;
        [SerializeField] private UnlockLocation _unlockLocation;
        private UnlockLocationContainerForUI _currentObjectUI;

        private void OnEnable()
        {
            _checkerPlayerTouch.TouchedPlayer += CreateUI;
            _checkerPlayerTouch.EndTouchedPlayer += DeliteUI;
        }

        private void OnDisable()
        {
            _checkerPlayerTouch.TouchedPlayer -= CreateUI;
            _checkerPlayerTouch.EndTouchedPlayer -= DeliteUI;
        }

        private void CreateUI()
        {
            _currentObjectUI = Instantiate(_unlockLocationUI_PREFAB, _canvasSpawn.transform).Init(_infoUnlockLocation, _unlockLocation.Unlock);
        }

        private void DeliteUI()
        {
            if (_currentObjectUI == null) return;
            Destroy(_currentObjectUI.gameObject);
        }
    }
}
