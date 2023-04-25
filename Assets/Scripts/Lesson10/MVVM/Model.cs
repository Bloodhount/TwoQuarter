using System;

namespace Mediator.MVVM
{
    public class Model : IModel
    {
        public event Action Changed; // 2) переделать через интерфейс(обязать исп.контракт) 
        public string Name { get; }
        public int Score { get; set; }

        public Model(string name)
        {
            Name = name; ;
        }
    }
}
