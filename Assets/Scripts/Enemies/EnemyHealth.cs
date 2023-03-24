using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Debug;

namespace Asteroids
{
    public class EnemyHealth : BaseHealth
    {
        [SerializeField] private int _health; // for test, after set stealth
        [SerializeField] private int _maxHealth = 2;

        [SerializeField] private Transform HealthBarPrefabRoot;
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
            _health = _maxHealth;
        }
        public void TakeDamage(int damageValue)
        {
            _health -= damageValue; Log("TakeDamage");
            if (_health <= 0)
            {
                _health = 0;
                Die();
            }
            _healthBar.SetHealth(_health, _maxHealth);
        }
        public override void Die()
        {
            gameObject.SetActive(false);
            _healthBar.gameObject.SetActive(false);
            // Destroy(_healthBar.gameObject);
        }
        public void ActivateHpBar()
        {
            _healthBar.gameObject.SetActive(true);
            _health = _maxHealth; Debug.LogWarning("ActivateHpBar");
            _healthBar.SetHealth(_health, _maxHealth);
        }
        private void OnCollisionEnter(Collision collision)
        {
            TakeDamage(1);
        }
    }
}
