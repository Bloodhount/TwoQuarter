using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class EnemiesPool : MonoBehaviour
    {
        public static EnemiesPool instance;
        [SerializeField] private List<GameObject> _poolObjects = new List<GameObject>();
        [SerializeField] private GameObject _prefab;

        [SerializeField] private Transform _startPosition;
        [SerializeField] private int _ObjectsAmount = 10;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }
        private void Start()
        {
            int random = Random.Range(-3, 6);
            for (int i = 0; i < _ObjectsAmount; i++)
            {
                GameObject obj = Instantiate(_prefab, _startPosition.position, _startPosition.rotation);
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

                    return _poolObjects[i];
                }
            }
            return null;
        }

        public void ReturnToPool(GameObject gameObject)
        {
            //gameObject.SetActive(false);
            //_poolObjects.Push(gameObject);
            // transform.SetParent(Enemy);
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
