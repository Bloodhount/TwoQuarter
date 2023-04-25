using System;
using System.Collections.Generic;
using Asteroids.State;
using TMPro;
using UnityEngine;
using static UnityEngine.Debug;

namespace Asteroids
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private float _shootForce = 100f;
        [SerializeField] private TextMeshProUGUI _shipMoveStateTextUI;
        [SerializeField] private TextMeshProUGUI _weaponStateText;
        private Dictionary<Type, IShipState> _behaviourStates;
        private IShipState _currentShipState;
        UnlockWeapon unlockWeapon;
        private void Start()
        {
            this.InitBehaviourStates();
            //  this.SetDefaultState();

            unlockWeapon = new UnlockWeapon(false); WeaponStateTextUpdate("Lock");
        }
        void Update()
        {
            StateInput();
            PlayerShoot();
            AlternativeShoot();
            WeaponSafety();
        }


        #region StatePatternRegion
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
            GetAndShowHPvalue();

            var state = this.GetState<ShipNormalMove>();
            this.SetState(state);
            ShipMoveStateTextUpdate("<color=green>Normal</color>");
        }

        public void SetDamagedState()
        {
            GetAndShowHPvalue();
            var state = this.GetState<ShipDamagedMove>();
            this.SetState(state);
            ShipMoveStateTextUpdate("<color=red>Damaged</color>");
        }

        private void GetAndShowHPvalue()
        {
            if (TryGetComponent(out PlayerHealth PlayerHealthComponent))
            {
                string currHP = PlayerHealthComponent.GetHPvalue().ToString();
                TextMessager.TextMessageUpdate(">>TextMessager<<; \n <color=yellow>HP</color>:" + $"<color=red>\"{currHP}\"</color>");
            }
        }

        private void ShipMoveStateTextUpdate(string text)
        {
            _shipMoveStateTextUI.text = $"MoveState: {text} ";
        }
        #endregion

        #region ProxyPatternRegion
        private void WeaponSafety()
        {
            if (Input.GetKeyDown(KeyCode.U))
            {
                unlockWeapon.IsUnlock = true;
                Log("<color=green> Weapon is Unlock</color> ");
                WeaponStateTextUpdate("<color=yellow>Unlock</color>");
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                unlockWeapon.IsUnlock = false; Log("<color=red> Weapon is lock</color> ");
                WeaponStateTextUpdate("<color=red>Lock</color>");
            }
        }

        private void WeaponStateTextUpdate(string text)
        {
            _weaponStateText.text = $"Weapon: {text} ";
        }

        // temp place for HW
        private void PlayerShoot()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                // var unlockWeapon = new UnlockWeapon(false);
                var weapon = new PlayerWeapon();
                var weaponProxy = new WeaponProxy(weapon, unlockWeapon);
                weaponProxy.Shoot(_shootForce);
                //unlockWeapon.IsUnlock = true;

                //        var bullet = ServiceLocator.GetService<BulletsPool>();
                //        bullet.GetBaseObjPool<Bullet>(_shootForce);
            }
        }
        #endregion

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
