using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Enemy : MonoBehaviour, IEnemy
    {
        //  [SerializeField] private Object _asteroid;

        [SerializeField] private GameObject _asteroidPrefab;
        [SerializeField] private Asteroid res;
        public EnemyHealth Health { get; private set; } // bad variant to use
        public void CreateAsteroidEnemy() // (Asteroid health)

        // public static Asteroid CreateAsteroidEnemy(EnemyHealth health) // Textures asteroids1
        { 
            // GameObject obj = Instantiate(_prefab, _startPosition.position, _startPosition.rotation);

            GameObject enemy1 = Instantiate(_asteroidPrefab,transform);
            enemy1.name = "111111111111";
            //var enemy2 = Instantiate(Resources.Load<Asteroid>("Prefabs/asteroids1"));
            //enemy2.name = "222222222222";

            //Debug.LogError("Instantiate(Resources.Load<Asteroid>");
            // enemy.Health = health;
            //return enemy;
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
