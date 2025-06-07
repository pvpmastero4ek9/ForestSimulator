using System;
using UnityEngine;
using UnityEngine.AI;

namespace Core.Player
{
    public class AutoMove : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private MovePlayer _movePlayer;
        private bool _isBlockMove = false;

        public bool IsBlockMove
        {
            get => _isBlockMove;
            set
            {
                IsBlockMove = value;
            }
        }
        public event Action StopedAgent;

        private void Start()
        {
            _agent.isStopped = true;
        }

        public void Update()
        {
            if (Mathf.Abs(_movePlayer.MoveX) > 0.01f || Mathf.Abs(_movePlayer.MoveZ) > 0.01f)
            {
                Stop();
            }

            if (Mathf.Abs(_movePlayer.MoveX) > 0.01f || Mathf.Abs(_movePlayer.MoveZ) > 0.01f || !_agent.isStopped)
            {
                StopedAgent?.Invoke();
            }
        }

        public void MoveTo(Vector3 targetPositon)
        {
            if (IsBlockMove) return;

            _agent.isStopped = false;
            _agent.SetDestination(targetPositon);
        }

        public void Stop() => _agent.isStopped = true;

        public Vector3 GetPosition() => _agent.transform.position;
    }
}
