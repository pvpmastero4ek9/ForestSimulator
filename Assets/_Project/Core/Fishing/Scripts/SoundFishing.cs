using Core.Player;
using UnityEngine;
using Zenject;

namespace Core.Fishing
{
    public class SoundFishing : MonoBehaviour
    {
        [Inject] private InfoPlayer _infoPlayer;
        
        [SerializeField] private AudioSource _gurgleSound;
        [SerializeField] private Transform _positionSound;
        private AnimatorPlayer _animatorPlayer => _infoPlayer.AnimatorPlayer;

        private void OnEnable()
        {
            _animatorPlayer.SwimedFallen += GurgleSoundPlay;
        }

        private void OnDisable()
        {
            _animatorPlayer.SwimedFallen -= GurgleSoundPlay;
        }

        private void GurgleSoundPlay()
        {
            GameObject tempGO = new GameObject("TempAudio");
            tempGO.transform.position = _positionSound.position;
            AudioSource aSource = tempGO.AddComponent<AudioSource>();

            aSource.clip = _gurgleSound.clip;
            aSource.outputAudioMixerGroup = _gurgleSound.outputAudioMixerGroup;
            aSource.spatialBlend = 1f; // 3D звук
            aSource.Play();

            Destroy(tempGO, _gurgleSound.clip.length);
        }
    }
}
