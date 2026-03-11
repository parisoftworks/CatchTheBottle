using UnityEngine;
using Random = UnityEngine.Random;

namespace _Scripts.LevelScene
{
    public class SpawnManager : MonoBehaviour
    {
        private static Vector2 _spawnPos;
        [SerializeField] private GameObject bottle;
        [SerializeField] private GameObject player;
        [SerializeField] private float minSpawnDistance = 0.8f;

        private float _lastSpawnX;
        private bool _hasSpawnedAtLeastOnce;
        
        private void Start()
        {
            Invoke(nameof(SpawnBottle), 1f);
        }

        private void SpawnBottle()
        {
            float randomX;

            do
            {
                randomX = Random.Range(GameplayManager.Instance.leftX, GameplayManager.Instance.rightX);
            }
            while (_hasSpawnedAtLeastOnce && Mathf.Abs(randomX - _lastSpawnX) < minSpawnDistance);

            _lastSpawnX = randomX;
            _hasSpawnedAtLeastOnce = true;

            _spawnPos = new Vector2(randomX, 7f);
            //Instantiate(bottle, _spawnPos, Quaternion.identity);
            GameObject bottle = ObjectPoolManager.SharedInstance.GetObjectFromPool();
            if (bottle != null)
            {
                bottle.transform.position = _spawnPos;
                bottle.SetActive(true);
            }

            Invoke(nameof(SpawnBottle), DifficultyManager.GetDifficultyBottleRespawnTimer(MainManager.BottlesCaught, GameplayManager.Instance.currentDifficulty));
        }
    }
}
