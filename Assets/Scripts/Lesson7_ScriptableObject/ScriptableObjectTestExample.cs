using UnityEngine;
using static UnityEngine.Debug;

namespace Data
{
    public class ScriptableObjectTestExample : MonoBehaviour
    {
        public GameConfig GameConfig;
        public LevelConfig LevelConfig;

        [ContextMenu("Print  Game  Difficulty")]
        private void PrintGameDifficulty()
        {
            Log($" . PrintGameDifficulty: {GameConfig.Difficulty} > ScriptableObjectTestExample ");
        }

        [ContextMenu("Print  Level  Name")]
        private void PrintLevelName()
        {
            Log($" . PrintLevelName: {LevelConfig.Name} > ScriptableObjectTestExample ");
        }

        [ContextMenu("Spawn  Unit")]
        private void SpawnUnit()
        {
            for (int i = 0; i < LevelConfig.NumUnitsToSpawn; i++)
            {
                Log($" ScriptableObjectTestExample . SpawnUnit: {GameConfig.Unit.name} ");

                var position = new Vector3(
                  x: Random.Range(LevelConfig.UnitMinPositionToSpawn, LevelConfig.UnitMaxPositionToSpawn),
                  y: Random.Range(LevelConfig.UnitMinPositionToSpawn, LevelConfig.UnitMaxPositionToSpawn),
                  z: -1);
                Instantiate(GameConfig.Unit, position, Quaternion.identity);
            }
        }
    }
}
