//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
namespace Asteroids
{

    public interface IMove //: MonoBehaviour
    {
        float Speed { get; }
        public void Move(float horizontal, float vertical, float deltaTime);
    }
}
