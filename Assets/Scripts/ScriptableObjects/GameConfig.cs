using UnityEngine;

namespace Asteroids.Data
{
    [CreateAssetMenu(fileName = "GameConfig", menuName = "Configs/GameConfig")]
    public class GameConfig : ScriptableObject
    {
        public int Difficulty;
        public GameObject Unit;
       // public GameObject Enemy;
    }
}
