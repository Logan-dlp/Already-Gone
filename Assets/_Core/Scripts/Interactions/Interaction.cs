using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace AlreadyGone.Interactions
{
    using Inputs;
    using Animations;
    
    public class Interaction : MonoBehaviour
    {
        [SerializeField] private float _interactionDistance;
        [Space]
        [SerializeField] private UnityEvent<EAnimations> _onInteract;
        
        private IInteractable _currentInteractable;
        
        private void Update()
        {
            if (InputManager.Instance.IsActiveInput)
            {
                if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, _interactionDistance))
                {
                    if (hit.collider.TryGetComponent(out IInteractable interactable))
                    {
                        if (_currentInteractable != null)
                        {
                            if (_currentInteractable != interactable)
                            {
                                interactable.VisualizeInteraction();
                                _currentInteractable.HideInteraction();
                                _currentInteractable = interactable;
                            }
                        }
                        else
                        {
                            interactable.VisualizeInteraction();
                            _currentInteractable = interactable;
                        }
                    }
                    else if (_currentInteractable != null)
                    {
                        _currentInteractable.HideInteraction();
                        _currentInteractable = null;
                    }
                }
                else if (_currentInteractable != null)
                {
                    _currentInteractable.HideInteraction();
                    _currentInteractable = null;
                }
            }
            else if (_currentInteractable != null)
            {
                _currentInteractable.HideInteraction();
                _currentInteractable = null;
            }
        }

        public void Interact(InputAction.CallbackContext ctx)
        {
            if (ctx.started && InputManager.Instance.IsActiveInput)
            {
                if (_currentInteractable != null)
                {
                    _currentInteractable.Interact();
                    _onInteract?.Invoke(_currentInteractable.GetAnimation());
                }
            }
        }
    }
}