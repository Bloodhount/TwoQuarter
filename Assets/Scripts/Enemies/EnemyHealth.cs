using Adapter;
using Interpreter;
using UnityEngine;
using static UnityEngine.Debug;

namespace Asteroids
{
    public class EnemyHealth : BaseHealth
    {
        [SerializeField] private int _scoreValue = 12550;
        [SerializeField] private int _health;
        [SerializeField] private int _maxHealth = 2;

        public GameObject HealthBarPrefab;
        [SerializeField] private Transform HealthBarPrefabRoot;
        private HealthBar _healthBar;
        private InterpreterScores interpreterScores;
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
        }
        public void TakeDamage(int damageValue)
        {
            _health -= damageValue; Log("TakeDamage");
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
            _healthBar.gameObject.SetActive(false); interpreterScores.Interpret(_scoreValue);
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
            TakeDamage(1);
            GetComponent<EnemyAdapter>().UniversalAttack(gameObject.transform.position);
        }
    }
}
