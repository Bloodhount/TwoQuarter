using System;
using Asteroids.Adapter;
using Asteroids.Interpreter;
using Asteroids.Observer;
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
        public IHit hit;
        [SerializeField] public event Action<int, string> OnHitChange;

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
            hit = this;
            //  AddListenTo();
        }

        public void AddListenTo()
        {
            if (TryGetComponent(out ListenerHitShowDamage hitShowDamageComponent))
            {
                hitShowDamageComponent.Add(hit);
            }
        }

        public void TakeDamage(int damageValue)
        {
            _health -= damageValue;

            if (_health <= 0)
            {
                _health = 0;
                Die();
                if (TryGetComponent(out ListenerHitShowDamage hitShowDamageComponent))
                {
                    Log("TryGetComponent.Remove(");
                    hitShowDamageComponent.Remove(hit);
                }
            }
            _healthBar.SetHealth(_health, _maxHealth);

            if (OnHitChange != null)
            {
                OnHitChange.Invoke(damageValue, " Take Damage");
            }
            else
            {
                Log("TakeDamage. OnHitChange is empty ! ");

            }
        }
        public override void Die()
        {
            interpreterScores.Interpret((long)UnityEngine.Random.Range(_minScoreValue, _maxScoreValue));

            int getID = gameObject.GetInstanceID();
            if (getID != null)
            {
                Log(getID + " Die");
                if (OnHitChange != null)
                {
                    OnHitChange.Invoke(arg1: getID, arg2: " Die");
                }
                else
                {
                    Log("Die. OnHitChange is empty ! ");
                }
            }
            else
            {
                Log("Die.getID is empty ! ");
            }

            gameObject.SetActive(false);
            _healthBar.gameObject.SetActive(false);
        }
        public void ActivateHpBar()
        {
            _healthBar.gameObject.SetActive(true);
            _health = _maxHealth;
            _healthBar.SetHealth(_health, _maxHealth);
            // Log("ActivateHpBar");
        }
        private void OnCollisionEnter(Collision collision)
        {
            Log(collision.gameObject.name);
            if (TryGetComponent(out EnemyHealth enemyHealthComponent))
            {
                enemyHealthComponent.TakeDamage(DamageValue);
            }
            // GetComponent<EnemyAdapter>().UniversalAttack(gameObject.transform.position);
        }
    }
}
