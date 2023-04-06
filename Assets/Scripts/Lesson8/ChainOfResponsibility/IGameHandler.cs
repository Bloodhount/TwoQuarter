namespace ChainOfResponsibility
{
    public interface IGameHandler
    {
        IGameHandler Handle();
    }
}