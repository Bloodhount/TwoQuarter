using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class PlayerHealth : BaseHealth, IGetHPvalue
    {
        [SerializeField] private int _hp;
        [SerializeField] private int _maxHp = 3;
        [SerializeField] private Transform HealthBarPrefabRoot;
        //private PlayerController _playerController;
        private HealthBar _healthBar;
        public GameObject HealthBarPrefab;
        private void Awake()
        {
            GameObject healthBar = Instantiate(HealthBarPrefab, HealthBarPrefabRoot);
            _healthBar = healthBar.GetComponentInChildren<HealthBar>();
            _healthBar.Setup(gameObject.transform);
        }
        private void Start()
        {
            _hp = _maxHp;
            CurrentHealth = _hp;
            MaxHealth = _maxHp;
            if (TryGetComponent(out PlayerController playerControllerComponent))
            {
                playerControllerComponent.SetNormalState();
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (_hp < 1)
            {
                Destroy(gameObject);
                if (_hp < 0)
                {
                    _hp = 0;
                }
            }
            else
            {
                _hp--; CurrentHealth = _hp;
            }

            if (_hp < _maxHp / 3)
            {
                if (TryGetComponent(out PlayerController playerControllerComponent))
                {
                    playerControllerComponent.SetDamagedState();
                }
            }

            _healthBar.SetHealth(_hp, _maxHp);
        }

        public override void Heal(int healthValue)
        {
            if (_hp < _maxHp)
            {
                _hp += healthValue;
                if (_hp > _maxHp / 3)
                {
                    if (TryGetComponent(out PlayerController playerControllerComponent))
                    {
                        playerControllerComponent.SetNormalState();
                    }
                }
            }
            if (_hp >= _maxHp)
            {
                _hp = _maxHp;
            }
            _healthBar.SetHealth(_hp, _maxHp);
        }
        public int GetHPvalue()
        {
            return _hp;
        }
    }
}
