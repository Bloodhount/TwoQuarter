<<<<<<< HEAD
using System.Collections;
=======
using System;
using System.Collections;
using System.Collections.Generic;
>>>>>>> 5ba6a86a4c2a6219ca716ca62a822a543072ed69
using UnityEngine;

namespace ChainOfResponsibility
{
    public class MoveToPosition : GameHandler
    {
        [SerializeField] private Vector3 _positionToMove;
        [SerializeField] private float _speed;

        public override IGameHandler Handle()
        {
            StartCoroutine(StartMoving());
            return this;
        }
<<<<<<< HEAD
=======

>>>>>>> 5ba6a86a4c2a6219ca716ca62a822a543072ed69
        private IEnumerator StartMoving()
        {
            while ((transform.position - _positionToMove).sqrMagnitude > 0f)
            {
                transform.position = Vector2.MoveTowards(transform.position, _positionToMove, Time.deltaTime * _speed);
                yield return null;
            }
            base.Handle();
        }
    }
}
