using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.State
{
    public class ShipNormalMove : IShipState
    {
        public void StateOff()
        {
            Debug.LogWarning("<color=red>ShipNormalMove.StateOff</color>");
        }

        public void StateOn()
        {
            Debug.LogWarning("<color=green>ShipNormalMove.StateOn</color>");
        }
    }
}
