namespace State
{
    public interface IState
    {
        void Do(ContextShip context);
        string SayMove();
    }
}
