using UnityEngine;
using UnityEngine.AI;

namespace Core.Mining
{
    public class AutoMoveToResource : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;

        public void MoveTo(Vector3 targetPositon)
        {
            _agent.isStopped = false;
            _agent.SetDestination(targetPositon);
        }

        public void Stop() => _agent.isStopped = true;
        public Vector3 GetPosition() => _agent.transform.position;
    }
}
