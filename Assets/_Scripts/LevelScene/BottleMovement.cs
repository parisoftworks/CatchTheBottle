using _Scripts.MainMenuScene;
using UnityEngine;

namespace _Scripts.LevelScene
{
    public class BottleMovement : MonoBehaviour
    {
        // Initialize variables
        private float _bottleSpeed;
        private bool _markedToDestroy;

        private void Start()
        {
            _bottleSpeed = DifficultyManager.GetDifficultyBottleSpeed(MainManager.BottlesCaught, GameplayManager.Instance.currentDifficulty);
            Debug.Log($"Spawning bottle with speed {_bottleSpeed}");
        }

        // Update is called once per frame
        private void Update()
        {
            transform.Translate(Vector2.down * (_bottleSpeed * Time.deltaTime));

            if (transform.position.y < -4.5f && !_markedToDestroy)
            {
                PlayMissedBottleSound();
            }

            if (transform.position.y < -6f && _markedToDestroy)
            {
                Destroy(gameObject);
            }
        }

        private void PlayMissedBottleSound()
        {
            GetComponent<AudioSource>().Play();
            MainManager.BottlesLeftToBroke--;
            _markedToDestroy = true;
        }
    }
}