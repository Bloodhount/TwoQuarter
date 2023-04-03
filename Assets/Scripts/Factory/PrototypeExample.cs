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
            var newObject = _origin.Clone();
            var newObjectCasted = (MyClonableObject)newObject;
            Debug.Log(" PrototypeExample. void TestPrototype . newObjectCasted.name = " + newObjectCasted);
        }

        [ContextMenu("TestInstantiate")]
        private void TestInstantiate()
        {
            var newObect = Instantiate(_origin);
            
        }
    }
}

