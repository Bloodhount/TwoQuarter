using Adapter;
using UnityEngine;

namespace Asteroids
{/// <summary>
/// used type generic type
/// </summary>
/// <typeparam name="T"></typeparam>
    public class AsteroidFactory<T> : MonoBehaviour where T : MonoBehaviour//, IEnemyFactory
    {
        [SerializeField] private T _prefab;
        [SerializeField] private Transform _spawnPoint;
        // TODO for prototype
        public T CreateAsUn() //(EnemyHealth health)
        {
            //  var enemy = Object.Instantiate(Resources.Load<Asteroid>("Prefabs/asteroids1"));
            Vector3 pos = new Vector3(_spawnPoint.position.x, _spawnPoint.position.y, -1);
            var enemy = GameObject.Instantiate(_prefab, pos, Quaternion.identity);
            enemy.gameObject.AddComponent<UnitAdapter>();

            // !!! TODO encapsulate field _timeToSelfdestruct !!!
            enemy.gameObject.AddComponent<DestroySelfGO>()._timeToSelfdestruct = 9;
            // enemy.DependencyInjectHealth(health);
            return enemy;
        }
        public void InitUnit(T prefab, Transform transform)
        {
            _prefab = prefab; _spawnPoint = transform;
        }
    }
}
