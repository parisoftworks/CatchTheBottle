using _Scripts.LevelScene;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Scripts.MainMenuScene
{
    public class MainMenuManager : MonoBehaviour
    {
        public GameObject mainMenuScreen;
        public GameObject settingsScreen;
        
        public void StartGame()
        {
            SceneManager.LoadScene(1);
        }

        public void Settings()
        {
            mainMenuScreen.SetActive(false);
            settingsScreen.SetActive(true);
        }

        public void QuitGame()
        {
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif
        }
        
        // Set difficulty
        public void SetDifficultyEasy()
        {
            GameplayManager.Instance.currentDifficulty = DifficultyManager.Difficulty.Easy;
            settingsScreen.SetActive(false);
            mainMenuScreen.SetActive(true);
        }
        public void SetDifficultyMedium()
        {
            GameplayManager.Instance.currentDifficulty = DifficultyManager.Difficulty.Medium;
            settingsScreen.SetActive(false);
            mainMenuScreen.SetActive(true);
        }
        public void SetDifficultyHard()
        {
            GameplayManager.Instance.currentDifficulty = DifficultyManager.Difficulty.Hard;
            settingsScreen.SetActive(false);
            mainMenuScreen.SetActive(true);
        }
    }
}
