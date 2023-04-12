using Asteroids;
using static UnityEngine.Debug;

namespace Bridge
{
    public class MoveRun : IMove
    {
        public float Speed { get; protected set; }

        public void Move()
        {
            Log("<color=yellow>MoveRun. Move</color>");
        }

        public void Move(float horizontal, float vertical)
        {
            Log("MoveRun. Move(float horizontal, float vertical)");
        }

        public void Move(float horizontal, float vertical, float deltaTime)
        {
            Log("MoveRun. Move(float horizontal, float vertical, float deltaTime)");
        }
    }
}
