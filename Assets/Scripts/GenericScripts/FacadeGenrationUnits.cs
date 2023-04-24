using Asteroids.Factories;
using Asteroids.Prototype;
using Asteroids.Adapter;
using Asteroids;
using UnityEngine;

public class FacadeGenrationUnits : MonoBehaviour
{
    //  ���� 6. ����������� �������. Task - 5. ��������� �������� �������� ��� ���� ��������� � �������� �� �������

    #region GenerateMethods
    FactoryMethod factoryMethod = new FactoryMethod(); 
        ClientEnemyFactory clientEnemyFactory = new ClientEnemyFactory();
        ServerEnemyFactory serverEnemyFactory = new ServerEnemyFactory();
        #endregion

        private static readonly Sprite someSprite1;

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

}
