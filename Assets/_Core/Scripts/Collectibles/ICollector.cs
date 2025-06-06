namespace AlreadyGone.Collectibles
{
    using Interactions;
    
    public interface ICollector : IInteractable
    {
        public ECollectible Collect();
    }
}