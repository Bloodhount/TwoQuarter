using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class DestroySelfGO : MonoBehaviour
    {
        [SerializeField] public int _timeToSelfdestruct = 1;
       // [SerializeField] private int _timeToSelfdestruct = 1;

        void Start()
        {
            Destroy(gameObject, _timeToSelfdestruct);
        }
    }
}
