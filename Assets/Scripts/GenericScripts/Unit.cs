using UnityEngine;

namespace Asteroids
{
    public class Unit : MonoBehaviour, IUnit 
    {
        private string _name = string.Empty;
        private string _Type = string.Empty;

        private EnemyHealth health;

        public void Config(string name)
        {
            _name = name;
            health = new EnemyHealth();
            _Type = GetType().ToString();
        }

        public void UnitAttack(Vector3 position, float radius)
        {
            Debug.Log($" class Unit, <color=yellow> GO:  {name} ,</color>" +
                $" UnitAttack {position} , <color=green>{radius}</color>  ");
        }

        //public void UniversalAttack(Vector3 position)
        //{
        //    Debug.LogWarning("  TODO: remake inplementation interface IAttack class Unit ");
        //}
    }
}
