using Adapter;
using Bridge;
using UnityEngine;
using static UnityEngine.Debug;

namespace Asteroids
{
    public class Enemy : MonoBehaviour, IDirectedAttack
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

        private IAttack _attack;
        private IMove _move;
        public void EnemyInit(IAttack attack, IMove move)
        {
            _attack = attack;
            _move = move;
        }


        public void Move()
        {
            _move.Move();
        }
        public void EnemyAttack()
        {
            Log($" _attack = {Attack}");

            _attack.UniversalAttack();
        }
        public void EnemyAttack(Vector3 position, Vector3 direction)
        {
            Log($" _attack = {Attack}");
            _attack.UniversalAttack(gameObject.transform.position);
        }
        public void EnemyAttack(Vector3 position, Vector3 direction, int attack)
        {
            Attack += attack;
            Log($" _attack = {Attack}");
        }
    }
}

