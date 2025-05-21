using UnityEngine;

namespace Core.Building
{
    public class BuildPoint : MonoBehaviour
    {
        [SerializeField] private GameObject buildingPreview;
        public GameObject BuildingPreview => buildingPreview;
    }
}
