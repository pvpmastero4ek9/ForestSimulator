using UnityEngine;
using Zenject;

namespace Core.Mining
{
    public class BinderCreaterTimer : MonoBehaviour
    {
        [Inject] private CreatorTimer _creatorTimer;

        private const float UpwardShift = 2f;
        [SerializeField] private ResourceNode _resourceNode;

        private void OnEnable()
        {
            _resourceNode.DestroyedResource += CreateTimerUI;
        }

        private void OnDisable()
        {
            _resourceNode.DestroyedResource -= CreateTimerUI;
        }

        private void CreateTimerUI()
        {
            Vector3 spawnPosition = transform.position + Vector3.up * UpwardShift;
            _creatorTimer.CreateTimerUI(spawnPosition, _resourceNode);
        }
    }
}
