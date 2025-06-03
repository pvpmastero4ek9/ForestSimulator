using Core.Settings;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Settings
{
    public class SettingsUI : MonoBehaviour
    {
        [SerializeField] private Slider _sliderMusic;
        [SerializeField] private Slider _sliderSound;
        private SettingsLogic _settingsLogic;

        public SettingsUI Init(SettingsLogic settingsLogic)
        {
            _settingsLogic = settingsLogic;
            VolumeInit();
            return this;
        }

        private void VolumeInit()
        {
            _sliderMusic.value = _settingsLogic.GetVolumeGroup("MusicVolume");
            _sliderSound.value = _settingsLogic.GetVolumeGroup("EffectsVolume");
        }

        public void ChangeVolumeMusic(float volume)
        {
            _settingsLogic.ChangeVolumeMusic(volume);
        }

        public void ChangeVolumeSound(float volume)
        {
            _settingsLogic.ChangeVolumeSound(volume);
        }
    }
}
