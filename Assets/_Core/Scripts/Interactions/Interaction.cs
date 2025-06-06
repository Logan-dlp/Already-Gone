using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace AlreadyGone.Interactions
{
    using Inputs;
    using Animations;
    using Collectibles;
    
    public class Interaction : MonoBehaviour
    {
        [SerializeField] private float _interactionDistance;
        [Space]
        [SerializeField] private UnityEvent<EAnimations> _onInteract;
        [Space]
        [SerializeField] private UnityEvent<ECollectible> _onCollect;
        
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
                                interactable.Show();
                                _currentInteractable.Hide();
                                _currentInteractable = interactable;
                            }
                        }
                        else
                        {
                            interactable.Show();
                            _currentInteractable = interactable;
                        }
                    }
                    else if (_currentInteractable != null)
                    {
                        _currentInteractable.Hide();
                        _currentInteractable = null;
                    }
                }
                else if (_currentInteractable != null)
                {
                    _currentInteractable.Hide();
                    _currentInteractable = null;
                }
            }
            else if (_currentInteractable != null)
            {
                _currentInteractable.Hide();
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

                    if (_currentInteractable is ICollector collectible)
                    {
                        _onCollect?.Invoke(collectible.Collect());
                    }
                }
            }
        }
    }
}