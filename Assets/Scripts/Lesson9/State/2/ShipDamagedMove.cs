using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDamagedMove : IShipState
{
    public void StateOff()
    {
       Debug.Log("ShipDamagedMove.StateOff");
    }

    public void StateOn()
    {
        Debug.Log("ShipDamagedMove.StateOn");
    }
}
