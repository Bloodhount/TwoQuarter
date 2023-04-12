using UnityEngine;

namespace Adapter
{
    public interface IAttack
    {
        public void UniversalAttack();
        public void UniversalAttack(Vector3 position);
    }
}
