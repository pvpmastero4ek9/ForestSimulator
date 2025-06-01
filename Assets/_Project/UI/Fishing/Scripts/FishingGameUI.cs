using Core.Fishing;
using UnityEngine;
using Zenject;

namespace UI.Fishing
{
    public class FishingGameUI : MonoBehaviour
    {
        [Inject] private GameFishing _gameFishing;

        [SerializeField] private RectTransform _line;
        [SerializeField] private RectTransform _bar;
        [SerializeField] private RectTransform _successZone;

        private void OnEnable()
        {
            _gameFishing.OnValueChanged += UpdateValueLine;
            UpdateSuccessZoneVisual(_gameFishing.SuccessZoneCenter, _gameFishing.SuccessZoneWidth);
        }

        private void OnDisable()
        {
            _gameFishing.OnValueChanged -= UpdateValueLine;
        }

        private void UpdateSuccessZoneVisual(float center, float width)
        {
            float zoneX = Mathf.Lerp(-_bar.rect.width / 2f, _bar.rect.width / 2f, center);
            float zoneWidth = width * _bar.rect.width;

            var zone = _successZone;
            var anchored = zone.anchoredPosition;
            anchored.x = zoneX;
            zone.anchoredPosition = anchored;

            var size = zone.sizeDelta;
            size.x = zoneWidth;
            zone.sizeDelta = size;
        }

        private void UpdateValueLine(float value)
        {
            float x = Mathf.Lerp(-_bar.rect.width / 2f, _bar.rect.width / 2f, value);
            var anchored = _line.anchoredPosition;
            anchored.x = x;
            _line.anchoredPosition = anchored;
        }
    }
}
