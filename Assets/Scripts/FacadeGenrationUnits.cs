using System.Collections;
using System.Collections.Generic;
using Asteroids.Factories;
using Prototype;
using Adapter;
using Asteroids;
using UnityEngine;

public class FacadeGenrationUnits : MonoBehaviour
{
    // ДЗ_5. Урок 6. Структурные шаблоны. Task'a -5. Разделить создания объектов для игры Астероиды и обернуть их ФАСАДОМ

    #region FactoryMethod
    FactoryMethod factoryMethod = new FactoryMethod(); 
        ClientEnemyFactory clientEnemyFactory = new ClientEnemyFactory();
        ServerEnemyFactory serverEnemyFactory = new ServerEnemyFactory();
        #endregion

        private static readonly Sprite someSprite1;
        //Unit staticUnit = StaticUnitFactory.CreateUnit(spriteTest: someSprite1);

        UnitFactory unitFactory = new UnitFactory();
        UnitAsterFactory unitAsterFactory = new UnitAsterFactory();
        AsteroidFactory<Unit> asteroidFactory = new AsteroidFactory<Unit>();

        #region Prototype
        PrototypeExample prototype = new PrototypeExample();
        #endregion

        #region Adapter
        EnemyAdapter enemyAdapter = new EnemyAdapter();
        UnitAdapter unitAdapter = new UnitAdapter();
    #endregion


    public void Initialized()
    {
        factoryMethod.ToString();
        clientEnemyFactory.GetEnemy();
        serverEnemyFactory.GetEnemy();
        Unit staticUnit = StaticUnitFactory.CreateUnit(spriteTest: someSprite1);
        unitFactory.CreateEnemy(EnemyType.Enemy);
        unitFactory.CreateEnemy(EnemyType.Enemy1);
        unitFactory.CreateEnemy(EnemyType.Enemy2);
        unitAsterFactory.GetType();
        asteroidFactory.ToString();
        prototype.ToString();
        enemyAdapter.UniversalAttack(transform.position);
        unitAdapter.UniversalAttack(transform.position);
    }


}
