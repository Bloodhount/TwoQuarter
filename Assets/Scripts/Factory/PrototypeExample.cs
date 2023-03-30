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

    //public class MyClonableObject : MonoBehaviour
    //{
    //    [SerializeField] private int _health;
    //    private static int _cloneCount = 0;
    //    public MyClonableObject Clone()
    //    {
    //        _cloneCount++;

    //        var newObject = new GameObject(name: $"{name} clone #{_cloneCount}");
    //        var myClonableObject = newObject.AddComponent<MyClonableObject>();

    //        if (gameObject.TryGetComponent<Rigidbody>(out var rigidbody))
    //        {
    //            var newRigidbody = newObject.AddComponent<Rigidbody>();
    //            newRigidbody.mass = rigidbody.mass;
    //        }
    //        if (gameObject.TryGetComponent<SpriteRenderer>(out var spriteRenderer))
    //        {
    //            var newSpriteRenderer = newObject.AddComponent<SpriteRenderer>();
    //            newSpriteRenderer.sprite = spriteRenderer.sprite;
    //        }

    //        // for example
    //        myClonableObject._health = _health;
    //        newObject.transform.position = transform.position + Vector3.right * _cloneCount;
    //        return myClonableObject;
    //    }
    //}
}

