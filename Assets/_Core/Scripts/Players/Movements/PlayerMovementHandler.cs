using UnityEngine;
using UnityEngine.InputSystem;

namespace AlreadyGone.Players.Movements
{
    using DesignPattern.Commands;
    
    public class PlayerMovementHandler : CommandHandler
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _gravityDistanceDetection;
        
        private Vector3 _direction;
        private PlayerMovementCommandReceiver _commandReceiver;
        private CharacterController _controller;
        
        private void Awake()
        {
            _commandReceiver = new PlayerMovementCommandReceiver();
            _controller = GetComponent<CharacterController>();
        }

        private void FixedUpdate()
        {
            ExecuteMovement();
        }

        public void SetDirection(InputAction.CallbackContext ctx) => _direction = new Vector3(ctx.ReadValue<Vector2>().x, 0, ctx.ReadValue<Vector2>().y);

        private void ExecuteMovement()
        {
            _direction.y = Physics.Raycast(gameObject.transform.position, -gameObject.transform.up, out RaycastHit hitInfo, _gravityDistanceDetection)
                                        && hitInfo.transform != gameObject.transform 
                                ? 0 : _direction.y + Physics.gravity.y * Time.fixedDeltaTime;
            
            if (_direction == Vector3.zero)
                return;
            
            PlayerMovementCommand playerMovementCommand = new(_commandReceiver, 
                                                    gameObject, 
                                                    _controller,
                                                    _direction, 
                                                    _speed);
            ExecuteCommand(playerMovementCommand);
        }
    }
}