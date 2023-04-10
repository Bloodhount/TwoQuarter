using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDamagedMove : IShipState
{
    public void StateOff()
    {
        Debug.LogWarning("<color=red>ShipDamagedMove.StateOff</color>");
    }

    public void StateOn()
    {
        Debug.LogWarning("<color=green>ShipDamagedMove.StateOn</color>");
    }
}
