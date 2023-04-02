using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Prototype
{
    public class PrototypeExample : MonoBehaviour
    {
        [SerializeField] private MyClonableObject _origin;

        [ContextMenu("TestPrototype")]
        private void TestPrototype()
        {
            Debug.Log(" PrototypeExample. void TestPrototype ");
        }

        [ContextMenu("TestInstantiate")]
        private void TestInstantiate()
        {
            var newObect = Instantiate(_origin);
            
        }
    }
}

