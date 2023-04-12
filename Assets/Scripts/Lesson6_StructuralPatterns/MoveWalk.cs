using Asteroids;
using static UnityEngine.Debug;

public class MoveWalk : IMove
{
    public float Speed { get; protected set; }

    public void Move()
    {
        Log("<color=yellow>MoveWalk. Move</color>");
    }

    public void Move(float horizontal, float vertical)
    {
        Log("MoveWalk. Move(float horizontal, float vertical)");
    }

    public void Move(float horizontal, float vertical, float deltaTime)
    {
        Log("MoveWalk. Move(float horizontal, float vertical, float deltaTime)");
    }
}
