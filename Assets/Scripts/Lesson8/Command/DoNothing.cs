using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Command
{
    public class DoNothing : ICommand
    {
        public bool Succeeded { get; private set; }

        public bool TryExecute()
        {
            Succeeded = true;
            return Succeeded;
        }

        public void Undo()
        {
        }
    }
}
