using UnityEngine;

namespace Asteroids.Adapter
{
    public class EnemyAdapter : MonoBehaviour, IAttack
    {
        IDirectedAttack enemy = new Enemy();
        public Vector3 Direction { get; set; }
        public void UniversalAttack()
        {
            Debug.Log($" {name}. UniversalAttack");
        }
        public void UniversalAttack(Vector3 position)
        {
            enemy.EnemyAttack(position, Direction); Debug.Log($" {name}. UniversalAttack");
        }
    }
}
