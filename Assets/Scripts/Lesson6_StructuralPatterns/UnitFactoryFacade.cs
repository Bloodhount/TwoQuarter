using System.Collections;
using System.Collections.Generic;
using Asteroids;
using Adapter;
using Asteroids.Factories;
using UnityEngine;
using static UnityEngine.Debug;

namespace Facade
{
    public sealed class UnitFactoryFacade
    {
        AsteroidFactory<Unit> uGO;
        Sprite goSprite;
        private int countCreateAsUn = 0;

        public UnitFactoryFacade(AsteroidFactory<Unit> unitGO, Sprite sprite, int count)
        {
            uGO = unitGO; goSprite = sprite; countCreateAsUn = count;
        }
        public void NumButton1()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Unit unit = StaticUnitFactory.CreateUnit(goSprite); // Log("");
                unit.GetComponent<UnitAsterFactory>().TestUnitAdapter(); // Break();
            }
        }

        public void NumButton2()
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                countCreateAsUn++;
                var un = uGO.CreateAsUn();
                un.name = un.name + $" {countCreateAsUn}";
                Log(un.name);
                un.UnitAttack(un.transform.position, 3);
            }
        }

        public void NumButton3(GameObject enterGo)
        {
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                countCreateAsUn++;
                var un = uGO.CreateAsUn();
                un.name = un.gameObject.name + $" {countCreateAsUn}";
                Log($"<color=yellow>{enterGo.name}</color> . <color=red>{un.name}</color>");
                var unitAsterFactory1 = enterGo.gameObject.GetComponent<UnitAsterFactory>();  // new UnitAsterFactory();
                if (un != null)
                {
                    Log($" <color=red> {unitAsterFactory1.name}... </color>");
                    unitAsterFactory1.TestUnitAdapter2(un, un.transform.position);
                }
                else
                {
                    Log(" <color=red>obj is null </color>");
                }
            }
        }

        public void NumButton4(GameObject enterGo)
        {
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                countCreateAsUn++;
                var un = uGO.CreateAsUn();
                un.name = un.gameObject.name + $" {countCreateAsUn}";
                Log($"<color=yellow>{enterGo.name}</color> . <color=red>{un.name}</color>");
                var unitAsterFactory1 = enterGo.gameObject.GetComponent<UnitAsterFactory>();
                if (un != null)
                {
                    Log($" <color=red> {unitAsterFactory1.name}... </color>");
                    unitAsterFactory1.TestUnitAdapter3(un);
                }
                else
                {
                    Log(" <color=red>obj is null </color>");
                }
            }
        }
    }
}
