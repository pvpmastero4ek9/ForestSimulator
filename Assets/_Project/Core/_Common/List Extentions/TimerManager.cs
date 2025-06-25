using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ListExtentions
{
    public class TimerManager : MonoBehaviour
    {
        private List<CountdownTimer> _timersList = new();

        private void Update()
        {
            foreach (CountdownTimer timer in _timersList.ToList())
            {
                timer.Update();
            }
        }

        public void Register(CountdownTimer timer, DateTime targetTime, Action actionFunction)
        {
            if (!_timersList.Contains(timer))
            {
                _timersList.Add(timer);
                timer.Start(targetTime, actionFunction);
                timer.EndedTime += Unregister;
            }
        }

        private void Unregister(CountdownTimer timer)
        {
            if (_timersList.Contains(timer))
            {
                _timersList.Remove(timer);
                timer.EndedTime -= Unregister;
            }
        }
    }
}
