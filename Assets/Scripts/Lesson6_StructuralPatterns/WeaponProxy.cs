using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Asteroids;

public sealed class WeaponProxy : IWeapon
{
    private readonly IWeapon _weapon;
    private readonly UnlockWeapon _unlockWeapon;
    public WeaponProxy(IWeapon weapon, UnlockWeapon unlockWeapon)
    {
        _weapon = weapon;
        _unlockWeapon = unlockWeapon;
    }
    public void Shoot(float shootForce)
    {
        if (_unlockWeapon.IsUnlock)
        {
            _weapon.Shoot(shootForce);
        }
        else
        {
            Debug.Log("<color=magenta> Weapon is lock</color>");
        }
    }
}

