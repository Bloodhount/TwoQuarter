using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public abstract class BaseHealth : MonoBehaviour
    {
        public int CurrentHealth { get; protected set; } = 2;
        public int MaxHealth { get; protected set; } = 5;

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
