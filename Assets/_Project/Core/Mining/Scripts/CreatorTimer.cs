using System;
using UnityEngine;

namespace Core.Mining
{
    public class CreatorTimer : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private TimerContainerForUI _timer_PREFAB;

        public void CreateTimerUI(Vector3 spawnPosition, ResourceNode resourceNode)
        {
            Instantiate(_timer_PREFAB, spawnPosition, Quaternion.identity, _canvas.transform).Init(resourceNode.CountdownTimer);
        }
    }
}
