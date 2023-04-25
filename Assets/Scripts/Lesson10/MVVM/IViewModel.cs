using System;

namespace Mediator.MVVM
{
    public interface IViewModel
    {
        public IModel Model { get;  }
        public abstract event Action<int> OnScoreChanged; 
        public void AddScore(int score);
    }
}