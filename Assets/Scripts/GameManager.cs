using System;
using System.Collections;
using System.Collections.Generic;
using Asteroids.Factories;
using UnityEngine;
using static UnityEngine.Debug;

namespace Asteroids
{
    public sealed class GameManager : MonoBehaviour //, IObserver
    {
        [SerializeField] UnitAsterFactory go;
        [SerializeField] Sprite goSprite;
        private int countCreateAsUn = 0;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                StaticUnitFactory.CreateUnit(goSprite);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                countCreateAsUn++;
                var un = go.CreateAsUn();
                un.name = un.name + $" {countCreateAsUn}";
                Debug.Log(un.name);
                un.UnitAttack(transform.position, 3);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                // Log("KeyDown 3");
                countCreateAsUn++;
                var un = go.CreateAsUn();

                // un.Config(gameObject.name.ToString());
                un.name = un.gameObject.name + $" {countCreateAsUn}";
                Log($"<color=yellow>{name}</color> . <color=red>{un.name}</color>");
                var unitAsterFactory1 = new UnitAsterFactory();
                unitAsterFactory1.TestUnitAdapter2(un, un.gameObject.transform.position);
            }

            if (Input.GetKeyDown(KeyCode.Alpha0))
            {

                // Debug.LogAssertion(" KeyCode (0) <color=red> LogAssertion </color> ");
                Debug.Log(" KeyCode (0)  <color=yellow>Log</color>");
                Debug.ClearDeveloperConsole();
            }
        }
    }
}
