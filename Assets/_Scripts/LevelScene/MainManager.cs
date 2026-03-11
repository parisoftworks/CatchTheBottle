using GoogleMobileAds.Api;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace _Scripts.LevelScene
{
    public class MainManager : MonoBehaviour
    {
        public static MainManager Instance;
        public static int BottlesLeftToBroke;
        public static int BottlesCaught;

        public TMP_Text scoreText;
        public Component gameOverUI;
        public Component gameUI;
        public TMP_Text gameOverCounter;
        private BannerView _bannerView;

        public GameObject healthbar;
        public GameObject healthbarBottle;
        public GameObject pauseBtn;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            MobileAds.Initialize(initializationStatus =>
            {
                if (initializationStatus == null)
                {
                    Debug.LogError("Google Mobile Ads initialization failed.");
                    return;
                }

                Debug.Log("Google Mobile Ads initialization complete.");
            });
            
            _bannerView = new BannerView("[YOUR_AD_UNIT_ID]", AdSize.Banner, AdPosition.Top);
            _bannerView.LoadAd(new AdRequest());
            
            BottlesCaught = 0;
            BottlesLeftToBroke = DifficultyManager.GetDifficultyBottlesLeft(GameplayManager.Instance.currentDifficulty);
            Debug.Log(BottlesLeftToBroke);

            for (var i = 1; i <= BottlesLeftToBroke; i++)
            {
                Instantiate(healthbarBottle, healthbar.transform);
                Debug.Log("Bottle " + i + " created");
            }
            
            Time.timeScale = 1f;
        }

        private void Update()
        {
            scoreText.text = $"{BottlesCaught}";

            if (BottlesLeftToBroke is not 0) return;
            Time.timeScale = 0f;
            gameUI.transform.gameObject.SetActive(false);
            gameOverUI.transform.gameObject.SetActive(true);
            gameOverCounter.text = $"Final Score: {BottlesCaught}";
        }

        public void PauseGame()
        {
            Time.timeScale = 0f;
        }
        
        public void ResumeGame()
        {
            Time.timeScale = 1f;
        }
        
        public void RestartGame()
        {
            SceneManager.LoadScene(1);
        }

        public void ExitToMenu()
        {
            SceneManager.LoadScene(0);
        }

        public static void DestroyOneHealthBottle()
        {
            if (Instance == null || Instance.healthbar == null)
                return;

            Transform healthbarTransform = Instance.healthbar.transform;

            if (healthbarTransform.childCount == 0)
                return;

            Destroy(healthbarTransform.GetChild(healthbarTransform.childCount - 1).gameObject);
            BottlesLeftToBroke--;
        }
    }
}