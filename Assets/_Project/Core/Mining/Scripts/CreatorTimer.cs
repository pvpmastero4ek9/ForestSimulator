using System;
using UnityEngine;

namespace Core.Mining
{
    public class Creator : MonoBehaviour
    {
        private const float UpwardShift = 2f;
        [SerializeField] private ResourceNode _resourceNode;
        [SerializeField] private Canvas _canvas;
        [SerializeField] private TimerContainerForUI _timer_PREFAB;

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
            Instantiate(_timer_PREFAB, spawnPosition, Quaternion.identity, _canvas.transform).Init(_resourceNode.CountdownTimer);
        }
    }
}
