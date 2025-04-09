using UnityEngine;
using UnityEngine.InputSystem;

namespace AlreadyGone.Players
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speedMovement;
        public float SpeedMovement => _speedMovement;
        
        private Vector3 _velocity;
        public Vector3 Velocity => _velocity;
        
        [SerializeField] private float _gravityDistanceDetection;
        
        private CharacterController _characterController;
        private Vector2 _targetMovement;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void FixedUpdate()
        {
            Movement();
        }

        private void Movement()
        {
            Vector3 horizontalMovement = _speedMovement * new Vector3(_targetMovement.x, 0, _targetMovement.y);
            float gravityMovement = Gravity(_velocity.y);
            
            _velocity = horizontalMovement + gravityMovement * Vector3.up;
            Vector3 movement = transform.forward * _velocity.z + transform.right * _velocity.x + transform.up * _velocity.y;
            
            _characterController.Move(movement * Time.fixedDeltaTime);
        }

        private float Gravity(float verticalVelocity)
        {
            if (Physics.Raycast(transform.position, -transform.up, out RaycastHit hitInfo, _gravityDistanceDetection) && hitInfo.transform != transform)
            {
                return 0;
            }
            
            verticalVelocity += Physics.gravity.y * Time.fixedDeltaTime;
            return verticalVelocity;
        }

        public void SetMovementDirection(InputAction.CallbackContext ctx) => _targetMovement = ctx.ReadValue<Vector2>();
    }
}