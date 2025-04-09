using UnityEngine;
using UnityEngine.InputSystem;

namespace AlreadyGone.Camera
{
    public class FPSCameraMovement : MonoBehaviour
    {
        [SerializeField] private Vector2 _mouseSensitivity;
        
        private GameObject _playerGameObject;
        private Vector2 _targetMovement;

        private void Awake()
        {
            _playerGameObject = FindFirstObjectByType<CharacterController>().gameObject;
        }

        private void Update()
        {
            Movement();
        }

        private void Movement()
        {
            _playerGameObject.transform.Rotate(_targetMovement.x * Time.deltaTime * _mouseSensitivity.x * Vector3.up);

            float horizontalMovement = transform.localEulerAngles.x - _targetMovement.y * Time.deltaTime * _mouseSensitivity.y;

            if (horizontalMovement <= 90) horizontalMovement = horizontalMovement > 0 ? Mathf.Clamp(horizontalMovement, 0, 85) : horizontalMovement;
            if (horizontalMovement > 270) horizontalMovement = Mathf.Clamp(horizontalMovement, 275, 360);
            
            transform.localEulerAngles = Vector3.right * horizontalMovement;
        }
        
        public void SetMovementDirection(InputAction.CallbackContext ctx) => _targetMovement = ctx.ReadValue<Vector2>();
    }
}