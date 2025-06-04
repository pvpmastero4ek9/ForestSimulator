using AYellowpaper.SerializedCollections;
using Unity.Cinemachine;
using UnityEngine;

namespace Core.CamerasController
{
    public class CameraController : MonoBehaviour
    {
        [SerializedDictionary("Location", "Camera")]
        [SerializeField] private SerializedDictionary<LocationName, CinemachineCamera> CamerasLocationsDictionary;

        private CinemachineCamera _currentCamera;

        private void Start()
        {
            _currentCamera = CamerasLocationsDictionary[0];
        }

        public void ActivateCamera(LocationName locationName)
        {
            _currentCamera.Priority = 0;
            _currentCamera = CamerasLocationsDictionary[locationName];
            _currentCamera.Priority = 10;
        }
    }
}
