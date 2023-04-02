using UnityEngine;

namespace Asteroids.Factories
{
    public static class StaticUnitFactory
    {
        //[SerializeField] private Texture _texture;
        // TODO enemy: -> unit
        //public static Enemy CreateEnemy()
        //{
        //    return new Enemy();
        //}
        public static Unit CreateUnit(Sprite spriteTest) // CreateUnit()
        {
            var go = new GameObject();
            go.transform.position = new Vector3(0, 0, -1);
            go.name = "StaticUnitFactory. new Unit";
            var unit = go.AddComponent<Unit>();
            unit.Config("fafsfdsa");
            // var sprite111 = Resources.Load<Sprite>("Prefabs/asteroids01");
            go.AddComponent<SpriteRenderer>();
            go.GetComponentInChildren<SpriteRenderer>().sprite = spriteTest;

            go.AddComponent<DestroySelfGO>();
            go.GetComponent<DestroySelfGO>()._timeToSelfdestruct = 5;

            go.AddComponent<UnitAsterFactory>(); // .TestUnitAdapter3();
            go.GetComponent<UnitAsterFactory>().InitUnit(go.GetComponent<Unit>(), go.transform);
            // go.GetComponent<UnitAsterFactory>().TestUnitAdapter();

            // Debug.Log(" sprite111 = " + sprite111);            
            Debug.Log(unit.name);
            return unit;
        }
    }
}
