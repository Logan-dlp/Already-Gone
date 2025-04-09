using UnityEngine;

namespace AlreadyGone.Players
{
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] PlayerMovement _playerMovement;
        [SerializeField] private float _speedAnimation;
        
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _animator.speed = _speedAnimation;
        }

        private void Update()
        {
            Vector2 animationVelocity = new(_playerMovement.Velocity.x, _playerMovement.Velocity.z);
            animationVelocity /= _playerMovement.SpeedMovement;

            _animator.SetFloat("PosX", animationVelocity.x);
            _animator.SetFloat("PosY", animationVelocity.y);
        }
    }
}