using NUnit.Framework.Constraints;
using UnityEngine;

namespace Core.DayNightCycle
{
    public class PlayerPhaseSound : MonoBehaviour
    {
        [SerializeField] private DayNightCycle _dayNightCycle;
        [SerializeField] private AudioSource _daySound;
        [SerializeField] private AudioSource _nightSound;

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
            AudioSource audioClip = dayPhase == DayPhase.Day ? _daySound : _nightSound;
            AudioSource audioClipOpposite = dayPhase == DayPhase.Day ? _nightSound : _daySound;

            audioClipOpposite.Stop();
            audioClip.Play();
        }
    }
}
