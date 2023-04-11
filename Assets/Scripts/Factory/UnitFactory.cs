using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.Factories
{
    public class UnitFactory 
    {
        // TODO enemy: -> unit
        public Enemy CreateEnemy()
        {
            return new Enemy();
        }

        // public Enemy CreateEnemy(EnemyType enemyType)  create as class
        public IDirectedAttack CreateEnemy(EnemyType enemyType)  // create as interface with needed methods/contracts
        {
            switch (enemyType)
            {
                case EnemyType.Enemy:
                    return new Enemy();

                case EnemyType.Enemy1:
                    return new Enemy();

                case EnemyType.Enemy2:
                    return new Enemy();

                default:  // TODO
                    return new Enemy();
            }
        }
    }
}
