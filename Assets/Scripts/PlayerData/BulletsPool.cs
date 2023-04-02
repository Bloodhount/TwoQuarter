using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class BulletsPool : MonoBehaviour, IDisposable
    {
        public static BulletsPool instance;
        [SerializeField] private List<GameObject> _poolObjects = new List<GameObject>();
        //  [SerializeField] private Stack<GameObject> _poolObjects = new Stack<GameObject>();
        [SerializeField] private GameObject _prefab;

        [SerializeField] private Transform _startShotPosition;
        [SerializeField] private int _bulletAmount = 10;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
        }
        private void Start()
        {
            if (_startShotPosition != null)
            {
                _startShotPosition = FindObjectOfType<Player>().GetComponent<Transform>(); // transform;
                for (int i = 0; i < _bulletAmount; i++)
                {
                    // GameObject obj = Instantiate(_prefab);
                    GameObject obj = Instantiate(_prefab, _startShotPosition.position, _startShotPosition.rotation);
                    // (_bullet, _startShotPosition.position, _startShotPosition.rotation)
                    obj.SetActive(false);
                    _poolObjects.Add(obj);
                }
            }
        }
        //public BulletsPool(GameObject prefab, Transform startShotPosition, int initPrefabsCount)
        //{
        //    //_prefab = prefab;
        //    //_startShotPosition = startShotPosition;
        //    //for (int i = 0; i < initPrefabsCount; i++)
        //    //{
        //    //    Get();
        //    //}
        //    for (int i = 0; i < initPrefabsCount; i++)
        //    {
        //        GameObject obj = Instantiate(prefab);
        //        obj.SetActive(false);
        //        _poolObjects.Add(obj);
        //    }
        //}

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

            // GameObject result = (_poolObjects.Count == 0) ? GameObject.Instantiate(_prefab, _startShotPosition.position, _startShotPosition.rotation) : _poolObjects.Pop();
            // _prefab.gameObject.SetActive(true);
            // result.gameObject.SetActive(true);
            //  result.SetActive(true);
            // return result;
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
