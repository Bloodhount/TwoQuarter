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
            int random = Random.Range(-5, 5);
            for (int i = 0; i < _ObjectsAmount; i++)
            {
                _startPosition.position = new Vector3(random, random, -1);
                GameObject obj = Instantiate(_prefab, _startPosition.position, _startPosition.rotation);
                // obj.SetActive(false);
                _poolObjects.Add(obj);
            }
        }

        public GameObject Get()
        {
            for (int i = 0; i < _poolObjects.Count; i++)
            {
                if (!_poolObjects[i].activeInHierarchy)
                {
                    return _poolObjects[i];
                }
            }
            return null;
        }

        public void ReturnToPool(GameObject gameObject)
        {
            //gameObject.SetActive(false);
            //_poolObjects.Push(gameObject);
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
