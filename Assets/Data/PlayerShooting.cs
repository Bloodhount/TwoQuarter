using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private float _shootForce = 200f;

    // [SerializeField] private Rigidbody2D _bullet;
    [SerializeField] private Transform _startShotPosition;

    public void Shoot(Rigidbody2D bullet) // (Rigidbody2D bullet, float force)
    {
        // bullet.AddForce(_startShotPosition.up * force, ForceMode2D.Impulse);
        bullet.GetComponent<Rigidbody2D>().AddForce(_startShotPosition.up * _shootForce);

        // var temAmmunition = Instantiate(bullet, _startShotPosition.position, _startShotPosition.rotation);
        // temAmmunition.GetComponent<Rigidbody2D>(). AddForce(_startShotPosition.up * _shootForce);      
    }
}
