using System;

namespace ListExtentions
{
    public class CountdownTimer
    {
        public TimeSpan TotalDuration { get; private set; }
        public TimeSpan ElapsedTime { get; private set; }
        public bool IsRunning { get; private set; } = false;

        private DateTime _startTime;
        private DateTime _endTime;
        private Action ActionFunction;

        public event Action<TimeSpan> ChangedTime;
        public delegate void EndedTimeHandler(CountdownTimer countdownTimer);
        public event EndedTimeHandler EndedTime;

        public void Start(DateTime targetTime, Action action)
        {
            ActionFunction = action;
            _startTime = DateTime.Now;
            _endTime = targetTime;
            TotalDuration = targetTime - _startTime;
            ElapsedTime = TimeSpan.Zero;
            IsRunning = true;
        }

        public void Cancel()
        {
            IsRunning = false;
        }

        public void Update()
        {
            if (!IsRunning)
                return;

            DateTime now = DateTime.Now;

            if (now >= _endTime)
            {
                ElapsedTime = TotalDuration;
                IsRunning = false;
                ActionFunction?.Invoke();
                ChangedTime?.Invoke(TimeSpan.Zero);
                EndedTime?.Invoke(this);
            }
            else
            {
                ElapsedTime = now - _startTime;
                var remaining = _endTime - now;
                ChangedTime?.Invoke(remaining);
            }
        }
    }
}
