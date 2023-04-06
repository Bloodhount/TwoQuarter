using UnityEngine;

namespace ChainOfResponsibility
{
<<<<<<< HEAD
    public  class GameHandler : MonoBehaviour, IGameHandler
=======
    public abstract class GameHandler : MonoBehaviour, IGameHandler
>>>>>>> 5ba6a86a4c2a6219ca716ca62a822a543072ed69
    {
        private IGameHandler _nextHandler;

        public IGameHandler SetNext(IGameHandler handler)
        {
            _nextHandler = handler;
            return handler;
        }

        public virtual IGameHandler Handle()
        {
            if (_nextHandler != null)
            {
                _nextHandler.Handle();
            }
            return _nextHandler;
        }
    }
}