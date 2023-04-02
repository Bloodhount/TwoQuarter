using System;
using System.Collections;
using System.Collections.Generic;
using Asteroids.Factories;
using Facade;
using UnityEngine;
using static UnityEngine.Debug;

namespace Asteroids
{
    public sealed class GameManager : MonoBehaviour //, IObserver
    {
        // [SerializeField] UnitAsterFactory go;
        [SerializeField] AsteroidFactory<Unit> uGO;
        [SerializeField] Sprite goSprite;
        private int countCreateAsUn = 0;
        private UnitFactoryFacade unitFactoryFacade;
        private FacadeGenrationUnits facadeGenration;
        //==============================
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
            //EnemiesPool.instance.GetEnemy_1<Enemy>();
            //enemiesPoolService.GetEnemy_1<Enemy>();
            //EnemiesPoolService.GetEnemy_1<Enemy>();
            enemiesPoolService = EnemiesPool.Instance;//.GetEnemy_1<Enemy>();
            // EnemiesPool enemiesPool = new EnemiesPool();
            ServiceLocator.RegisterService<EnemiesPool>(enemiesPoolService);
            //  Log(ServiceLocator.GetService<EnemiesPool>());
        }
        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                // GameObject enemies = 
                // EnemiesPool.instance.GetEnemy_1<Enemy>(); // типа синглтон...

                // or use ServiceLocator
               // Log(ServiceLocator.GetService<EnemiesPool>());
                var enemies = ServiceLocator.GetService<EnemiesPool>();
               // Log(enemies);
                enemies.GetEnemy_1<Enemy>();
               // Log(ServiceLocator.GetService<EnemiesPool>());

                //.GetEnemy_1<Enemy>();
                // GameObject enemies = ServiceLocator.GetService<EnemiesPool>().GetEnemy_1<Enemy>();

                //if (enemies != null)
                //{
                // enemies.AddComponent
                //    //var temAmmunition = enemies.GetComponent<Rigidbody>();
                //    //temAmmunition.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                //}
            }
            unitFactoryFacade.NumButton1();
            unitFactoryFacade.NumButton2();
            unitFactoryFacade.NumButton3(gameObject);
            unitFactoryFacade.NumButton4(gameObject);
            //_______________________________________________
            if (Input.GetKeyDown(KeyCode.Alpha9))
            { // ДЗ_5. Урок 6. Структурные шаблоны. Task'a -5. Разделить создания объектов для игры Астероиды и обернуть их ФАСАДОМ 
                facadeGenration.Initialized();
            }
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                Debug.Log(" KeyCode (0)  <color=yellow>Log</color>");
                Debug.ClearDeveloperConsole();
            }
        }

        //private void NumButton1()
        //{
        //    if (Input.GetKeyDown(KeyCode.Alpha1))
        //    {
        //        Unit unit = StaticUnitFactory.CreateUnit(goSprite);
        //        unit.GetComponent<UnitAsterFactory>().TestUnitAdapter();
        //    }
        //}

        //private void NumButton2()
        //{
        //    if (Input.GetKeyDown(KeyCode.Alpha2))
        //    {
        //        countCreateAsUn++;
        //        var un = uGO.CreateAsUn();
        //        un.name = un.name + $" {countCreateAsUn}";
        //        Debug.Log(un.name);
        //        un.UnitAttack(transform.position, 3);
        //    }
        //}

        //private void NumButton3()
        //{
        //    if (Input.GetKeyDown(KeyCode.Alpha3))
        //    {
        //        countCreateAsUn++;
        //        var un = uGO.CreateAsUn();
        //        un.name = un.gameObject.name + $" {countCreateAsUn}";
        //        Log($"<color=yellow>{name}</color> . <color=red>{un.name}</color>");
        //        var unitAsterFactory1 = gameObject.GetComponent<UnitAsterFactory>();  // new UnitAsterFactory();
        //        if (un != null)
        //        {
        //            Log($" <color=red> {unitAsterFactory1.name}... </color>");
        //            unitAsterFactory1.TestUnitAdapter2(un, un.transform.position);
        //        }
        //        else
        //        {
        //            Log(" <color=red>obj is null </color>");
        //        }
        //    }
        //}

        //private void NumButton4()
        //{
        //    if (Input.GetKeyDown(KeyCode.Alpha4))
        //    {
        //        countCreateAsUn++;
        //        var un = uGO.CreateAsUn();
        //        un.name = un.gameObject.name + $" {countCreateAsUn}";
        //        Log($"<color=yellow>{name}</color> . <color=red>{un.name}</color>");
        //        var unitAsterFactory1 = gameObject.GetComponent<UnitAsterFactory>();
        //        if (un != null)
        //        {
        //            Log($" <color=red> {unitAsterFactory1.name}... </color>");
        //            unitAsterFactory1.TestUnitAdapter3(un);
        //        }
        //        else
        //        {
        //            Log(" <color=red>obj is null </color>");
        //        }
        //    }
        //}
    }

    //public sealed class UnitFactoryFacade
    //{
    //    [SerializeField] AsteroidFactory<Unit> uGO;
    //    [SerializeField] Sprite goSprite;
    //    private int countCreateAsUn = 0;
    //    private void NumButton1()
    //    {
    //        if (Input.GetKeyDown(KeyCode.Alpha1))
    //        {
    //            Unit unit = StaticUnitFactory.CreateUnit(goSprite);
    //            unit.GetComponent<UnitAsterFactory>().TestUnitAdapter();
    //        }
    //    }

    //    private void NumButton2(Transform transform)
    //    {
    //        if (Input.GetKeyDown(KeyCode.Alpha2))
    //        {
    //            countCreateAsUn++;
    //            var un = uGO.CreateAsUn();
    //            un.name = un.name + $" {countCreateAsUn}";
    //            Debug.Log(un.name);
    //            un.UnitAttack(transform.position, 3);
    //        }
    //    }

    //    private void NumButton3(GameObject enterGo)
    //    {
    //        if (Input.GetKeyDown(KeyCode.Alpha3))
    //        {
    //            countCreateAsUn++;
    //            var un = uGO.CreateAsUn();
    //            un.name = un.gameObject.name + $" {countCreateAsUn}";
    //            Log($"<color=yellow>{enterGo.name}</color> . <color=red>{un.name}</color>");
    //            var unitAsterFactory1 = enterGo.gameObject.GetComponent<UnitAsterFactory>();  // new UnitAsterFactory();
    //            if (un != null)
    //            {
    //                Log($" <color=red> {unitAsterFactory1.name}... </color>");
    //                unitAsterFactory1.TestUnitAdapter2(un, un.transform.position);
    //            }
    //            else
    //            {
    //                Log(" <color=red>obj is null </color>");
    //            }
    //        }
    //    }

    //    private void NumButton4(GameObject enterGo)
    //    {
    //        if (Input.GetKeyDown(KeyCode.Alpha4))
    //        {
    //            countCreateAsUn++;
    //            var un = uGO.CreateAsUn();
    //            un.name = un.gameObject.name + $" {countCreateAsUn}";
    //            Log($"<color=yellow>{enterGo.name}</color> . <color=red>{un.name}</color>");
    //            var unitAsterFactory1 = enterGo.gameObject.GetComponent<UnitAsterFactory>();
    //            if (un != null)
    //            {
    //                Log($" <color=red> {unitAsterFactory1.name}... </color>");
    //                unitAsterFactory1.TestUnitAdapter3(un);
    //            }
    //            else
    //            {
    //                Log(" <color=red>obj is null </color>");
    //            }
    //        }
    //    }
    //}
}
