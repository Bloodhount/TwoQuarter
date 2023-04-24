using UnityEngine;

public interface IRadiusAttack : IUnit
{
    public void DoAttack(Vector3 position, float radius);
}
