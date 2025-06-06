namespace AlreadyGone.Interactions
{
    using Animations;
    
    public interface IInteractable
    {
        public EAnimations GetAnimation();
        public void VisualizeInteraction();
        public void HideInteraction();
        public void Interact();
    }
}
