using UnityEngine;

namespace Core.Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class MovePlayer : MonoBehaviour
    {
        [SerializeField] private Vector3 _transformMovement;
        [SerializeField] private float _speed = 7f;
        public float MoveX { get; private set; }
        public float MoveY { get; private set; }
        private Rigidbody _rigidbody;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            MovementLogic();
        }

        private void MovementLogic()
        {
            MoveX = Input.GetAxis("Horizontal");
            MoveY = Input.GetAxis("Vertical");

            Vector3 forward = _transformMovement.normalized;

            // Право относительно направления — поворот на 90° вокруг Y
            Vector3 right = Vector3.Cross(Vector3.up, forward).normalized;

            // Комбинируем движение
            Vector3 movementVector = (forward * MoveY + right * MoveX).normalized;
            RotateLogic(movementVector);

            Vector3 velocity = movementVector * _speed;
            _rigidbody.linearVelocity = new Vector3(velocity.x, _rigidbody.linearVelocity.y, velocity.z);
        }

        private void RotateLogic(Vector3 moveDirectionVector)
        {
            if (moveDirectionVector != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(moveDirectionVector);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.deltaTime);
            }
        }
    }
}
