using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public sealed class Bullet : MonoBehaviour
    {
        [SerializeField] private float Timer = 2f;
        public void Start()
        {
            // StartCoroutine(StartTimer());
        }
        public void StartDisasbleGOTimer()
        {
            StartCoroutine(StartTimer());
        }
        public IEnumerator StartTimer()
        {
            for (float t = Timer; t > 0f; t -= Time.deltaTime)
            {
                yield return null;
            }
            gameObject.SetActive(false);
        }
        private void OnCollisionEnter(Collision collision)
        {
            gameObject.SetActive(false);
        }
    }
}
