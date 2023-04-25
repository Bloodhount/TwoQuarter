using Asteroids.Adapter;
using UnityEngine;

namespace Asteroids
{/// <summary>
/// used type generic type
/// </summary>
/// <typeparam name="T"></typeparam>
    public class AsteroidFactory<T> : MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField] private T _prefab;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private float SpawnPositionX = 5;

        public T CreateAsUn()
        {
            var spawnPositionX = Random.Range(-SpawnPositionX, SpawnPositionX);
            Vector3 pos = new Vector3(spawnPositionX, _spawnPoint.position.y, -1);
            // Vector3 pos = new Vector3(_spawnPoint.position.x, _spawnPoint.position.y, -1);
            var enemy = GameObject.Instantiate(_prefab, pos, Quaternion.identity);
            enemy.gameObject.AddComponent<UnitAdapter>();
            enemy.gameObject.layer = 9; // layer = 9 = enemy
            enemy.gameObject.AddComponent<SphereCollider>().radius = 0.35f;

            // enemy.gameObject.AddComponent<BoxCollider>().size = new Vector3(2, 2, 2);
            // enemy.gameObject.AddComponent<DestroySelfGO>()._timeToSelfdestruct = 9;
            return enemy;
        }
        public void InitUnit(T prefab, Transform transform)
        {
            _prefab = prefab; _spawnPoint = transform;
        }
    }
}
