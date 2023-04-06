using System.Collections;
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
