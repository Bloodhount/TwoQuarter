using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public sealed class AsteroidFactory : IEnemyFactory
    {    [SerializeField] private Asteroid _asteroid;
        public  Enemy Create(EnemyHealth health)
        {
          //  var enemy = Object.Instantiate(Resources.Load<Asteroid>("Prefabs/asteroids1"));
            var enemy = GameObject. Instantiate<Asteroid>(_asteroid); 
            enemy.DependencyInjectHealth(health);
            return enemy;
        }
    }
}
