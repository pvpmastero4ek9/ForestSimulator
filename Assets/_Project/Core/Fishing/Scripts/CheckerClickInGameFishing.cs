using System.Collections;
using UnityEngine;
using Zenject;

namespace Core.Fishing
{
    public class CheckerClickInGameFishing : MonoBehaviour
    {
        [Inject] private GameFishing _gameFishing;

        private void OnEnable()
        {
            _gameFishing.StartedGame += OnStartFishing;
            _gameFishing.StopedFishing += StopCheckClick;
        }

        private void OnDisable()
        {
            _gameFishing.StartedGame -= OnStartFishing;
            _gameFishing.StopedFishing -= StopCheckClick;
        }

        private void OnStartFishing() => StartCoroutine(CheckClick());

        private void StopCheckClick() => StopAllCoroutines();

        public IEnumerator CheckClick()
        {
            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            StopFishing();
        }

        private void StopFishing()
        {
            _gameFishing.ActivateStopFishing();
        }
    }
}
