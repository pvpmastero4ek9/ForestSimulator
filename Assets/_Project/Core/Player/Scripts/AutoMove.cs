using System;
using UnityEngine;
using UnityEngine.AI;

namespace Core.Player
{
    public class AutoMove : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private MovePlayer _movePlayer;

        public void Update()
        {
            if (Mathf.Abs(_movePlayer.MoveX) > 0.01f || Mathf.Abs(_movePlayer.MoveY) > 0.01f)
            {
                Stop();
            }
        }

        public void MoveTo(Vector3 targetPositon)
        {
            _agent.isStopped = false;
            _agent.SetDestination(targetPositon);
        }

        public void Stop() => _agent.isStopped = true;
        public Vector3 GetPosition() => _agent.transform.position;
    }
}
