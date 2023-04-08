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
            //var unitComponent = unit.GetComponent<UnitAdapter>();
            //if (unitComponent != null)
            //{
            //    unitComponent.UnitInit(unit, AttackRadius);
            //    unitComponent.UniversalAttack(pos);
            //}
            // or
            if (unit.TryGetComponent(out UnitAdapter unitAdapter))
            {
                unitAdapter.UnitInit(unit, AttackRadius);
                unitAdapter.UniversalAttack(pos);
            }
        }
        public void TestUnitAdapter3(Unit unit)
        {
            // unit.GetComponent<UnitAdapter>().UnitInit(unit, 1);
            // var attackPos = new Vector3(1, 1, -1);
            // unit.GetComponent<UnitAdapter>().UniversalAttack(attackPos);
            // or
            if (unit.TryGetComponent(out UnitAdapter unitAdapter))
            {
                var attackPos = new Vector3(1, 1, -1);
                unitAdapter.UnitInit(unit, AttackRadius);
                unitAdapter.UniversalAttack(attackPos);
            }
        }
    }
}
