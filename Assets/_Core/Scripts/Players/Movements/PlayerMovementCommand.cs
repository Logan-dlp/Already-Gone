using UnityEngine;

namespace AlreadyGone.Players.Movements
{
    using DesignPattern.Commands;
    
    public class PlayerMovementCommand : Command
    {
        private PlayerMovementCommandReceiver _commandReceiver;

        private GameObject _gameObject;
        private CharacterController _controller;
        private Vector3 _direction;
        private float _speed;

        public PlayerMovementCommand(PlayerMovementCommandReceiver commandReceiver, 
                                GameObject gameObject, 
                                CharacterController controller, 
                                Vector3 direction, 
                                float speed)
        {
            _commandReceiver = commandReceiver;
            _gameObject = gameObject;
            _controller = controller;
            _direction = direction;
            _speed = speed;
        }
        
        public override void Execute()
        {
            _commandReceiver.ExecuteOperation(_gameObject, _controller, _direction, _speed);
        }

        public override void UnExecute()
        {
            _commandReceiver.ExecuteOperation(_gameObject, _controller, -_direction, _speed);
        }

        public override string ToString()
        {
            return $"{_gameObject.name} : {_direction} : {_speed}";
        }
    }
}