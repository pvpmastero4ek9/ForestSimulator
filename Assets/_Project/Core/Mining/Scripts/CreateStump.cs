using UnityEngine;

namespace Core.Mining
{
    public class CreaterStump : MonoBehaviour
    {
        [SerializeField] private ResourceNode _resourceNode;
        [SerializeField] private GameObject _stump_PREFAB;
        private GameObject _stump; 

        private void OnEnable()
        {
            _resourceNode.DestroyedResource += CreateStump;
            _resourceNode.RecoveredResource += DeliteStump;
        }

        private void OnDisable()
        {
            _resourceNode.DestroyedResource -= CreateStump;
            _resourceNode.RecoveredResource -= DeliteStump;
        }

        private void CreateStump()
        {
            _stump = Instantiate(_stump_PREFAB, transform.position, Quaternion.Euler(_stump_PREFAB.transform.eulerAngles.x, _stump_PREFAB.transform.eulerAngles.y, Random.Range(0, 180)));
        }

        private void DeliteStump()
        {
            Destroy(_stump);
        }
    }
}
