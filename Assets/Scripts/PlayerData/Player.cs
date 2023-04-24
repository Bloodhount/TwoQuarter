using UnityEngine;

namespace Asteroids
{
    internal sealed class Player : MonoBehaviour
    {
        #region FieldsRegion
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;

        private float _inputDirVertical, _inputDirHorizontal;

        public Ship _ship;
        private Camera _camera;
        private Rigidbody _playerRigidbody;
        private AccelerationMove _moveTransform;
        #endregion 
        private void Start()
        {
            _camera = Camera.main;
            _playerRigidbody = GetComponent<Rigidbody>();
            _moveTransform = new AccelerationMove(_playerRigidbody, _speed, _acceleration);
            var _rotation = new RotationShip(transform);
            _ship = new Ship(_moveTransform, _rotation); // теперь можно поменять _ship на любой класс поддержывающий методы Move и Rotation(интерфейсы IMove, IRotation)
        }

        void Update()
        {
            PlayerInput();
        }

        #region InputMethodsRegion
        private void PlayerInput()
        {
            Aiming();
            HorizontalInput();
            VerticalInput();
            Boost();
            //Shoot();
            //AlternativeShoot();
           // StateInput();
        }

        private void Aiming()
        {
            var direction = Input.mousePosition - _camera.WorldToScreenPoint(transform.position);
            _ship.Rotation(direction);
        }
        private void Boost()
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                _ship.AddAcceleration();
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                _ship.RemoveAcceleration();
            }
        }
        private void VerticalInput()
        {
            _inputDirVertical = Input.GetAxis("Vertical");
        }
        private void HorizontalInput()
        {
            _inputDirHorizontal = Input.GetAxis("Horizontal");
        }
        #endregion
        private void FixedUpdate()
        {
            RbMove();
        }
        private void RbMove()
        {
            _ship.Move(_inputDirHorizontal, _inputDirVertical);
        }
    }
}