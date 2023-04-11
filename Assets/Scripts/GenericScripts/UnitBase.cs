using UnityEngine;

namespace Asteroids
{
    public abstract class UnitBase : MonoBehaviour
    {
        protected IUnit _unit;
        public IUnit Attack
        {
            set { _unit = value; }
        }

        public abstract void AttackReload();
        public virtual void DoAttack(Vector3 position, float radius)
        {
            Debug.Log($" abstract class UnitBase, <color=green>DoAttack</color>  ");
        }
    }
}