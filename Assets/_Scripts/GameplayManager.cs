using _Scripts.LevelScene;
using UnityEngine;

namespace _Scripts
{
    public class GameplayManager : MonoBehaviour
    {
        public static GameplayManager Instance;
        
        public DifficultyManager.Difficulty currentDifficulty;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }
            
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}
