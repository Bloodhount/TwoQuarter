using System.Collections;
using System.Collections.Generic;
using Asteroids;
using UnityEngine;

namespace Adapter
{
    public class EnemyAdapter : MonoBehaviour, IAttack
    {
        IEnemy enemy = new Enemy();
        public Vector3 Direction { get; set; }

        public void UniversalAttack(Vector3 position)
        {
            enemy.EnemyAttack(position, Direction);
        }
    }
}