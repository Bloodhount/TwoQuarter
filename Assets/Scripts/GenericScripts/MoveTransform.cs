using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    internal class MoveTransform : IMove
    {
        private readonly Transform _transform;
        private readonly Rigidbody _playerRigidbody;

        private Vector3 _move;
        public float Speed { get; protected set; }
        public MoveTransform(Transform transform, float speed)
        {
            _transform = transform;
            Speed = speed;
        }
        public MoveTransform(Rigidbody body, float speed)
        {
            _playerRigidbody = body;
            Speed = speed;
        }
        public void Move(float horizontal, float vertical, float deltaTime)
        {
            var moveSpeed = deltaTime * Speed;
            _move.Set(horizontal * moveSpeed, vertical * moveSpeed, 0.0f);
            _transform.localPosition += _move;
        }

        public void Move(float horizontal, float vertical)
        {
            var moveSpeed = Speed;
            _move.Set(horizontal * moveSpeed, vertical * moveSpeed,0);
            _playerRigidbody.AddForce(_move ); 
        }

        public void Move()
        {
            Debug.Log(" MoveTransform. DoNothing ");
        }
    }
}
