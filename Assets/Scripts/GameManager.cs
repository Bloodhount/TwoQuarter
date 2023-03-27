using System.Collections;
using System.Collections.Generic;
using Asteroids.Factories;
using UnityEngine;

namespace Asteroids
{
    public sealed class GameManager : MonoBehaviour
    {
        [SerializeField] UnitAsterFactory go;
        void Start()
        {
            // var un = go.CreateAsUn();
            // StaticUnitFactory.CreateUnit();
            #region TestRegion
            // StaticUnitFactory.CreateEnemy();
            // var unit_1 = StaticUnitFactory.CreateUnit();
            //Debug.Log(unit_1.name);


            //Enemy enemy_one = StaticUnitFactory.CreateEnemy();
            ////  Enemy enemy_one = StaticUnitFactory.CreateUnit();
            //// enemy_one.gameObject.AddComponent<EnemyHealth>();
            //enemy_one.CreateAsteroidEnemy();

            //IEnemyFactory asteroidfactory_one = new AsteroidFactory();
            //go = asteroidfactory_one.Create(new EnemyHealth());
            #endregion
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                StaticUnitFactory.CreateUnit();
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                var un = go.CreateAsUn();
            }
        }
    }
}
