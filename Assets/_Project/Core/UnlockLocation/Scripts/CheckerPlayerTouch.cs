using System;
using UnityEngine;

namespace Core.UnlockLocations
{
    public class CheckerPlayerTouch : MonoBehaviour
    {
        public event Action TouchedPlayer;
        public event Action EndTouchedPlayer;

        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                TouchedPlayer?.Invoke();
            }
        }

        void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                EndTouchedPlayer?.Invoke();
            }
        }
    }
}
