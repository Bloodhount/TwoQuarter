using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.Factories
{
    public class UseFactory : MonoBehaviour
    {
        private UnitFactory _enemyFactory;

        #region Dependency injection

        public UnitFactory EnemyFactory
        {
            set => _enemyFactory = value;
        }

        public void SetEnemyFactory(UnitFactory enemyFactory)
        {
            _enemyFactory = enemyFactory;
        }

        #endregion

        private void StartGameWithFactories()
        {
            if (_enemyFactory == null) throw new Exception(" is not factory for ... ");

            var enemy = _enemyFactory.CreateEnemy();
            var enemyType2 = _enemyFactory.CreateEnemy(EnemyType.Enemy2);
        }
    }

    //================================================================
    public enum EnemyType // TODO: add/remake more type
    {
        Enemy,
        Enemy1,
        Enemy2
    }

    public enum UnitType  // TODO: add/remake more type
    {
        Unit = 1,
        Unit1 = 2,
        Unit2 = 3
    }
}
