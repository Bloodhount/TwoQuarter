using System.Collections;
using System.Collections.Generic;
using Asteroids;
using UnityEngine;

public class ShipDamagedMove : IShipState
{
    private Player _player;
    public void StateOff()
    {
        _player = GameObject.FindObjectOfType<Player>();
        Debug.LogWarning("<color=red>ShipDamagedMove.StateOff</color>");
        if (_player.gameObject.TryGetComponent(out Rigidbody rigidbody))
        {
            rigidbody.drag = 1;
        }
    }
    public void StateOn()
    {
        _player = GameObject.FindObjectOfType<Player>();
        Debug.LogWarning("<color=green>ShipDamagedMove.StateOn</color>");
        if (_player.gameObject.TryGetComponent(out Rigidbody rigidbody))
        {
            rigidbody.drag = 8;
        }
    }
}
