using UnityEngine;
using System;

namespace Core.Building
{
    public class PlayerLocationChecker : MonoBehaviour
    {
        public bool IsPlayerInside { get; private set; }
        public event Action PlayerCamed;
        public event Action PlayerCamedOut;
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                IsPlayerInside = true;

                PlayerCamed?.Invoke();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                IsPlayerInside = false;

                PlayerCamedOut?.Invoke();
            }
        }
    }
}