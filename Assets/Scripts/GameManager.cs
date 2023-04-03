using System;
using System.Collections;
using System.Collections.Generic;
using Asteroids.Factories;
using Facade;
using UnityEngine;
using static UnityEngine.Debug;

namespace Asteroids
{
    public sealed class GameManager : MonoBehaviour
    {
        [SerializeField] AsteroidFactory<Unit> uGO;
        [SerializeField] Sprite goSprite;
        private int countCreateAsUn = 0;
        private UnitFactoryFacade unitFactoryFacade;
        private FacadeGenrationUnits facadeGenration;
        //==============================
        BulletsPool bulletsPoolService;
        EnemiesPool enemiesPoolService;
        //public EnemiesPool EnemiesPoolService
        //{
        //    get => enemiesPoolService;
        //    set => enemiesPoolService = value;
        //}
        //==============================
        private void Start()
        {
            unitFactoryFacade = new UnitFactoryFacade(uGO, goSprite, countCreateAsUn);

            enemiesPoolService = EnemiesPool.Instance;
            ServiceLocator.RegisterService<EnemiesPool>(enemiesPoolService);

            bulletsPoolService = BulletsPool.Instance;
            ServiceLocator.RegisterService<BulletsPool>(bulletsPoolService);

        }
        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                // EnemiesPool.instance.GetEnemy_1<Enemy>(); // ���� ��������...
                // or use ServiceLocator
                var enemies = ServiceLocator.GetService<EnemiesPool>();
                enemies.GetEnemy_1<Enemy>();

            }
            unitFactoryFacade.NumButton1();
            unitFactoryFacade.NumButton2();
            unitFactoryFacade.NumButton3(gameObject);
            unitFactoryFacade.NumButton4(gameObject);
            //_______________________________________________
            if (Input.GetKeyDown(KeyCode.Alpha9))
            { // ��_5. ���� 6. ����������� �������. Task'a -5. ��������� �������� �������� ��� ���� ��������� � �������� �� ������� 
                facadeGenration.Initialized();
            }
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                Debug.Log(" KeyCode (0)  <color=yellow>Log</color>");
                Debug.ClearDeveloperConsole();
            }
        }
    }
}
