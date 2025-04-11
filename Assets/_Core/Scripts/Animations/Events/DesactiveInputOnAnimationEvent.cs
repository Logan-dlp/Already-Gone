using UnityEngine;

namespace AlreadyGone.Animations.Events
{
    using Inputs;
    
    public class DesactiveInputOnAnimationEvent : StateMachineBehaviour
    {
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            InputManager.Instance.DisableInput();
        }
        
        override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            InputManager.Instance.EnableInput();
        }
    }
}