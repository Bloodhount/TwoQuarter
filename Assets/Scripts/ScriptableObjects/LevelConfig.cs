using UnityEngine;

namespace Asteroids.Data
{
    [CreateAssetMenu(fileName = "LevelConfig", menuName = "Configs/LevelConfig")]
    public class LevelConfig : ScriptableObject
    {
        public string Name;
        public int NumUnitsToSpawn;
        public int UnitMinPositionToSpawn;
        public int UnitMaxPositionToSpawn;

    }
}
