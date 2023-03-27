using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public class Unit : MonoBehaviour,IUnit
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
    }
}
