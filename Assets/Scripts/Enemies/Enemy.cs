using UnityEngine;
using static UnityEngine.Debug;

namespace Asteroids
{
    public class Enemy : MonoBehaviour, IEnemy
    {
        public string Name;
        public int Attack;
        public int Defence;

        [SerializeField] private GameObject _asteroidPrefab;
        public EnemyHealth Health { get; private set; }

        public void DependencyInjectHealth(EnemyHealth hp)
        {
            Health = hp;
        }

        public void EnemyAttack(Vector3 position, Vector3 direction)
        {
            Log($" _attack = {Attack}");
        }
        public void EnemyAttack(Vector3 position, Vector3 direction, int attack)
        {
            Attack += attack;
            Log($" _attack = {Attack}");
        }
    }
}
