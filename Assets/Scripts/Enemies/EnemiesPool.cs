using System.Collections.Generic;
using Observer;
using Bridge;
using TMPro;
using UnityEngine;

namespace Asteroids
{
    public class EnemiesPool : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _poolObjects = new List<GameObject>();
        [SerializeField] private GameObject _prefab;
        [SerializeField] private Transform _startPosition;

        [SerializeField] private int _ObjectsAmount = 10;

        private static EnemiesPool _instance;
        public static EnemiesPool Instance
        {
            get
            {
                if (!_instance)
                {
                    var singleton = new GameObject();
                    var enemiesPool = singleton.AddComponent<EnemiesPool>();
                    _instance = enemiesPool;
                }
                return _instance;
            }
        }
        private void Awake()
        {
            if (_instance)
            {
                Destroy(this);
                return;
            }
            _instance = this; // DontDestroyOnLoad(this);
        }
        private void Start()
        {
            InitEnemiesPool();
        }
        private void InitEnemiesPool()
        {
            int random = Random.Range(-3, 6);
            for (int i = 0; i < _ObjectsAmount; i++)
            {
                _startPosition.position = new Vector3(random, random, -1);
                GameObject obj = Instantiate(_prefab, _startPosition.position, _startPosition.rotation);
                obj.SetActive(true);
                obj.name = obj.name + $"#{i + 1}";
                if (obj.TryGetComponent(out ListenerHitShowDamage showDamageComponent))
                {
                    showDamageComponent._EnemyHealthLabel = GameObject.Find("Text (TMP) total score (test) (1)").GetComponent<TextMeshProUGUI>();
                    showDamageComponent.Add(obj.GetComponent<EnemyHealth>());
                }
                _poolObjects.Add(obj);
            }
        }
        private void InitEnemiesPool(int enemyAmount, GameObject prefab, Transform spawnPos)
        {
            int random = Random.Range(-3, 6);
            for (int i = 0; i < enemyAmount; i++)
            {
                GameObject obj = Instantiate(prefab, spawnPos.position, spawnPos.rotation);
                obj.SetActive(true);
                _startPosition.position = new Vector3(random, random, -1);
                _poolObjects.Add(obj);
            }
        }

        public GameObject GetEnemy_1<T>() // you can pass values
        {
            for (int i = 0; i < _poolObjects.Count; i++)
            {
                if (!_poolObjects[i].activeInHierarchy)
                {
                    int random = Random.Range(-6, 6);
                    Vector3 _startVector = new Vector3(random, random, -1);

                    _poolObjects[i].SetActive(true);
                    _poolObjects[i].transform.position = _startVector;
                    _poolObjects[i].gameObject.GetComponent<EnemyHealth>().ActivateHpBar();
                    _poolObjects[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
                    if (_poolObjects[i].TryGetComponent(out ListenerHitShowDamage showDamageComponent))
                    {
                        showDamageComponent.Add(_poolObjects[i].GetComponent<EnemyHealth>().hit);
                    }
                    if (_poolObjects[i].TryGetComponent(out Enemy enemyComponent))
                    {
                        ///* 
                        enemyComponent.EnemyInit(new AttackA(), new MoveWalk());

                        enemyComponent.Move();
                        enemyComponent.EnemyAttack();
                        //*/

                        /*
                      // или для теста, выбрать
                      enemyComponent.EnemyInit(new AttackB(), new MoveRun());

                      enemyComponent.Move();
                      enemyComponent.EnemyAttack();
                      */
                    }
                    return _poolObjects[i];
                }
            }
            return null;
        }

        public void ReturnToPool(GameObject gameObject)
        {
            gameObject.SetActive(false);
        }
        public void Dispose()
        {
            foreach (var item in _poolObjects)
            {
                GameObject.Destroy(item);
            }
            _poolObjects.Clear();
        }
    }
}
