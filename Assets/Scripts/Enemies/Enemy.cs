using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Adapter;
using static UnityEngine.Debug;

namespace Asteroids
{
    public class Enemy : MonoBehaviour, IEnemy // , IAttack , IMove // for Bridge
    {
<<<<<<< HEAD
        public string Name;
        public int Attack;
        public int Defence;
        // [field: SerializeField] public int Attack { get; set; } = 1;
        // public int Defence { get; set; } = 10;

        [SerializeField] private GameObject _asteroidPrefab;
        public EnemyHealth Health { get; private set; }
=======
        public int Attack { get; set; } = 1;
        public int Defence { get; set; } = 10;

        [SerializeField] private GameObject _asteroidPrefab;
        public EnemyHealth Health { get; private set; } // Property is bad variant to use
>>>>>>> 5ba6a86a4c2a6219ca716ca62a822a543072ed69

        public void DependencyInjectHealth(EnemyHealth hp)
        {
            Health = hp;
        }

<<<<<<< HEAD
        //private void Start()
        //{
        //    InvokeRepeating(nameof(EnemyAttack), 1, 1);
        //}
=======
>>>>>>> 5ba6a86a4c2a6219ca716ca62a822a543072ed69
        // TODO - pattern Bridge start ===========================================================

        //private readonly IAttack _attack;
        //private readonly IMove _move;
        //public Enemy(IAttack attack, IMove move)
        //{
        //    _attack = attack;
        //    _move = move;
        //}
        //public void Attack()
        //{
        //    _attack.Attack();
        //}
        //public void Move()
        //{
        //    _move.Move();
        //}

        // пример вызова из другого класса и имплементировать новые методы , там где нужно или здесь ..(new MagicalAttack(), new Infantry());

        //  public class UnitFactory 
        //  public class ClientEnemyFactory : EnemyBaseFactory
        //{
        //    private void Start()
        //    {
        //        var enemy = new Enemy(new MagicalAttack(), new Infantry());
        //    }
        //}

<<<<<<< HEAD
        public void EnemyAttack(Vector3 position, Vector3 direction)
        {
            Log($" _attack = {Attack}");
        }
        public void EnemyAttack(Vector3 position, Vector3 direction, int attack)
        {
            Attack += attack;
            Log($" _attack = {Attack}");
=======
        public void EnemyAttack(Vector3 position, Vector3 direction)// TODO: some mandatory for enemies method
        {
            Log($" _attack = {Attack}");
            LogWarning("  TODO: remake inplementation interface IEnemy class Enemy  ");
        }
        public void EnemyAttack(Vector3 position, Vector3 direction, int attack)// TODO: some mandatory for enemies method
        {
            Attack += attack;
            Log($" _attack = {Attack}");
            LogWarning("  TODO: remake inplementation interface IEnemy class Enemy  ");
>>>>>>> 5ba6a86a4c2a6219ca716ca62a822a543072ed69
        }

        // TODO - pattern Bridge end ===========================================================
    }
}
