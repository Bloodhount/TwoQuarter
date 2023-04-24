using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mediator.MVVM
{
    //public 
    class ViewModel : IViewModel
    {
        public IModel Model { get; }
        public event Action<int> OnScoreChanged;

        public ViewModel(IModel model)
        {
            Model = model;
        }
        public void AddScore(int scoreIncrement)
        {
            Model.Score += scoreIncrement;
            OnScoreChanged?.Invoke(Model.Score);
        }

    }
}
