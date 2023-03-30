using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Adapter;

namespace Asteroids
{
    public class Enemy : MonoBehaviour, IEnemy, IAttack
    {
        //  [SerializeField] private Object _asteroid;

        [SerializeField] private GameObject _asteroidPrefab;
        [SerializeField] private Asteroid res;
        public EnemyHealth Health { get; private set; } // bad variant to use
        public void DependencyInjectHealth(EnemyHealth hp)
        {
            Health = hp;
        }

        [ContextMenu("Enemy.EnemyAttack")]
        public void EnemyAttack(Vector3 position, Vector3 direction)// TODO: some mandatory for enemies method
        {
            Debug.LogWarning("  TODO: remake inplementation interface IEnemy class Enemy  ");
        }
        [ContextMenu("Enemy.UniversalAttack")]
        public void UniversalAttack(Vector3 position)
        {
            Debug.LogWarning("  TODO: remake inplementation interface IAttack class Enemy  ");
        }
    }
}
