using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Asteroids;

namespace ChainOfResponsibility
{
    public class ChainOfResponsibilityExample2 : MonoBehaviour
    {
        [SerializeField] private Enemy _enemy;

        [ContextMenu("ChainOfResponsibility_2")]
        public void ChainOfResponsibilityExampleMethod2()
        {
            var enemy = _enemy;
            //var enemy = new Enemy();

            var root = new EnemyModifier(enemy);
            root.Add(new AddAttackModifier(enemy, 1));
            root.Add(new AddAttackModifier(enemy, 2));
            root.Add(new AddDefenceModifier(enemy, 15));
            root.Handle();
        }
    }
}
