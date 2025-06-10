using Core.Wallets;
using Data.ResourcesSounds;
using UnityEngine;
using Zenject;

namespace Core.Mining
{
    public class CreaterSounds : MonoBehaviour
    {
        [Inject] private ResourcesSoundsData _resourcesSoundsData;

        public void CreateSound(CurrencyType currencyType, Vector3 position)
        {
            AudioClip sound = _resourcesSoundsData.GetResourceRandomSound(currencyType);
            if (sound == null) return;
            CreateSound(sound, position);
        }

        public void CreateSoundBreaking(CurrencyType currencyType, Vector3 position)
        {
            AudioClip sound = _resourcesSoundsData.GetResourceSoundBreaking(currencyType);
            if (sound == null) return;
            CreateSound(sound, position);
        }

        private void CreateSound(AudioClip sound, Vector3 position)
        {
            GameObject tempGO = new GameObject("TempAudio");
            tempGO.transform.position = position;
            AudioSource aSource = tempGO.AddComponent<AudioSource>();

            aSource.clip = sound;
            aSource.outputAudioMixerGroup = _resourcesSoundsData.OutputMixerGroup;
            aSource.spatialBlend = 1f; // 3D звук
            aSource.Play();

            Destroy(tempGO, sound.length);
        }
    }
}
