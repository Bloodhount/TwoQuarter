using System.Collections;
using System.Collections.Generic;
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
        protected override IEnemy CreateEnemy()
        {
            IEnemy enemy = new Enemy();
            enemy.Attack();
            return enemy;
        }
    }
    public class ServerEnemyFactory : EnemyBaseFactory
    {
        protected override IEnemy CreateEnemy()
        {
            IEnemy enemy = new Enemy(); // not using view
            enemy.Attack();
            return enemy;
        }
    }
    public abstract class EnemyBaseFactory
    { // FactoryMethod
        public IEnemy GetEnemy()
        {
            return CreateEnemy();
        }
        protected abstract IEnemy CreateEnemy();

        #region other methods to do stuff with created enemies
        private void DoPrivateThingsWithEnemy(IEnemy enemy)
        {

        }
        private void DoProtectedThingsWithEnemy(IEnemy enemy)
        {

        }
        #endregion
    }
}
