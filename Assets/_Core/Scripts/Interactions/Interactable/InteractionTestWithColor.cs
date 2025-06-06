using UnityEngine;

namespace AlreadyGone.Interactions.Interactable
{
    using Animations;
    
    public class InteractionTestWithColor : MonoBehaviour, IInteractable
    {
        [SerializeField] private EAnimations _interactionAnimation;
        [SerializeField] private Color _baseColor;
        [SerializeField] private Color _interactColor;

        private void Awake()
        {
            Hide();
        }

        public EAnimations GetAnimation()
        {
            return _interactionAnimation;
        }

        public void Show()
        {
            GetComponent<Renderer>().material.color = _interactColor;
        }

        public void Hide()
        {
            GetComponent<Renderer>().material.color = _baseColor;
        }

        public void Interact()
        {
            Debug.Log("Interacted");
        }
    }
}