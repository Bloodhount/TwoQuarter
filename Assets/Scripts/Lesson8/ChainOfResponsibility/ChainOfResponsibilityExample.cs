using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.ChainOfResponsibility
{
    public class ChainOfResponsibilityExample : MonoBehaviour
    {
        [SerializeField] private List<GameHandler> _gameHandlers;

        [ContextMenu("ChainOfResponsibility_1")]
        public void ChainOfResponsibilityExampleMethod1()
        {
            _gameHandlers[0].Handle();
            for (int i = 0; i < _gameHandlers.Count; i++)
            {
                _gameHandlers[i].SetNext(_gameHandlers[i + 1]);
            }
        }
    }
}
