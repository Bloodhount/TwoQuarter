using UnityEngine;

namespace Adapter
{
    public class UnitAdapter : MonoBehaviour, IAttack
    {
        IUnit _unit;
        float _radius;

        public void UnitInit(IUnit unit, float r)
        {
            _unit = unit;
            Debug.Log($" UnitAdapter. <color=green>UnitInit</color> ");
            _radius = r;
        }
        public void UniversalAttack(Vector3 position)
        {
            Debug.LogWarning($"><color=yellow>{gameObject.name}</color><  UnitAdapter. <color=red>UniversalAttack</color> ");
            _unit.UnitAttack(position, _radius);
        }
    }
}
