using UnityEngine;

namespace _Scripts
{
    public class GameplayManager : MonoBehaviour
    {
        public static GameplayManager Instance;

        public enum Difficulty
        {
            Easy,
            Medium,
            Hard
        }

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
