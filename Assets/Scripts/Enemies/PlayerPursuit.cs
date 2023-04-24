using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Asteroids
{
    public sealed class PlayerPursuit : MonoBehaviour
    {
        [SerializeField] private float _speedMin = 0.1f;
        [SerializeField] private float _speedMax = 0.2f;
        public float SpeedMin { get; private set; } = 0.2f;
        public float SpeedMax { get; private set; } = 0.3f;

        private float randomSpeed;

        private Rigidbody _rigidbody;
        private Transform _playerTransform;
        [SerializeField] private static TextMeshProUGUI _textGO;
        Rigidbody rigidbody;
        void Start()
        {
            _textGO = GameObject.Find("Text for tests (TMP)  (2)").gameObject.GetComponent<TextMeshProUGUI>();
            _textGO.text = $" {gameObject.name}";
            if (TryGetComponent(out Rigidbody rigidbodyComponent))
            {
                rigidbody = rigidbodyComponent;
            }

            _rigidbody = GetComponent<Rigidbody>();

            _playerTransform = FindObjectOfType<Player>().transform;

            SetRandomSpeed(_speedMin, _speedMax);
        }

        public void SetRandomSpeed(float speedMin, float speedMax)
        {
            SpeedMin = speedMin; SpeedMax = speedMax;
            randomSpeed = Random.Range(SpeedMin, SpeedMax);
        }

        void Update()
        {
            TextMessager.TextMessageUpdate(rigidbody.velocity.ToString());
            if (_playerTransform != null)
            {
                Vector3 toPlayer = (_playerTransform.position - transform.position).normalized;
                _rigidbody.AddForce((toPlayer) * randomSpeed, ForceMode.Acceleration);
            }
        }
    }
}
