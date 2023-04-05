using System.Collections;
using System.Collections.Generic;
using Asteroids;
using UnityEngine;

namespace ChainOfResponsibility
{
    public class ChainOfResponsibilityExample : MonoBehaviour
    {
        [SerializeField] private List<GameHandler> _gamaHandlers;
        public void ChainOfResponsibilityExample1()
        {
            _gamaHandlers[0].Handle();
            for (int i = 0; i < _gamaHandlers.Count; i++)
            {
                _gamaHandlers[i - 1].SetNext(_gamaHandlers[i]);
            }
        }
        public void ChainOfResponsibilityExample2()
        {
            var enemy = new Enemy();

            var root = new EnemyModifier(enemy);
            root.Add(new AddAttackModifier(enemy,2));
            root.Add(new AddAttackModifier(enemy,5));
            root.Add(new AddDefenceModifier(enemy,20));
            root.Handle();
        }
    }
}
