using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace AlreadyGone.Players.Movements
{
    using DesignPattern.Commands;
    
    public class PlayerMovementHandler : CommandHandler
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _gravityDistanceDetection;
        [Space]
        [SerializeField] private UnityEvent<Vector2> _onMovementEvent;
        
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

        private float ApplyGravity(float gravityDirection)
        {
            return Physics.Raycast(gameObject.transform.position, -gameObject.transform.up, out RaycastHit hitInfo, _gravityDistanceDetection)
                   && hitInfo.transform != gameObject.transform 
                ? 0 : gravityDirection + Physics.gravity.y * Time.fixedDeltaTime;
        }

        private void ExecuteMovement()
        {
            _onMovementEvent?.Invoke(new Vector2(_direction.x, _direction.z));
            _direction.y = ApplyGravity(_direction.y);
            
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