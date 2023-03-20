using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private float _shootForce;

   // [SerializeField] private Rigidbody2D _bullet;
    [SerializeField] private Transform _startShotPosition;

    public void Shoot(GameObject bullet)
    { bullet.GetComponent<Rigidbody2D>().AddForce(_startShotPosition.up * _shootForce);
        // var temAmmunition = Instantiate(bullet, _startShotPosition.position, _startShotPosition.rotation);
        // temAmmunition.GetComponent<Rigidbody2D>(). AddForce(_startShotPosition.up * _shootForce);      
    }
}
