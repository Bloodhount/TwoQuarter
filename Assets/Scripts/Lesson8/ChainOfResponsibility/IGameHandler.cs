namespace Asteroids.ChainOfResponsibility
{
    public interface IGameHandler
    {
        IGameHandler Handle();
    }
}