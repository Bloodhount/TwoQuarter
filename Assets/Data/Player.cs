using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    internal sealed class Player : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _shootForce;
        [SerializeField] private Rigidbody2D _bulletRigidbody;
        [SerializeField] private Transform _startShotPosition;
        private Camera _camera;
        private Ship _ship;
        private PlayerShooting _playerShooting;
        [SerializeField] private GameObject _bullet;

        private void Start()
        {
            _camera = Camera.main;
            var _moveTransform = new AccelerationMove(transform, _speed, _acceleration);
            var _rotation = new RotationShip(transform);
            //_bulletRigidbody = FindObjectOfType<PlayerShooting>().GetComponent<Rigidbody2D>();
            // var _instantiateBullet = new PlayerShooting();
            _ship = new Ship(_moveTransform, _rotation); // теперь можно поменять _ship на любой класс поддержывающий методы Move и Rotation(интерфейсы IMove, IRotation)
        }
        void Update()
        {
            var direction = Input.mousePosition - _camera.WorldToScreenPoint(transform.position);

            _ship.Rotation(direction);
            _ship.Move(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), Time.deltaTime);

            PlayerInput();
        }

        private void PlayerInput()
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _ship.AddAcceleration();
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                _ship.RemoveAcceleration();
            }
            if (Input.GetButtonDown("Fire1"))
            {
                //_bulletRigidbody = FindObjectOfType<PlayerShooting>().GetComponent<Rigidbody2D>();
                // var temAmmunition = Instantiate(_bullet, _startShotPosition.position, _startShotPosition.rotation);
                // _playerShooting.Shoot(temAmmunition);
                // _playerShooting.Shoot(_bullet);
                var temAmmunition = Instantiate(_bulletRigidbody, _startShotPosition.position, _startShotPosition.rotation);
                temAmmunition.AddForce(_startShotPosition.up * _shootForce);
            }
        }
    }
}