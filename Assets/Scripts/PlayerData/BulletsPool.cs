using System;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class BulletsPool : MonoBehaviour, IDisposable
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private List<GameObject> _poolObjectsBase = new List<GameObject>();
        [SerializeField] private List<GameObject> _poolObjectsAlternative = new List<GameObject>();
        [SerializeField] private Sprite _view;
        private Transform _startShotPosition;

        [SerializeField] private int _bulletAmount = 10;

        public static BulletsPool _instance;
        public static BulletsPool Instance
        {
            get
            {
                if (!_instance)
                {
                    var singleton = new GameObject();
                    var bulletsPool = singleton.AddComponent<BulletsPool>();
                    _instance = bulletsPool;
                }
                return _instance;
            }
        }
        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this; // DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(this);
                return;
            }
        }
        private void Start()
        {
            _startShotPosition = GameObject.Find("StartShotPosition").transform;

            InstantiateBullet();
            TestBulletBuilder();
        }

        private void InstantiateBullet()
        {
            for (int i = 0; i < _bulletAmount; i++)
            {
                GameObject obj = Instantiate(_prefab, _startShotPosition.position, _startShotPosition.rotation);
                obj.SetActive(false);
                _poolObjectsBase.Add(obj);
            }
        }
        private void TestBulletBuilder()
        {
            for (int i = 0; i < _bulletAmount; i++)
            {
                var gameObjectBuilder = new BulletBuilder();
                GameObject buildResult = gameObjectBuilder
                .GetName("newBullet_" + i)
                .GetOrAddSprite(_view)
                .GetTransform(gameObject.transform, 1.2f)
                .GetOrAddRigidbody()
                .GetOrAddCollider()
                .GetOrAddComponentBullet();

                buildResult.SetActive(false);
                _poolObjectsAlternative.Add(buildResult);
            }
        }

        public GameObject GetBaseObjPool<T>(float shootForce)
        {
            for (int i = 0; i < _poolObjectsBase.Count; i++)
            {
                if (!_poolObjectsBase[i].activeInHierarchy)
                {
                    var temAmmunition = _poolObjectsBase[i].gameObject.GetComponent<Rigidbody>();
                    temAmmunition.transform.position = _startShotPosition.position;
                    temAmmunition.velocity = Vector3.zero;
                    temAmmunition.gameObject.SetActive(true);
                    temAmmunition.AddForce(_startShotPosition.up * shootForce);
                    temAmmunition.gameObject.GetComponent<Bullet>().StartDisasbleGOTimer();

                    return _poolObjectsBase[i];
                }
            }
            return null;
        }
        public GameObject GetAlternativeObjPool<T>(float shootForce)
        {
            for (int i = 0; i < _poolObjectsAlternative.Count; i++)
            {
                if (!_poolObjectsAlternative[i].activeInHierarchy)
                {
                    var temAmmunition = _poolObjectsAlternative[i].gameObject.GetComponent<Rigidbody>();
                    temAmmunition.transform.position = _startShotPosition.position;
                    temAmmunition.velocity = Vector3.zero;
                    temAmmunition.gameObject.SetActive(true);
                    temAmmunition.AddForce(_startShotPosition.up * shootForce);
                    temAmmunition.gameObject.GetComponent<Bullet>().StartDisasbleGOTimer();

                    return _poolObjectsAlternative[i];
                }
            }
            return null;
        }

        public void ReturnToPool(GameObject gameObject)
        {
            gameObject.SetActive(false);
            //_poolObjects.Push(gameObject);
        }
        public void Dispose()
        {
            foreach (var item in _poolObjectsBase)
            {
                GameObject.Destroy(item);
            }
            _poolObjectsBase.Clear();
        }
    }
}
