using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public sealed class Asteroid : Enemy
    {
        public HealthStruct AsteroidHealth = new HealthStruct();
    }

    public struct HealthStruct 
    {
        [SerializeField] private int _maxHealth;
        [SerializeField] private int _currentHealth;
    }
}
