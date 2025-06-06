using UnityEngine;

namespace AlreadyGone.Players.Animators
{
    using Animations;
    
    public class PlayerAnimatorHandler : MonoBehaviour
    {
        private const string ANIMATOR_POSX_VARIABLE = "PosX";
        private const string ANIMATOR_POSY_VARIABLE = "PosY";
        
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void UpdateMovementAnimation(Vector2 direction)
        {
            _animator.SetFloat(ANIMATOR_POSX_VARIABLE, direction.x);
            _animator.SetFloat(ANIMATOR_POSY_VARIABLE, direction.y);
        }

        public void PlayStateAnimation(EAnimations animation)
        {
            _animator.Play(animation.ToString());
        }
    }
}