using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class AsteroidFactory<T> : MonoBehaviour where T : MonoBehaviour//, IEnemyFactory
    {
        [SerializeField] private T _prefab;
        [SerializeField] private Transform _spawnPoint;
        public T CreateAsUn() //(EnemyHealth health)
        {
            //  var enemy = Object.Instantiate(Resources.Load<Asteroid>("Prefabs/asteroids1"));
            Vector3 pos = new Vector3(_spawnPoint.position.x, _spawnPoint.position.y, _spawnPoint.position.z);
            var enemy = GameObject.Instantiate(_prefab, pos, Quaternion.identity);
            // enemy.DependencyInjectHealth(health);
            return enemy;
        }
    }
}
