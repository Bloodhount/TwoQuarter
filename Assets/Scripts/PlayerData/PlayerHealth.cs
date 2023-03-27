using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class PlayerHealth : MonoBehaviour
    {
        [SerializeField] private int _hp;
        [SerializeField] private int _maxHp = 3;
        [SerializeField] private Transform HealthBarPrefabRoot;
        private HealthBar _healthBar;
        public GameObject HealthBarPrefab;
        private void Awake()
        {
            GameObject healthBar = Instantiate(HealthBarPrefab, HealthBarPrefabRoot);
            _healthBar = healthBar.GetComponentInChildren<HealthBar>();
            _healthBar.Setup(gameObject.transform);
        }
        private void Start()
        {
            _hp = _maxHp;
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
