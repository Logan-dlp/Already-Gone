namespace AlreadyGone.DesignPattern.Commands
{
    public abstract class Command
    {
        public abstract void Execute();
        public abstract void UnExecute();
    }
}