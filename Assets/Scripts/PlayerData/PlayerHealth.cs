using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private int _hp;
        [SerializeField] private int _maxHp;
        private HealthBar _healthBar;
        public GameObject HealthBarPrefab;
        private void Start()
        {
            GameObject healthBar = Instantiate(HealthBarPrefab);
            _maxHp = _hp;
            _healthBar = healthBar.GetComponent<HealthBar>();
            _healthBar.Setup(transform);
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (_hp < 1)
            {
                Destroy(gameObject);
                if (_hp < 0)
                {
                    _hp = 0;
                }
            }
            else
            {
                _hp--;
            }
            _healthBar.SetHealth(_hp, _maxHp);
        }
    }
}
