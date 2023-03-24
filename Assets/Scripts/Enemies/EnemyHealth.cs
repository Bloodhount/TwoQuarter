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
        private HealthBar _healthBar;
        private Transform HealthBarPrefabRoot;

        public GameObject HealthBarPrefab;
        private void Awake()
        {
            GameObject healthBar = Instantiate(HealthBarPrefab, HealthBarPrefabRoot);
            _healthBar = healthBar.GetComponent<HealthBar>();
            _healthBar.Setup(gameObject.transform);
        }
        private void Start()
        {
            // HealthBarPrefabRoot = new GameObject(HealthBar.);
            // gameObject.set
            
            _health = _maxHealth;

            // CurrentHealth = _health;
            // healthBar.transform.SetParent(gameObject. transform);
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
        private void OnCollisionEnter(Collision collision)
        {
            TakeDamage(1);
        }
    }
}
