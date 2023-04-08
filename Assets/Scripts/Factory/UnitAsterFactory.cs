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

        public Unit TestUnitAdapter()
        {
            var unit = new Unit();
            const int staticAttackRadius = 1;
            Log($"{gameObject.transform.position} ");
            return unit;
        }
        public void TestUnitAdapter2(Unit unit, Vector3 pos)
        {
            unit.GetComponent<UnitAdapter>().UnitInit(unit, AttackRadius);
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
