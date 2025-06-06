namespace AlreadyGone.Interactions
{
    using Broadcasts;
    using Animations;
    
    public interface IInteractable : IVisibility, IAnimate
    {
        public void Interact();
    }
}
