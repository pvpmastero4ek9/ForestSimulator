using NUnit.Framework.Constraints;
using UnityEngine;

namespace Core.DayNightCycle
{
    public class PlayerPhaseSound : MonoBehaviour
    {
        [SerializeField] private DayNightCycle _dayNightCycle;
        [SerializeField] private AudioClip _daySound;
        [SerializeField] private AudioClip _nightSound;

        private void OnEnable()
        {
            _dayNightCycle.SwitchedPhase += PlayPhaseSound;
        }

        private void OnDisable()
        {
            _dayNightCycle.SwitchedPhase -= PlayPhaseSound;
        }

        private void PlayPhaseSound(DayPhase dayPhase)
        {
            AudioClip audioClip = dayPhase == DayPhase.Day ? _daySound : _nightSound;
            AudioSource.PlayClipAtPoint(audioClip, transform.position);
        }
    }
}
