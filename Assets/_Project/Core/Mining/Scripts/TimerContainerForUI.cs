using System;
using ListExtentions;
using UnityEngine;

namespace Core.Mining
{
    public class TimerContainerForUI : MonoBehaviour
    {
        public CountdownTimer CountdownTimer { get; private set; }

        public TimerContainerForUI Init(CountdownTimer countdownTimer)
        {
            CountdownTimer = countdownTimer;
            return this;
        }
    }
}
