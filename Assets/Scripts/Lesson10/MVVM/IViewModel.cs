using System;

namespace Mediator.MVVM
{
    internal interface IViewModel
    {
        public IModel Model { get;  }
        public abstract event Action<int> OnScoreChanged; //{ get; set; }
        public void AddScore(int score);
    }
}