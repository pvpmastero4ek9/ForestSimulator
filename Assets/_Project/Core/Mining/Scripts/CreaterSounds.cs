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
            AudioSource.PlayClipAtPoint(sound, position);
        }

        public void CreateSoundBreaking(CurrencyType currencyType, Vector3 position)
        {
            AudioClip sound = _resourcesSoundsData.GetResourceSoundBreaking(currencyType);
            if (sound == null) return;
            AudioSource.PlayClipAtPoint(sound, position);
        } 
    }
}
