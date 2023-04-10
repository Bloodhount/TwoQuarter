using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _shootForce = 100f;
        private Dictionary<Type, IShipState> _behaviourStates;
        private IShipState _currentShipState;
        private void Start()
        {
            this.InitBehaviourStates();
            this.SetDefaultState();
        }
        void Update()
        {
            StateInput();
            Shoot();
            AlternativeShoot();
        }
        private void StateInput()
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                SetNormalState();
            }
            if (Input.GetKeyDown(KeyCode.P))
            {
                SetDamagedState();
            }
        }

        private void InitBehaviourStates()
        {
            this._behaviourStates = new Dictionary<Type, IShipState>();

            this._behaviourStates[typeof(ShipNormalMove)] = new ShipNormalMove();
            this._behaviourStates[typeof(ShipDamagedMove)] = new ShipDamagedMove();
        }
        private void SetState(IShipState newState)
        {
            if (this._currentShipState != null)
            {
                this._currentShipState.StateOff();
            }

            this._currentShipState = newState;
            this._currentShipState.StateOn();
        }
        private IShipState GetState<T>() where T : IShipState
        {
            var type = typeof(T);
            return this._behaviourStates[type];
        }
        private void SetDefaultState()
        {
            this.SetNormalState();
        }
        public void SetNormalState()
        {
            var state = this.GetState<ShipNormalMove>();
            this.SetState(state);
        }   // TODO ShipNormalMove & ShipDamagedMove переделать и исп.вместо класса Ship в классе Player
        public void SetDamagedState()
        {
            var state = this.GetState<ShipDamagedMove>();
            this.SetState(state);
        }   // TODO ShipNormalMove & ShipDamagedMove переделать и исп.вместо класса Ship в классе Player

        private void Shoot()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                var bullet = ServiceLocator.GetService<BulletsPool>();
                bullet.GetBaseObjPool<Bullet>(_shootForce);
            }
        }
        private void AlternativeShoot()
        {
            if (Input.GetMouseButton(1))
            {
                var bullet = ServiceLocator.GetService<BulletsPool>();
                bullet.GetAlternativeObjPool<Bullet>(_shootForce);
            }
        }
    }
}
