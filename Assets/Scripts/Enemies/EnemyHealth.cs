using System;
using Adapter;
using Interpreter;
using Observer;
using UnityEngine;
using static UnityEngine.Debug;

namespace Asteroids
{
    public class EnemyHealth : BaseHealth, IHit
    {
        public int DamageValue { get; } = 1;
        [SerializeField] private long _minScoreValue = 33;
        [SerializeField] private long _maxScoreValue = 3333;
        [SerializeField] private int _health;
        [SerializeField] private int _maxHealth = 2;

        public GameObject HealthBarPrefab;
        [SerializeField] private Transform HealthBarPrefabRoot;
        private HealthBar _healthBar;
        private InterpreterScores interpreterScores;
        // ListenerHitShowDamage listenerHitShowDamage;
        IHit hit;
        [SerializeField] public event Action<int> OnHitChange;

        private void Awake()
        {
            GameObject healthBar = Instantiate(HealthBarPrefab, HealthBarPrefabRoot);
            _healthBar = healthBar.GetComponentInChildren<HealthBar>();
            _healthBar.Setup(gameObject.transform);
        }
        private void Start()
        {
            interpreterScores = FindObjectOfType<InterpreterScores>();
            _health = _maxHealth;
            // listenerHitShowDamage = new ListenerHitShowDamage();
            // listenerHitShowDamage._EnemyHealthLabel
            hit = this;
            AddListenTo();
            // listenerHitShowDamage.Add(this);
        }

        public void AddListenTo()
        {
            if (TryGetComponent(out ListenerHitShowDamage hitShowDamageComponent))
            {
                hitShowDamageComponent.Add(hit);
                // listenerHitShowDamage.Add(hit);
            }
        }

        public void TakeDamage(int damageValue)
        {
            _health -= damageValue;
            Log("TakeDamage");
            // hit.OnHitChange.
            OnHitChange.Invoke(damageValue);
            if (_health <= 0)
            {
                _health = 0;
                Die();
            }
            _healthBar.SetHealth(_health, _maxHealth);
        }
        public override void Die()
        {
            gameObject.SetActive(false);
            _healthBar.gameObject.SetActive(false);
            interpreterScores.Interpret((long)UnityEngine.Random.Range(_minScoreValue, _maxScoreValue));
            if (TryGetComponent(out ListenerHitShowDamage hitShowDamageComponent))
            {
                hitShowDamageComponent.Remove(hit);
                // listenerHitShowDamage.Add(hit);
            }
            // listenerHitShowDamage.Remove(this);
        }
        public void ActivateHpBar()
        {
            _healthBar.gameObject.SetActive(true);
            _health = _maxHealth;
            _healthBar.SetHealth(_health, _maxHealth);
            Log("ActivateHpBar");
        }
        private void OnCollisionEnter(Collision collision)
        {
            TakeDamage(DamageValue);
            GetComponent<EnemyAdapter>().UniversalAttack(gameObject.transform.position);
        }
        //void IHit.Hit(float damage)
        //{
        //    OnHitChange.Invoke(damage);
        //}
    }
}
