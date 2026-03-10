using UnityEngine;
using Random = UnityEngine.Random;

namespace _Scripts.LevelScene
{
    public class SpawnManager : MonoBehaviour
    {
        private static Vector2 _spawnPos;
        [SerializeField] private GameObject bottle;
        [SerializeField] private GameObject player;
        
        private void Start()
        {
            Invoke(nameof(SpawnBottle), 1f);
        }

        private void SpawnBottle()
        {
            _spawnPos = new Vector2(Random.Range(-1.7f, 1.7f), 7f);
            Instantiate(bottle, _spawnPos, Quaternion.identity);
            Invoke(nameof(SpawnBottle), DifficultyManager.GetDifficultyBottleRespawnTimer(MainManager.BottlesCaught));
        }
    }
}
