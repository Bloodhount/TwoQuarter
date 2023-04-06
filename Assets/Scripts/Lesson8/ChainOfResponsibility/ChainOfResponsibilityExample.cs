using System.Collections;
using System.Collections.Generic;
<<<<<<< HEAD
=======
using Asteroids;
>>>>>>> 5ba6a86a4c2a6219ca716ca62a822a543072ed69
using UnityEngine;

namespace ChainOfResponsibility
{
    public class ChainOfResponsibilityExample : MonoBehaviour
    {
<<<<<<< HEAD
        [SerializeField] private List<GameHandler> _gameHandlers;

        [ContextMenu("ChainOfResponsibility_1")]
        public void ChainOfResponsibilityExampleMethod1()
        {
            _gameHandlers[0].Handle();
            for (int i = 0; i < _gameHandlers.Count; i++)
            {
                // _gameHandlers[i].SetNext(_gameHandlers[i - 1]);
                // _gameHandlers[i - 1].SetNext(_gameHandlers[i]);
                _gameHandlers[i].SetNext(_gameHandlers[i + 1]);
            }
        }
=======
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
>>>>>>> 5ba6a86a4c2a6219ca716ca62a822a543072ed69
    }
}
