using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace State
{
    public class StateBDamagedMove : IState
    {
        public void Do(ContextShip context)
        {
            Debug.Log($" class State B. DoAction: ");
            context.SetState(this);
        }

        public string SayMove()
        {
            Debug.Log($" class State B. Say: ");
            return "B";
        }
    }
}
