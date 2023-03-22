using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class BulletsPool : IDisposable
    {
        private readonly Stack<GameObject> _poolObjects = new Stack<GameObject>();
        private readonly GameObject _prefab;
        private Transform _startShotPosition;
        public BulletsPool(GameObject prefab, Transform startShotPosition, int initPrefabsCount)
        {
            _prefab = prefab;
            _startShotPosition = startShotPosition;
            //for (int i = 0; i < initPrefabsCount; i++)
            //{
            //    Get();
            //}
        }

        public GameObject Get()
        {
            GameObject result = (_poolObjects.Count == 0) ? GameObject.Instantiate(_prefab, _startShotPosition.position, _startShotPosition.rotation) : _poolObjects.Pop();
            // _prefab.gameObject.SetActive(true);
            result.gameObject.SetActive(true);
            //  result.SetActive(true);
            return result;
        }

        public void ReturnToPool(GameObject gameObject)
        {
            //  gameObject.SetActive(false);

            _poolObjects.Push(gameObject);
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
