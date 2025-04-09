using UnityEngine;

namespace AlreadyGone.Interactions
{
    public interface IInteractible
    {
        public void VisualizeInteraction();
        public void HideInteraction();
        public void Interact();
    }
}
