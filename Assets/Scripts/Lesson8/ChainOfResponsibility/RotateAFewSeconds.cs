using System.Collections;
using UnityEngine;

namespace Asteroids.ChainOfResponsibility
{
    public class RotateAFewSeconds : GameHandler
    {
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _rotationDuration;

        public override IGameHandler Handle()
        {
            StartCoroutine(StartRotating());
            return this;
        }
        private IEnumerator StartRotating()
        {
            var t = 0.0f;
            while (t < _rotationDuration)
            {
                t += Time.deltaTime;
                transform.Rotate(Vector3.forward * (_rotationSpeed * Time.deltaTime));
                yield return null;
            }
            base.Handle();
        }
    }
}
