using UnityEngine;

namespace AlreadyGone.Animations.Events
{
    using Inputs;
    
    public class DesactiveInputOnAnimationEvent : StateMachineBehaviour
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            InputManager.Instance.DisableInput();
        }
        
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            InputManager.Instance.EnableInput();
        }
    }
}