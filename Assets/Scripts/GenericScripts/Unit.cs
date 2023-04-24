using UnityEngine;

namespace Asteroids
{
    public class Unit : UnitBase, IRadiusAttack
    {
        private string _name = string.Empty;
        private string _Type = string.Empty;

        public Unit() { }
        public Unit(IUnit unit)
        {
            _unit = unit;
        }
        private EnemyHealth health;
        public void Config(string name)
        {
            _name = name;
            health = new EnemyHealth();
            _Type = GetType().ToString();
        }

        public override void DoAttack(Vector3 position, float radius)
        {
            Debug.Log($" class Unit, <color=yellow> GO:  {name} ,</color>" +
                $" UnitAttack {position} , <color=green>{radius}</color>  ");
        }

        public override void AttackReload()
        {
            Debug.Log($" class Unit, <color=yellow> {name} AttackReload  </color>");
        }
    }
}
