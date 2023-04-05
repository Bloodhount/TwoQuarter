using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public sealed class PlayerPursuit : MonoBehaviour
    {
        [SerializeField] private float _speedMin = 1f;
        [SerializeField] private float _speedMax = 2f;

        private float randomSpeed;

        private Rigidbody _rigidbody;
        private Transform _playerTransform;

        void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
          //  if (_playerTransform != null)
          // {
                _playerTransform = FindObjectOfType<Player>().transform;
           // }
            randomSpeed = Random.Range(_speedMin, _speedMax);
        }

        void Update()
        {
            if (_playerTransform != null)
            {
                Vector3 toPlayer = (_playerTransform.position - transform.position).normalized;
                _rigidbody.AddForce((toPlayer) * randomSpeed, ForceMode.Acceleration);
            }
        }
    }
}
