using System;
using System.Collections;
using System.Collections.Generic;
using Adapter;
using UnityEngine;

namespace Asteroids
{
    public class Unit : MonoBehaviour,IUnit//,IAttack
    {

        private string _name = String.Empty;
        private string _Type = String.Empty;
        private EnemyHealth health;

        public void Config(string name)
        {
            _name = name;
            health = new EnemyHealth();
            _Type = GetType().ToString();
            // health.GetHP
        }

        public void CreateAsteroidUnit()
        {

        }

        public void UnitAttack(Vector3 position, float radius)
        {
            //Config(name);
            Debug.Log($" > {name} < class Unit <color=blue>UnitAttack</color>");
            Debug.LogWarning($" Unit . UnitAttack {position} , <color=green>{radius}</color>  ");
           // Debug.LogWarning("  TODO: remake inplementation interface IUnit class Unit ");
        }

        //public void UniversalAttack(Vector3 position)
        //{
        //    Debug.LogWarning("  TODO: remake inplementation interface IAttack class Unit ");
        //}
    }
}
