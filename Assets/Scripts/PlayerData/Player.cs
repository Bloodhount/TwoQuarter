using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using System.Linq;//using MoreLinq;

namespace Asteroids
{
    internal sealed class Player : MonoBehaviour
    {
        #region FieldsRegion
        [SerializeField] private float _speed;
        [SerializeField] private float _acceleration;
        //[SerializeField] private float _shootForce = 100f;

        private float _inputDirVertical, _inputDirHorizontal;

        //private Dictionary<Type, IShipState> _behaviourStates;
        //private IShipState _currentShipState;

        private Camera _camera;
        private Ship _ship;
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
            //this.InitBehaviourStates();
            //this.SetDefaultState();
        }

        #region ManagedStateRegion
        //    private void InitBehaviourStates()
        //{
        //    this._behaviourStates = new Dictionary<Type, IShipState>();

        //    this._behaviourStates[typeof(ShipNormalMove)] = new ShipNormalMove();
        //    this._behaviourStates[typeof(ShipDamagedMove)] = new ShipDamagedMove();
        //}
        //    private void SetState(IShipState newState)
        //{
        //    if (this._currentShipState != null)
        //    {
        //        this._currentShipState.StateOff();
        //    }

        //    this._currentShipState = newState;
        //    this._currentShipState.StateOn();
        //}
        //    private IShipState GetState<T>() where T : IShipState
        //{
        //    var type = typeof(T);
        //    return this._behaviourStates[type];
        //}
        //    private void SetDefaultState()
        //{
        //    this.SetNormalState();
        //}
        //    public void SetNormalState()
        //{
        //    var state = this.GetState<ShipNormalMove>();
        //    this.SetState(state);
        //}
        //    public void SetDamagedState()
        //{
        //    var state = this.GetState<ShipDamagedMove>();
        //    this.SetState(state);
        //}

        //    private void StateInput()
        //{
        //    if (Input.GetKeyDown(KeyCode.O))
        //    {
        //        SetNormalState();
        //    }
        //    if (Input.GetKeyDown(KeyCode.P))
        //    {
        //        SetDamagedState();
        //    }
        //}
        #endregion
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
        //private void Shoot()
        //{
        //    if (Input.GetButtonDown("Fire1"))
        //    {
        //        var bullet = ServiceLocator.GetService<BulletsPool>();
        //        bullet.GetBaseObjPool<Bullet>(_shootForce);
        //    }
        //}
        //private void AlternativeShoot()
        //{
        //    if (Input.GetMouseButton(1))
        //    {
        //        var bullet = ServiceLocator.GetService<BulletsPool>();
        //        bullet.GetAlternativeObjPool<Bullet>(_shootForce);
        //    }
        //}
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