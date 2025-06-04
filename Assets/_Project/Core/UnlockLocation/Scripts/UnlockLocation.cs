using System;
using Core.CamerasController;
using UnityEngine;
using Zenject;

namespace Core.UnlockLocations
{
    public class UnlockLocation : MonoBehaviour
    {
        [Inject] private CameraController _cameraController;

        [SerializeField] private GameObject _locationSpawn_PREFAB;
        [SerializeField] private LocationPoints _currentLocationPoints;
        [SerializeField] private LocationName _location;
        [SerializeField] private GameObject _barrierForLocation;

        public void Unlock()
        {
            GameObject newLocation = Instantiate(_locationSpawn_PREFAB);
            newLocation.transform.position = _currentLocationPoints.End.position - newLocation.GetComponent<LocationPoints>().Begin.localPosition;

            _cameraController.ActivateCamera(_location);

            Destroy(_barrierForLocation);
            Destroy(gameObject);
        }
    }
}
