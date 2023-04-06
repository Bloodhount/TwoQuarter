using Adapter;
using UnityEngine;

namespace Asteroids.Factories
{
    public static class StaticUnitFactory
    {
        public static Unit CreateUnit(Sprite spriteTest)
        {
            var go = new GameObject();
            go.transform.position = new Vector3(0, 0, -1);
            go.name = "StaticUnitFactory. CreateUnit new Unit !";
            var unit = go.AddComponent<Unit>();
            unit.Config("fafsfdsa");
            go.AddComponent<SpriteRenderer>();
            go.GetComponentInChildren<SpriteRenderer>().sprite = spriteTest;

            go.AddComponent<DestroySelfGO>();
            go.GetComponent<DestroySelfGO>()._timeToSelfdestruct = 5;

            go.AddComponent<UnitAsterFactory>();
            go.GetComponent<UnitAsterFactory>().InitUnit(go.GetComponent<Unit>(), go.transform);

            go.AddComponent<UnitAdapter>();
            //go.GetComponent<UnitAdapter>().UniversalAttack(go.transform.position);

            Debug.Log(unit.name);
            return unit;
        }
    }
}
