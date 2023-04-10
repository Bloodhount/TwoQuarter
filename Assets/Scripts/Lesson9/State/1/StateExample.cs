using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace State
{
    public class StateExample : MonoBehaviour
    {
        [ContextMenu("Test Sate")]
        private void TestSate()
        {
            var contextShip = new ContextShip();

            var normalMove = new StateANormalMove();
            contextShip.SetState(normalMove);
            contextShip.SayCurrentMove();

            var damagedMove = new StateBDamagedMove();
            contextShip.SetState(damagedMove);
            contextShip.SayCurrentMove();
        }

        [ContextMenu("Test Inverse Sate")]
        void TestInverseSate()
        {
            var context = new ContextShip();

            var concreteStateA = new StateANormalMove();
            concreteStateA.Do(context);
            context.SayCurrentMove();

            var concreteStateB = new StateBDamagedMove();
            concreteStateB.Do(context);
            context.SayCurrentMove();
        }
    }
}
