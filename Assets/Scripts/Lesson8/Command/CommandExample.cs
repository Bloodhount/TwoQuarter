using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Command
{
    public class CommandExample : MonoBehaviour
    {
        public InputHandler InputHandler;
        void Start()
        {
            Instantiate(InputHandler);
        }
    }
}
