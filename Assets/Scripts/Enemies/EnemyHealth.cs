using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Debug;

namespace Asteroids
{
    public class EnemyHealth : BaseHealth
    {
        [SerializeField] private int health = 2;
        private void Start()
        {
            CurrentHealth = health;
        }
        public void TakeDamage(int damageValue)
        {
            CurrentHealth -= damageValue; Log("TakeDamage");
            if (CurrentHealth <= 0)
            {
                CurrentHealth = 0;
                Die();
            }
        }
        public override void Die()
        {
            gameObject.SetActive(false);
            // Destroy(gameObject);
        }
        private void OnCollisionEnter(Collision collision)
        {
            TakeDamage(1);
        }
    }
}
