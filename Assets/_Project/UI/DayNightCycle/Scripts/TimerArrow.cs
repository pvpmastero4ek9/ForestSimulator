using UnityEngine;
using Core.DayNightCycle;
using ListExtentions;
using System;

namespace UI.DayNightCycle
{
    public class TimerArrow : MonoBehaviour
    {
        private const float FullParcentForArrow = 1.0f;
        [SerializeField] private Core.DayNightCycle.DayNightCycle _dayNightCycle;
        private CountdownTimer _countdownTimer => _dayNightCycle.CountdownTimer;

        private void OnEnable()
        {
            _countdownTimer.ChangedTime += UpdateArrow;
        }

        private void OnDisable()
        {
            _countdownTimer.ChangedTime -= UpdateArrow;
        }

        private void UpdateArrow(TimeSpan timeSpan)
        {
            float parcent = FullParcentForArrow - ((float)timeSpan.TotalSeconds / (float)_countdownTimer.totalDuration.TotalSeconds);

            float angle = _dayNightCycle.CurrentPhase == DayPhase.Day
            ? Mathf.Lerp(0f, 180f, parcent)
            : Mathf.Lerp(180f, 360f, parcent);

            transform.localRotation = Quaternion.Euler(0, 0, -angle);
        }
    }
}
