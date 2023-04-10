using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipNormalMove : IShipState
{
    public void StateOff()
    {
        Debug.Log("ShipNormalMove.StateOff");
    }

    public void StateOn()
    {
        Debug.Log("ShipNormalMove.StateOn");
    }
}
