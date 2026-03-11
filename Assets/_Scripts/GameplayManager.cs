using _Scripts.LevelScene;
using UnityEngine;
using UnityEngine.InputSystem;

namespace _Scripts
{
    public class GameplayManager : MonoBehaviour
    {
        public static GameplayManager Instance;
        
        public DifficultyManager.Difficulty currentDifficulty;
        
        [SerializeField] private float doubleTapTime = 0.4f;
        private InputAction _backAction;
        private float _lastBackPressTime;

        public Camera cam;
        public float leftX;
        public float rightX;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }
            
            Instance = this;
            DontDestroyOnLoad(gameObject);
            
            _backAction = new InputAction("Back", binding: "<Keyboard>/escape");
            
            // get screen bounds
            var worldHeight = cam.orthographicSize * 2f;
            var worldWidth = worldHeight * cam.aspect;
            leftX = (cam.transform.position.x - worldWidth / 2f) + 0.7f;
            rightX = (cam.transform.position.x + worldWidth / 2f) - 0.7f;
            
            Debug.Log($"leftX bound: {leftX}");
            Debug.Log($"rightX bound: {rightX}");
        }
        
        private void OnEnable()
        {
            _backAction.Enable();
            _backAction.performed += OnBackPressed;
        }

        private void OnDisable()
        {
            _backAction.performed -= OnBackPressed;
            _backAction.Disable();
        }

        private void OnBackPressed(InputAction.CallbackContext context)
        {
            if (Time.time - _lastBackPressTime <= doubleTapTime)
            {
                HideApplication();
            }
            else
            {
                _lastBackPressTime = Time.time;
                Debug.Log("Press back again to hide app");
            }
        }

        private static void HideApplication()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
        using var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        using var activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        activity.Call<bool>("moveTaskToBack", true);
#else
            Debug.Log("HideApplication works on Android device.");
#endif
        }
    }
}
