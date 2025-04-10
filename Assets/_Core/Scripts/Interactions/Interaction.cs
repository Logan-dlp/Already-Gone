using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace AlreadyGone.Interactions
{
    using Inputs;
    
    public class Interaction : MonoBehaviour
    {
        [SerializeField] private float _interactionDistance;
        
        private IInteractible _currentInteractible;
        
        private void Update()
        {
            if (InputManager.Instance.IsActiveInput)
            {
                if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, _interactionDistance))
                {
                    if (hit.collider.TryGetComponent(out IInteractible interactible))
                    {
                        if (_currentInteractible != null)
                        {
                            if (_currentInteractible != interactible)
                            {
                                interactible.VisualizeInteraction();
                                _currentInteractible.HideInteraction();
                                _currentInteractible = interactible;
                            }
                        }
                        else
                        {
                            interactible.VisualizeInteraction();
                            _currentInteractible = interactible;
                        }
                    }
                    else if (_currentInteractible != null)
                    {
                        _currentInteractible.HideInteraction();
                        _currentInteractible = null;
                    }
                }
                else if (_currentInteractible != null)
                {
                    _currentInteractible.HideInteraction();
                    _currentInteractible = null;
                }
            }
            else if (_currentInteractible != null)
            {
                _currentInteractible.HideInteraction();
                _currentInteractible = null;
            }
        }

        public void Interact(InputAction.CallbackContext ctx)
        {
            if (ctx.started && InputManager.Instance.IsActiveInput)
            {
                if (_currentInteractible != null)
                {
                    _currentInteractible.Interact();
                }
            }
        }
    }
}