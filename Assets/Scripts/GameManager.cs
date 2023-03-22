using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public sealed class GameManager : MonoBehaviour
    {
        //[SerializeField] private Transform _startShotPosition;
        //[SerializeField] private int InitPrefabsCount = 3;
        //[SerializeField] private BulletsPool _bulletsPool;

        //public void Init(GameObject pooledGameObject)
        //{
        //    _bulletsPool = new BulletsPool(pooledGameObject,_startShotPosition, InitPrefabsCount);
        //}
        void Start()
        {
            //Enemy enemy = new Enemy();
            //enemy. CreateAsteroidEnemy(new Asteroid());

            // Enemy.CreateAsteroidEnemy(new EnemyHealth());
            //IEnemyFactory factory = new AsteroidFactory();
            //factory.Create(new EnemyHealth());

            //var obj = _bulletsPool.Get();
            //_bulletsPool.ReturnToPool(obj);
        }
        //private void OnDestroy()
        //{
        //    _bulletsPool.Dispose();
        //}
    }
}
