using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Enemy : MonoBehaviour, IEnemy
    {
        //  [SerializeField] private GameObject _asteroid;
        public EnemyHealth Health { get; private set; }
        //   public void CreateAsteroidEnemy(Asteroid health) // static
        public static Asteroid CreateAsteroidEnemy(EnemyHealth health) // Textures asteroids1
        {
            // var enemy = Instantiate(_asteroid);
            var enemy = Instantiate(Resources.Load<Asteroid>("Prefabs/asteroids1"));
            enemy.Health = health;
            return enemy;
        }
        public void DependencyInjectHealth(EnemyHealth hp)
        {
            Health = hp;
        }

        public void Attack()// TODO: some mandatory for enemies method
        {
            Debug.LogWarning("  TODO: remake inplementation interface ");
        }
    }
}
