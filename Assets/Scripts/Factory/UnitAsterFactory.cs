using System.Collections;
using System.Collections.Generic;
using Adapter;
using UnityEngine;
using static UnityEngine.Debug;

namespace Asteroids
{
    public class UnitAsterFactory : AsteroidFactory<Unit>
    {

        [ContextMenu("TestAdapter")]
        public void TestAdapter()
        {
            TestUnitAdapter();// Log($">{name}< . TestAdapter");
        }

        private void TestUnitAdapter()
        {
            var unit = new Unit();
            var enemyAdaptor = new UnitAdapter(unit, 5.5f);
            // var attackPos = unit.transform.position; Log(attackPos);
            var attackPos = new Vector3(1, 1, -1);
            enemyAdaptor.UniversalAttack(attackPos);
            Log($">name< . TestUnitAdapter . UniversalAttack({attackPos})");
        }
        public void TestUnitAdapter2(Unit unit,Vector3 pos)
        {
            var enemyAdaptor = new UnitAdapter(unit, 5.5f);
            // var attackPos = unit.transform.position; Log(attackPos);
            // var attackPos = new Vector3(1, 1, -1);
            Log($">{name}< . TestUnitAdapter 2 . UniversalAttack({pos})");
            enemyAdaptor.UniversalAttack(pos);
        }
    }
}
