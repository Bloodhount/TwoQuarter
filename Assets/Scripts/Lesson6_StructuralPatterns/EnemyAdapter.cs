using Asteroids;
using UnityEngine;

namespace Adapter
{
    public class EnemyAdapter : MonoBehaviour, IAttack
    {
        IDirectedAttack enemy = new Enemy();
        public Vector3 Direction { get; set; }

        public void UniversalAttack(Vector3 position)
        {
            enemy.EnemyAttack(position, Direction); Debug.Log($" {name}. UniversalAttack");
        }
    }
}
