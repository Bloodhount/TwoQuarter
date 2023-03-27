using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class PlayerPursuit : MonoBehaviour
    {
        [SerializeField] private float _speedMin = 1f;
        [SerializeField] private float _speedMax = 2f;
        // [SerializeField] for tests
        private float randomSpeed;
        // [SerializeField] for tests
        private Rigidbody _rigidbody;
        // [SerializeField] for tests
        private Transform _playerTransform;

        void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _playerTransform = FindObjectOfType<Player>().transform;
            randomSpeed = Random.Range(_speedMin, _speedMax);
        }

        void Update()
        {
            Vector3 toPlayer = (_playerTransform.position - transform.position).normalized;
            _rigidbody.AddForce((toPlayer) * randomSpeed, ForceMode.Acceleration);
        }
    }
}
