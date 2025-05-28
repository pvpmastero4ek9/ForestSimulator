using UnityEngine;
using ListExtentions;
using System;

namespace Core.DayNightCycle
{
    public class DayNightCycle : MonoBehaviour
    {
        [SerializeField] private float _dayDuractionMinutes = 1f;
        [SerializeField] private float _nightDuractionMinutes = 1f;
        private CountdownTimer _countdownTimer = new();
        private DayPhase _currentPhase = DayPhase.Day;

        public delegate void SwitchedPhaseHandler(DayPhase dayPhase);
        public event SwitchedPhaseHandler SwitchedPhase;

        private void Start()
        {
            StartDayNightCycle();
        }

        private void StartDayNightCycle()
        {
            SwitchPhase(_currentPhase);
        }

        private void SwitchPhase(DayPhase phase)
        {
            _currentPhase = phase;

            float duration = phase == DayPhase.Day ? _dayDuractionMinutes : _nightDuractionMinutes;
            DateTime endTime = DateTime.Now.AddMinutes(duration);

            StartTimerPhase(endTime);
            SwitchedPhase?.Invoke(phase);
        }

        private async void StartTimerPhase(DateTime endTime)
        {
            await _countdownTimer.WaitUntil(endTime, OnPhaseEnd);
        }

        private void OnPhaseEnd()
        {
            DayPhase nextPhase = _currentPhase == DayPhase.Day ? DayPhase.Night : DayPhase.Day;
            SwitchPhase(nextPhase);
        }
    }
}
