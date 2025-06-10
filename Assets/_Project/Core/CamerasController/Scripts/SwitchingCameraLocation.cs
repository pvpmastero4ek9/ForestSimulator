using UnityEngine;
using Zenject;

namespace Core.CamerasController
{
    public class SwitchingCameraLocation : MonoBehaviour
    {
        [Inject] private CameraController _cameraController;

        [SerializeField] private LocationName _location;
        [SerializeField] private bool _isReady = true;

        public void SetIsReady(bool value)
        {
            _isReady = value;
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Player" && _isReady)
            {
                _cameraController.ActivateCamera(_location);
            }
        }
    }
}
