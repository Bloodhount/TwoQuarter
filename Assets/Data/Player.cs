using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    internal sealed class Player : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _shootForce = 10f;
        private float _inputDirVertical, _inputDirHorizontal;

        [SerializeField] private Transform _startShotPosition;
        [SerializeField] private GameObject _bullet;
        private Camera _camera;
        private Ship _ship;
        private Rigidbody _playerRigidbody;
        private AccelerationMove _moveTransform;
        private void Start()
        {
            _camera = Camera.main;
            _playerRigidbody = GetComponent<Rigidbody>();
            _moveTransform = new AccelerationMove(_playerRigidbody, _speed, _acceleration);
            //  var _moveTransform = new AccelerationMove(transform, _speed, _acceleration);
            var _rotation = new RotationShip(transform);
            _ship = new Ship(_moveTransform, _rotation); // теперь можно поменять _ship на любой класс поддержывающий методы Move и Rotation(интерфейсы IMove, IRotation)
        }
        void Update()
        {
            var direction = Input.mousePosition - _camera.WorldToScreenPoint(transform.position);
            _ship.Rotation(direction);

            PlayerInput();
        }
        private void FixedUpdate()
        {
            RbMove();
        }

        private void PlayerInput()
        {

            _inputDirHorizontal = Input.GetAxis("Horizontal");
            _inputDirVertical = Input.GetAxis("Vertical");

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
                var temAmmunition = GameObject.Instantiate(_bullet, _startShotPosition.position, _startShotPosition.rotation).GetComponent<Rigidbody>();
                temAmmunition.AddForce(_startShotPosition.up * _shootForce);
            }
        }
        private void RbMove() 
        {
            _ship.Move(_inputDirHorizontal, _inputDirVertical);
        }
    }
}