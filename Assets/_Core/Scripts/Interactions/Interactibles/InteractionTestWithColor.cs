using UnityEngine;

namespace AlreadyGone.Interactions.Interactables
{
    using Players;
    using Players.Movements;
    
    public class InteractionTestWithColor : MonoBehaviour, IInteractable
    {
        [SerializeField] private string _stateAnimationName;
        [SerializeField] private Color _baseColor;
        [SerializeField] private Color _interactColor;
        
        private GameObject _playerObjectReference;

        private void Awake()
        {
            HideInteraction();
            _playerObjectReference = FindFirstObjectByType<PlayerMovementHandler>().gameObject;
        }

        public void VisualizeInteraction()
        {
            GetComponent<Renderer>().material.color = _interactColor;
        }

        public void HideInteraction()
        {
            GetComponent<Renderer>().material.color = _baseColor;
        }

        public void Interact()
        {
            Debug.Log("Interacted");
            
            if (_playerObjectReference.TryGetComponent(out PlayerAnimatorHandler playerAnimation))
            {
                playerAnimation.PlayStateAnimation(_stateAnimationName);
            }
            else
            {
                foreach (Transform child in _playerObjectReference.transform)
                {
                    if (child.TryGetComponent(out playerAnimation))
                    {
                        playerAnimation.PlayStateAnimation(_stateAnimationName);
                    }
                }
            }
        }
    }
}