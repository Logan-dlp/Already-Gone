using UnityEngine;

namespace AlreadyGone.Camera.PlayerCamera
{
    using DesignPattern.Commands;
    
    public class PlayerCameraCommand : Command
    {
        private PlayerCameraCommandReceiver _commandReceiver;
        
        private GameObject _gameObject;
        private Vector2 _direction;
        private float _sensitivity;

        public PlayerCameraCommand(PlayerCameraCommandReceiver commandReceiver, GameObject gameObject,
            Vector2 direction, float sensitivity)
        {
            _commandReceiver = commandReceiver;
            _gameObject = gameObject;
            _direction = direction;
            _sensitivity = sensitivity;
        }
        
        public override void Execute()
        {
            _commandReceiver.ExecuteOperation(_gameObject, _direction, _sensitivity);
        }

        public override void UnExecute()
        {
            _commandReceiver.ExecuteOperation(_gameObject, -_direction, _sensitivity);
        }
    }
}