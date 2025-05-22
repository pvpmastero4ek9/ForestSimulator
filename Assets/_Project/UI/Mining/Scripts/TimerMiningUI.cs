using UnityEngine;
using Core.Mining;
using UnityEngine.UI;
using System;
using ListExtentions;

namespace UI.Mining
{
    public class TimerMiningUI : MonoBehaviour
    {
        [SerializeField] private TimerContainerForUI _timerContainer;
        [SerializeField] private Image _timerImage;
        private CountdownTimer _countdownTimer => _timerContainer.CountdownTimer;

        private void Start()
        {
            _countdownTimer.ChangedTime += OnChangedTime;
            _countdownTimer.EndedTime += DeleteObject;
        }

        private void OnEnable()
        {
            if (didStart)
            {
                _countdownTimer.ChangedTime += OnChangedTime;
                _countdownTimer.EndedTime += DeleteObject;
            }
        }

        private void OnDisable()
        {
            _countdownTimer.ChangedTime -= OnChangedTime;
            _countdownTimer.EndedTime -= DeleteObject;
        }

        private void OnChangedTime(TimeSpan timeSpan) => ChangeImageTimerValue();

        private void ChangeImageTimerValue()
        {
            _timerImage.fillAmount = (float)((_countdownTimer.totalDuration.TotalSeconds - _countdownTimer.elapsedTime.TotalSeconds) / _countdownTimer.totalDuration.TotalSeconds);
        }

        private void DeleteObject()
        {
            Destroy(gameObject);
        }
    }
}
