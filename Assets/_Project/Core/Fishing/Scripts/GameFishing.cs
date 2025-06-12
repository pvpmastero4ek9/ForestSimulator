using System;
using System.Collections;
using System.Threading;
using Core.Player;
using ListExtentions;
using UnityEngine;
using Zenject;

namespace Core.Fishing
{
    public class GameFishing : MonoBehaviour
    {
        private const float DividerWidth = 2f;
        private const float SuccessZoneWidthRandomMin = 0.1f;
        private const float SuccessZoneWidthRandomMax = 0.3f;
        private const float SuccessZoneCenterValue = 0.5f;
        private const float SpeedRandomMin = 1f;
        private const float SpeedRandomMax = 2f;

        [Inject] private InfoPlayer _infoPlayer;

        public float SuccessZoneCenter { get; private set; }
        public float SuccessZoneWidth { get; private set; }

        private AnimatorPlayer _animatorPlayer => _infoPlayer.AnimatorPlayer;
        private AutoMove _autoMove => _infoPlayer.AutoMove;
        private float _minValue;
        private float _value;
        private float _successMin;
        private float _successMax;
        private bool _isFishing = true;
        private bool _isEndFishing;

        public event Action<float> OnValueChanged;
        public event Action OnSuccess;
        public event Action OnFail;
        public event Action StopedFishing;

        [SerializeField] private RewardDistributorFishing _rewardDistributorFishing;
        [SerializeField] private float _wateBeforeFishingInSeconds;
        [SerializeField] private float _maxValue = 1f;
        [SerializeField] private float _speed = 1f;
        [SerializeField] private float direction = 1f;
        private CountdownTimer _countdownTimer = new();

        public delegate void StartedGameHandler();
        public event StartedGameHandler StartedGame;

        private void OnEnable()
        {
            _autoMove.StopedAgent += StopFishing;
            _animatorPlayer.SwimedFallen += WateWishing;
        }

        private void OnDisable()
        {
            _animatorPlayer.SwimedFallen -= WateWishing;
            _autoMove.StopedAgent -= StopFishing;
        }

        private void SetSuccessZone()
        {
            float center = SuccessZoneCenterValue;
            float width = UnityEngine.Random.Range(SuccessZoneWidthRandomMin, SuccessZoneWidthRandomMax);

            SuccessZoneCenter = SuccessZoneCenterValue;
            SuccessZoneWidth = UnityEngine.Random.Range(SuccessZoneWidthRandomMin, SuccessZoneWidthRandomMax);

            _successMin = center - width / DividerWidth;
            _successMax = center + width / DividerWidth;
        }

        private void SetDataFishing()
        {
            SetSuccessZone();
            _speed = UnityEngine.Random.Range(SpeedRandomMin, SpeedRandomMax);
        }

        private async void WateWishing()
        {
            _isFishing = true;

            DateTime dateTime = DateTime.Now + TimeSpan.FromSeconds(_wateBeforeFishingInSeconds);
            await _countdownTimer.WaitUntil(dateTime, StartGame);
        }

        private void StartGame()
        {
            if (_isFishing == false) return;
            
            SetDataFishing();
            StartCoroutine(GameCycle());

            StartedGame?.Invoke();
        }

        public void ActivateStopFishing()
        {
            _isEndFishing = true;
            StopFishing();
        }

        private void StopFishing()
        {
            if (_isEndFishing)
            {
                if (_value >= _successMin && _value <= _successMax)
                {
                    _rewardDistributorFishing.GetCurrency(_speed);
                    OnSuccess?.Invoke();
                }
                else
                {
                    OnFail?.Invoke();
                }

                _isEndFishing = false;
            }
            else
            {
                StopAllCoroutines();
                _countdownTimer.Cancel();
                StopedFishing?.Invoke();
            }

            _isFishing = false;
        }

        private IEnumerator GameCycle()
        {
            while (_isFishing)
            {
                _value += direction * _speed * Time.deltaTime;

                if (_value >= _maxValue)
                {
                    _value = _maxValue;
                    direction = -1f;
                }
                else if (_value <= _minValue)
                {
                    _value = _minValue;
                    direction = 1f;
                }

                OnValueChanged?.Invoke(_value);

                yield return null;
            }
        }
    }
}
