using UnityEngine;

namespace Asteroids.State
{
    public class ContextShip
    {
        IState _currentState;
        public void SetState(IState state)
        {
            _currentState = state;
        }

        public void SayCurrentMove()
        {
            Debug.Log($" class Context . {_currentState.SayMove()}");
        }
    }
}
