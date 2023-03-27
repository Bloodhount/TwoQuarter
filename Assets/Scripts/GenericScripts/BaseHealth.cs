using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class BaseHealth : MonoBehaviour
    {
        [SerializeField] public int CurrentHealth { get; protected set; } = 2;
        [SerializeField] public int MaxHealth { get; protected set; } = 5;
        //public BaseHealth(int max, int current)
        //{
        //    MaxHealth = max;
        //    CurrentHealth = current;
        //}
        public virtual (int currentHP, int maxHP) GetHP()
        {
            return (CurrentHealth, MaxHealth);
        }
        public virtual void Heal(int healthValue)
        {
            CurrentHealth += healthValue;
            if (CurrentHealth > MaxHealth)
            {
                CurrentHealth = MaxHealth;
            }
        }
        public virtual void Die()
        {
            Debug.Log($" {name} - Die. BaseHealth");
        }
    }
}
