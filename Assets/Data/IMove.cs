namespace Asteroids
{

    public interface IMove
    {
        float Speed { get; }
        public void Move(float horizontal, float vertical);
        public void Move(float horizontal, float vertical, float deltaTime);
    }
}
