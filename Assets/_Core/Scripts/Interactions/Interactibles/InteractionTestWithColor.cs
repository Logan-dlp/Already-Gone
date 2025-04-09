using UnityEngine;

namespace AlreadyGone.Interactions.Interactibles
{
    public class InteractionTestWithColor : MonoBehaviour, IInteractible
    {
        [SerializeField] private Color _baseColor;
        [SerializeField] private Color _interactColor;

        private void Awake()
        {
            HideInteraction();
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
        }
    }
}