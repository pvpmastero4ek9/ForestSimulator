using UnityEngine;

namespace Core.UnlockLocations
{
    public class LocationPoints : MonoBehaviour
    {
        [field: SerializeField] public Transform Begin { get; private set; }
        [field: SerializeField] public Transform End { get; private set; }
    }
}
