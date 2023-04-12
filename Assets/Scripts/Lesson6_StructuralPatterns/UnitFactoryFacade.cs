using Asteroids.Adapter;
using Asteroids;
using Asteroids.Factories;
using UnityEngine;
using static UnityEngine.Debug;

namespace Facade
{
    public sealed class UnitFactoryFacade
    {
        AsteroidFactory<Unit> unitGO;
        Sprite goSprite;
        private int countCreateAsUn = 0;

        public UnitFactoryFacade(AsteroidFactory<Unit> unitGO, Sprite sprite, int count)
        {
            this.unitGO = unitGO; goSprite = sprite; countCreateAsUn = count;
        }
        public void NumButton1()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                GameObject unitGO = StaticUnitFactory.CreateUnit(goSprite);

                if (unitGO.gameObject.TryGetComponent(out UnitAdapter unitAdapter))
                {
                    IRadiusAttack _unit = null;
                    if (unitGO.gameObject.TryGetComponent(out Unit unitComponent))
                    {
                        _unit = unitComponent;

                        _unit.DoAttack(unitGO.transform.position, 2);
                        Log($"<color=yellow> IAsteroid <color=red>_unit</color> =  unit </color> " +
                            $"<color=red>_unit.UnitAttack</color><color=green>" +
                            $"(go.position<color=white>{unitGO.transform.position}</color>, radius attack:...</color>");
                    }

                    unitAdapter.UnitInit(_unit, 2);
                    unitAdapter.UniversalAttack(unitGO.transform.position);
                    unitAdapter.UniversalAttack(unitGO.transform.position);
                    Log($"<color=yellow> ... <color=red>unitAdapter</color> ... </color> " +
                        $"<color=red>UniversalAttack</color><color=green>" +
                        $"(go.position<color=white>{unitGO.transform.position}</color>, radius attack:...</color>");
                }
            }
        }

        public void NumButton2()
        {
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                countCreateAsUn++;
                var un = unitGO.CreateAsUn();
                if (un != null)
                {
                    un.name = un.name + $" {countCreateAsUn}";
                    Log(un.name);
                    un.DoAttack(un.transform.position, 3);
                }
            }
        }

        public void NumButton3(GameObject enterGo)
        {
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                countCreateAsUn++;
                var un = unitGO.CreateAsUn();
                un.name = un.gameObject.name + $" {countCreateAsUn}";
                var unitAsterFactory1 = enterGo.gameObject.GetComponent<UnitAsterFactory>();
                if (un != null)
                {
                    unitAsterFactory1.TestUnitAdapter2(un, un.transform.position);
                }

            }
        }

        public void NumButton4(GameObject enterGo)
        {
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                countCreateAsUn++;
                var un = unitGO.CreateAsUn();
                un.name = un.gameObject.name + $" {countCreateAsUn}";
                if (enterGo.TryGetComponent(out UnitAsterFactory unitAsterFactory))
                {
                    unitAsterFactory.TestUnitAdapter3(un);
                }
            }
        }
    }
}
