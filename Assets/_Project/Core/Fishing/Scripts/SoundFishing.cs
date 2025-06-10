using Core.Player;
using UnityEngine;
using Zenject;

namespace Core.Fishing
{
    public class SoundFishing : MonoBehaviour
    {
        [Inject] private InfoPlayer _infoPlayer;
        
        [SerializeField] private AudioSource _gurgleSound;
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
            _gurgleSound.Play();
        }
    }
}
