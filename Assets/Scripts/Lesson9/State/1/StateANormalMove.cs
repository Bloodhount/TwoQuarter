using UnityEngine;

namespace Asteroids.State
{
    public class StateANormalMove : IState
    {
        public void Do(ContextShip context)
        {
            Debug.Log($" class StateA . DoAction: ");
            context.SetState(this);
        }

        public string SayMove()
        {
            Debug.Log($" class StateA . Say: ");
            return "A";
        }
    }
}
