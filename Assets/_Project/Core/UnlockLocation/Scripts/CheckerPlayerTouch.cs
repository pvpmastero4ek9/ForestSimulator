using System;
using UnityEngine;

namespace Core.UnlockLocations
{
    public class CheckerPlayerTouch : MonoBehaviour
    {
        public event Action TouchedPlayer;
        public event Action EndTouchedPlayer;

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                TouchedPlayer?.Invoke();
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Player")
            {
                EndTouchedPlayer?.Invoke();
            }
        }
    }
}
