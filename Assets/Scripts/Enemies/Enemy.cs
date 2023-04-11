using Adapter;
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
        // TODO - pattern Bridge start ===========================================================
        private  IAttack _attack;
        private  IMove _move;
        public void EnemyInit(IAttack attack, IMove move)
        {
            _attack = attack;
            _move = move;
        }
        //public void Attack()
        //{
        //    _attack.Attack();
        //}
        public void Move()
        {
            _move.Move();
        }
        // ****** ****** ** ******* ****** * **************** ***** ****** ,
        // ***************** ..(new MagicalAttack(), new Infantry());
        public void EnemyAttack(Vector3 position, Vector3 direction)
        {
            Log($" _attack = {Attack}");
        }
        public void EnemyAttack(Vector3 position, Vector3 direction, int attack)
        {
            Attack += attack;
            Log($" _attack = {Attack}");
        }

        // TODO - pattern Bridge end ===========================================================
    }
}
/*
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
        // TODO - pattern Bridge start ===========================================================
        private  IAttack _attack;
        private  IMove _move;
        public void EnemyInit(IAttack attack, IMove move)
        {
            _attack = attack;
            _move = move;
        }
        //public void Attack()
        //{
        //    _attack.Attack();
        //}
        public void Move()
        {
            _move.Move();
        }
        // ****** ****** ** ******* ****** * **************** ***** ****** ,
        // ***************** ..(new MagicalAttack(), new Infantry());
        public void EnemyAttack(Vector3 position, Vector3 direction)
        {
            Log($" _attack = {Attack}");
        }
        public void EnemyAttack(Vector3 position, Vector3 direction, int attack)
        {
            Attack += attack;
            Log($" _attack = {Attack}");
        }

        // TODO - pattern Bridge end ===========================================================
    }
 */
