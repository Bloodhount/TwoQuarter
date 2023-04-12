using UnityEngine;

namespace Bridge
{
    public class AttackB : IAttack
    {
        public void UniversalAttack()
        {
            Debug.Log("namespace Bridge. class <color=yellow>Attack >B<</color>. UniversalAttack");
        }
        public void UniversalAttack(Vector3 position)
        {
            Debug.Log("namespace Bridge. class <color=yellow>Attack >B<</color>. UniversalAttack (Vector3 position)");
        }
    }
}
