using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mediator.MVVM
{
    public class Model : IModel
    {
        public string Name { get; }
        public int Score { get; set; }

        public Model(string name)
        {
            Name = name; ;
        }
    }
}
