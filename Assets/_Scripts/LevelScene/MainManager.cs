using GoogleMobileAds.Api;
using GoogleMobileAds.Common;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Scripts.LevelScene
{
    public class MainManager : MonoBehaviour
    {
        private static MainManager _instance;
        private static int _bottlesLeftToBroke;
        public static int BottlesCaught;

        public TMP_Text scoreText;
        public Component gameOverUI;
        public Component gameUI;
        public TMP_Text gameOverCounter;
        private BannerView _bannerView;
        public GameObject topbar;

        public GameObject healthBar;
        public GameObject healthBarBottle;
        
        private static bool _gameOver;

        private void Awake()
        {
            _instance = this;
        }

        private void Start()
        {
            //MobileAdsEventExecutor.ExecuteInUpdate();
            
            MobileAds.Initialize(initializationStatus =>
            {
                if (initializationStatus == null)
                {
                    Debug.LogError("Google Mobile Ads initialization failed.");
                    return;
                }

                Debug.Log("Google Mobile Ads initialization complete.");
            });
            
            _bannerView = new BannerView("ca-app-pub-3940256099942544/6300978111", AdSize.Banner, AdPosition.Bottom);
            _bannerView.LoadAd(new AdRequest());
            
            BottlesCaught = 0;
            if (GameplayManager.Instance != null)
                _bottlesLeftToBroke = DifficultyManager.GetDifficultyBottlesLeft(GameplayManager.Instance.currentDifficulty);
            else
            {
                Debug.LogError("GameplayManager.Instance is null");
                SceneManager.LoadScene(0);
            }

            for (var i = 1; i <= _bottlesLeftToBroke; i++)
            {
                Instantiate(healthBarBottle, healthBar.transform);
                //Debug.Log("Bottle " + i + " created");
            }
            
            Time.timeScale = 1f;
            _gameOver = false;
        }

        private void Update()
        {
            scoreText.text = $"{BottlesCaught}";

            if (!_gameOver) return;
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
            if (_instance == null || _instance.healthBar == null)
                return;

            var healthBarTransform = _instance.healthBar.transform;

            if (healthBarTransform.childCount != 0)
                Destroy(healthBarTransform.GetChild(healthBarTransform.childCount - 1).gameObject);
            
            if(_bottlesLeftToBroke is not 0) _bottlesLeftToBroke--;
            else _gameOver = true;
        }
    }
}