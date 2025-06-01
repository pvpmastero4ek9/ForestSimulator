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
        [Inject] private InfoPlayer _infoPlayer;

        public float SuccessZoneCenter { get; private set; }
        public float SuccessZoneWidth { get; private set; }

        private AnimatorPlayer _animatorPlayer => _infoPlayer.AnimatorPlayer;
        private float _minValue;
        private float _maxValue = 1f;
        private float _value;
        private float _speed = 1f;
        private float _successMin;
        private float _successMax;
        private float direction = 1f;

        public bool IsRunning { get; private set; } = false;
        public event Action<float> OnValueChanged;
        public event Action OnSuccess;
        public event Action OnFail;


        [SerializeField] private float _wateBeforeFishingInSeconds;
        private CountdownTimer _countdownTimer = new();
        private CheckerClickInGameFishing _checkerClickInGameFishing = new();

        public delegate void StartedGameHandler();
        public event StartedGameHandler StartedGame;


        private void OnEnable()
        {
            _animatorPlayer.SwimedFallen += WateWishing;
            _checkerClickInGameFishing.Clicked += Stop;
        }

        private void OnDisable()
        {
            _animatorPlayer.SwimedFallen -= WateWishing;
            _checkerClickInGameFishing.Clicked -= Stop;
        }

        private void SetSuccessZone(float center, float width)
        {
            SuccessZoneCenter = center;
            SuccessZoneWidth = width;


            _successMin = center - width / 2f;
            _successMax = center + width / 2f;
        }

        private void SetDataFishing()
        {
            SetSuccessZone(0.5f, UnityEngine.Random.Range(0.1f, 0.4f));
            _speed = UnityEngine.Random.Range(1f, 2f);
        }

        private async void WateWishing()
        {
            DateTime dateTime = DateTime.Now + TimeSpan.FromSeconds(_wateBeforeFishingInSeconds);
            await _countdownTimer.WaitUntil(dateTime, StartGame);
        }

        private void StartGame()
        {
            IsRunning = true;

            SetDataFishing();
            StartCoroutine(GameCycle());
            StartCoroutine(_checkerClickInGameFishing.CheckClick());

            StartedGame?.Invoke();
        }

        private void Stop()
        {
            IsRunning = false;

            if (_value >= _successMin && _value <= _successMax)
                OnSuccess?.Invoke();
            else
                OnFail?.Invoke();
        }

        private IEnumerator GameCycle()
        {
            while (IsRunning)
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
