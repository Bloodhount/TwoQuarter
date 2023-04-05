using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Adapter;
using static UnityEngine.Debug;

namespace Asteroids
{
    public class Enemy : MonoBehaviour, IEnemy // , IAttack , IMove // for Bridge
    {
        public int Attack { get; set; } = 1;
        public int Defence { get; set; } = 10;

        [SerializeField] private GameObject _asteroidPrefab;
        public EnemyHealth Health { get; private set; } // Property is bad variant to use

        public void DependencyInjectHealth(EnemyHealth hp)
        {
            Health = hp;
        }

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
        }

        // TODO - pattern Bridge end ===========================================================
    }
}
