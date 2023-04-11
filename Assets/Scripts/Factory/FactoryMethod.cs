using System.Collections;
using System.Collections.Generic;
using Adapter;
using UnityEngine;

namespace Asteroids.Factories
{
    public class FactoryMethod
    {

    }
    /// <summary>
    /// Для наглядности все в одном файле
    /// </summary>
    public class FactoryMethodExample : MonoBehaviour
    {
        EnemyBaseFactory _enemyFactory = new ClientEnemyFactory();
        public void StartGame()
        {
            var enemy = _enemyFactory.GetEnemy();
        }

        EnemyBaseFactory _enemyFactoryServer = new ServerEnemyFactory();
        public void StartServerGame()
        {
            var enemy = _enemyFactoryServer.GetEnemy();
        }
    }
    public class ClientEnemyFactory : EnemyBaseFactory
    {
        private Transform _playerTransform;
        protected override IDirectedAttack CreateEnemy()
        {
            // TODO
            IDirectedAttack enemy = new Enemy();
            // use  some mandatory for interface IEnemy methods
            return enemy;
        }
    }
    public class ServerEnemyFactory : EnemyBaseFactory
    {
        protected override IDirectedAttack CreateEnemy()
        {
            // TODO
            IDirectedAttack enemy = new Enemy(); // not using view
            //  enemy.EnemyAttack();
            return enemy;
        }
    }
    public abstract class EnemyBaseFactory
    { // FactoryMethod
        public IDirectedAttack GetEnemy()
        {
            return CreateEnemy();
        }
        //public IAttack GetIAttack()
        //{
        //    IAttack enemy = new Enemy();
        //    return enemy;
        //}
        protected abstract IDirectedAttack CreateEnemy();

        #region other methods to do stuff with created enemies
        private void DoPrivateThingsWithEnemy(IDirectedAttack enemy)
        {

        }
        private void DoProtectedThingsWithEnemy(IDirectedAttack enemy)
        {

        }
        #endregion
    }
}
