using UnityEngine;
using UnityEngine.InputSystem;

namespace AlreadyGone.Camera.PlayerCamera
{
    using DesignPattern.Commands;
    
    public class PlayerCameraHandler : CommandHandler
    {
        [SerializeField] private float _sensitivity;
        
        private Vector2 _direction;
        private PlayerCameraCommandReceiver _commandReceiver;

        private void Awake()
        {
            _commandReceiver = new PlayerCameraCommandReceiver();
        }

        private void FixedUpdate()
        {
            ExecuteMovement();
        }

        public void SetDirection(InputAction.CallbackContext ctx) => _direction = ctx.ReadValue<Vector2>();

        private void ExecuteMovement()
        {
            if (_direction == Vector2.zero)
                return;

            PlayerCameraCommand playerCameraCommand = new(_commandReceiver,
                                                            gameObject, 
                                                            _direction, 
                                                            _sensitivity);
            
            ExecuteCommand(playerCameraCommand);
        }
    }
}