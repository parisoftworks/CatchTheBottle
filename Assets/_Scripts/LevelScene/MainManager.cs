using GoogleMobileAds.Api;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Scripts.LevelScene
{
    public class MainManager : MonoBehaviour
    {
        public static int BottlesLeftToBroke;
        public static int BottlesCaught;
        public TMP_Text scoreText;
        public TMP_Text livesText;
        public Component gameOverUI;
        public Component gameUI;
        public TMP_Text gameOverCounter;
        private static bool _enabled;
        private BannerView _bannerView;
        
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
            
            _bannerView = new BannerView("ca-app-pub-1816072728463177~9330230804", AdSize.Banner, AdPosition.Top);
            _bannerView.LoadAd(new AdRequest());
            
            BottlesCaught = 0;
            _enabled = false;
        }

        private void Update()
        {
            if (!_enabled) return;
            scoreText.text = $"Score: {BottlesCaught}";
            livesText.text = $"Bottles left: {BottlesLeftToBroke}";

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
    }
}
