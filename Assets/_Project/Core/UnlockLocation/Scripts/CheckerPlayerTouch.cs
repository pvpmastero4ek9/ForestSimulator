using System;
using UnityEngine;

namespace Core.UnlockLocations
{
    public class CheckerPlayerTouch : MonoBehaviour
    {
        public bool IsPlayerTouch { get; private set; } = false;
        public event Action TouchedPlayer;
        public event Action EndTouchedPlayer;

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                IsPlayerTouch = true;
                TouchedPlayer?.Invoke();
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                IsPlayerTouch = false;
                EndTouchedPlayer?.Invoke();
            }
        }
    }
}
