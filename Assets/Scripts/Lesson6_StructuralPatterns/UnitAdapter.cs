using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Adapter
{
    public class UnitAdapter : MonoBehaviour, IAttack
    {
        IUnit _unit;
        float _radius;
        //public UnitAdapter(IUnit unit, float r)
        //{
        //    _unit = unit;
        //    _radius = r;
        //}
        public void UnitInit(IUnit unit, float r)
        {
            _unit = unit;
            _radius = r;
        }
        public void UniversalAttack(Vector3 position)
        {
            Debug.LogWarning($">{gameObject.name}<  UnitAdapter. <color=red>UniversalAttack</color> ");
            _unit.UnitAttack(position, _radius);
        }
    }
}
