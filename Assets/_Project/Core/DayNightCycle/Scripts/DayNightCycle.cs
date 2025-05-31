using UnityEngine;
using ListExtentions;
using System;

namespace Core.DayNightCycle
{
    public class DayNightCycle : MonoBehaviour
    {
        [SerializeField] private float _dayDuractionMinutes = 1f;
        [SerializeField] private float _nightDuractionMinutes = 1f;
        public CountdownTimer CountdownTimer { get; private set; } = new();
        public DayPhase CurrentPhase { get; private set; } = DayPhase.Day;

        public delegate void SwitchedPhaseHandler(DayPhase dayPhase);
        public event SwitchedPhaseHandler SwitchedPhase;

        private void Start()
        {
            StartDayNightCycle();
        }

        private void StartDayNightCycle()
        {
            SwitchPhase(CurrentPhase);
        }

        private void SwitchPhase(DayPhase phase)
        {
            CurrentPhase = phase;

            float duration = phase == DayPhase.Day ? _dayDuractionMinutes : _nightDuractionMinutes;
            DateTime endTime = DateTime.Now.AddMinutes(duration);

            StartTimerPhase(endTime);
            SwitchedPhase?.Invoke(phase);
        }

        private async void StartTimerPhase(DateTime endTime)
        {
            await CountdownTimer.WaitUntil(endTime, OnPhaseEnd);
        }

        private void OnPhaseEnd()
        {
            DayPhase nextPhase = CurrentPhase == DayPhase.Day ? DayPhase.Night : DayPhase.Day;
            SwitchPhase(nextPhase);
        }
    }
}
