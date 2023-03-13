using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal sealed class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _hp;
    [SerializeField] private float _force;
    [SerializeField] private Rigidbody2D _bullet;
    [SerializeField] private Transform _barrel;
    private Vector3 _move;
    void Update()
    {
        var deltaTime = Time.deltaTime;
        var speed = deltaTime * _speed;

        _move.Set(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed, 0.0f);
        transform.localPosition += _move;

        if (Input.GetButtonDown("Fire1"))
        {
            var temAmmunition = Instantiate(_bullet, _barrel.position, _barrel.rotation);
            temAmmunition.AddForce(_barrel.up * _force);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_hp <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            _hp--;
        }
    }
}
