using Core.Fishing;
using UnityEngine;
using Zenject;

namespace UI.Fishing
{
    public class FishingActivatedUI : MonoBehaviour
    {
        [Inject] private GameFishing _gameFishing;

        [SerializeField] private FishingGameUI ui_PREFAB;
        [SerializeField] private Canvas _canvasForPrefab;

        private FishingGameUI _currentObj; 

        private void OnEnable()
        {
            _gameFishing.StartedGame += ActivateVisualUI;
            _gameFishing.OnSuccess += StopVisualUI;
            _gameFishing.OnFail += StopVisualUI;
        }

        private void OnDisable()
        {
            _gameFishing.StartedGame -= ActivateVisualUI;
            _gameFishing.OnSuccess -= StopVisualUI;
            _gameFishing.OnFail -= StopVisualUI;
        }

        private void ActivateVisualUI()
        {
            _currentObj = Instantiate(ui_PREFAB, _canvasForPrefab.transform);
        }

        private void StopVisualUI()
        {
            Destroy(_currentObj.gameObject);
        }
    }
}
