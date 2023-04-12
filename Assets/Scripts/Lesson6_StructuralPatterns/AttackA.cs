using UnityEngine;
using Adapter;

namespace Bridge
{
    public class AttackA : IAttack
    {
        public void UniversalAttack()
        {
            Debug.Log("namespace Bridge. class <color=green>Attack >A<</color>. UniversalAttack");
        }
        public void UniversalAttack(Vector3 position)
        {
            Debug.Log("namespace Bridge. class <color=green>Attack >A<</color>. UniversalAttack(Vector3 position)");
        }
    }
}
