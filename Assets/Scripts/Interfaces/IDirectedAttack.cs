using UnityEngine;

public interface IDirectedAttack : IUnit
{
    public void EnemyAttack(Vector3 pos, Vector3 dir);
}
