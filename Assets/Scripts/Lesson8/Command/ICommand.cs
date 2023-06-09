namespace Asteroids.Command
{
    public interface ICommand
    {
        bool Succeeded { get; }
        bool TryExecute();
        void Undo();
    }
}
