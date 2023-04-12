public interface IMove
{
    float Speed { get; }
    public abstract void Move();
    public void Move(float horizontal, float vertical);
    public void Move(float horizontal, float vertical, float deltaTime);
}

