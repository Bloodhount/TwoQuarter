using System.Collections;
using System.Collections.Generic;
using Adapter;
using UnityEngine;
using static UnityEngine.Debug;

namespace Asteroids
{
    public class UnitAsterFactory : AsteroidFactory<Unit>
    {
        [SerializeField] private int AttackRadius = 1;

        //[ContextMenu("TestAdapter")]
        //public void TestAdapter()
        //{
        //    TestUnitAdapter();// Log($">{name}< . TestAdapter");
        //}
        private void TestUnitAdapter()
        {
            var unit = new Unit();
            // var enemyAdaptor = new UnitAdapter(unit, 5.5f);
            unit.gameObject.AddComponent<UnitAdapter>().UnitInit(unit, AttackRadius);

            var attackPos = unit.transform.position;
            // enemyAdaptor.UniversalAttack(attackPos);
            unit.GetComponent<UnitAdapter>().UniversalAttack(attackPos);
            Log($">name< . TestUnitAdapter . UniversalAttack({attackPos})");
        }
        public void TestUnitAdapter2(Unit unit, Vector3 pos)
        {
            unit.GetComponent<UnitAdapter>().UnitInit(unit, AttackRadius);
            // var enemyAdaptor = new UnitAdapter(unit: unit, r: 5.5f);
            unit.GetComponent<UnitAdapter>().UniversalAttack(pos);
            Log($">{name}< . <color=red> TestUnitAdapter 2 </color> . UniversalAttack({pos})");
        }
        public void TestUnitAdapter3(Unit unit)
        {
            Log($">{name}< . <color=red> TestUnitAdapter 3 </color> . UniversalAttack() <color=green>START</color>");
            unit.GetComponent<UnitAdapter>().UnitInit(unit, 1);
            var attackPos = new Vector3(1, 1, -1);
            unit.GetComponent<UnitAdapter>().UniversalAttack(attackPos);
            Log($">{name}< . <color=red> TestUnitAdapter 3 </color> . UniversalAttack() <color=green>STOP</color>");
        }
    }
}
