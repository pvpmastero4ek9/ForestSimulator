using UnityEngine;
using UnityEngine.Audio;

namespace Core.Settings
{
    public class SettingsLogic : MonoBehaviour
    {
        [SerializeField] private AudioMixerGroup _mixer;

        public void ChangeVolumeMusic(float volume)
        {
            ChangeVolume("MusicVolume", volume);
        }

        public void ChangeVolumeSound(float volume)
        {
            ChangeVolume("EffectsVolume", volume);
        }

        public float GetVolumeGroup(string groupName, float minDb = -80f, float maxDb = 0f)
        {
            if (_mixer.audioMixer.GetFloat(groupName, out float dB))
            {
                return Mathf.Clamp01((dB - minDb) / (maxDb - minDb));
            }
            return 0f;
        }

        private void ChangeVolume(string groupName, float volume)
        {
            _mixer.audioMixer.SetFloat(groupName, Mathf.Lerp(-80, 0, volume));
        }
    }
}
