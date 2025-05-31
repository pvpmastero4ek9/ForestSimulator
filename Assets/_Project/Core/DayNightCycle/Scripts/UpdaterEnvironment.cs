using System.Collections;
using UnityEngine;

namespace Core.DayNightCycle
{
    public class UpdaterEnvironment : MonoBehaviour
    {
        private const float DayIntensity = 1f;
        private const float NightIntensity = 0f;

        [SerializeField] private DayNightCycle _dayNightCycle;
        [SerializeField] private Light _directionalLight;
        [SerializeField] private float _transitionDurationInSeconds = 5f;

        private void OnEnable()
        {
            _dayNightCycle.SwitchedPhase += UpdateEnvironment;
        }

        private void OnDisable()
        {
            _dayNightCycle.SwitchedPhase -= UpdateEnvironment;
        }

        private void UpdateEnvironment(DayPhase dayPhase)
        {
            float targetIntensity = (dayPhase == DayPhase.Day) ? DayIntensity : NightIntensity;
            StartCoroutine(SmoothTransition(_directionalLight.color, targetIntensity, dayPhase));
        }

        private IEnumerator SmoothTransition(Color targetColor, float targetIntensity, DayPhase dayPhase)
        {
            Color initialColor = _directionalLight.color;
            float initialIntensity = _directionalLight.intensity;
            float elapsed = 0f;

            while (elapsed < _transitionDurationInSeconds)
            {
                elapsed += Time.deltaTime;
                float t = elapsed / _transitionDurationInSeconds;

                _directionalLight.color = Color.Lerp(initialColor, targetColor, t);
                _directionalLight.intensity = Mathf.Lerp(initialIntensity, targetIntensity, t);

                yield return null;
            }

            _directionalLight.color = targetColor;
            _directionalLight.intensity = targetIntensity;
        }
    }
}
