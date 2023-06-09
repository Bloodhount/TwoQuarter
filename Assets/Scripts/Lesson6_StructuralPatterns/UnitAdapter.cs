using UnityEngine;

namespace Asteroids.Adapter
{
    public class UnitAdapter : MonoBehaviour, IAttack
    {
        IRadiusAttack _asteroid;
        float _radius;

        public void UnitInit(IRadiusAttack asteroid, float r)
        {
            _asteroid = asteroid;
            Debug.Log($" UnitAdapter. <color=green>UnitInit</color> ");
            _radius = r;
        }
        public void UniversalAttack(Vector3 position)
        {
            Debug.LogWarning($"><color=yellow>{gameObject.name}</color><  UnitAdapter. <color=red>UniversalAttack</color> ");
            _asteroid.DoAttack(position, _radius);
        }

        public void UniversalAttack()
        {
            Debug.Log($" UnitAdapter. <color=yellow>UniversalAttack for not args...</color> ");

        }
    }
}
