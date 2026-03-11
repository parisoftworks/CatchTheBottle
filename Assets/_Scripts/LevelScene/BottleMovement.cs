using UnityEngine;

namespace _Scripts.LevelScene
{
    public class BottleMovement : MonoBehaviour
    {
        private float _bottleSpeed;
        private bool _markedToDestroy;

        private void OnEnable()
        {
            _bottleSpeed = DifficultyManager.GetDifficultyBottleSpeed(MainManager.BottlesCaught, GameplayManager.Instance.currentDifficulty);
            Debug.Log($"Spawning bottle with speed {_bottleSpeed}");
        }

        private void Update()
        {
            transform.Translate(Vector2.down * (_bottleSpeed * Time.deltaTime));

            if (transform.position.y < -4.5f && !_markedToDestroy)
            {
                MainManager.DestroyOneHealthBottle();
                PlayMissedBottleSound();
            }

            if (transform.position.y < -6f && _markedToDestroy)
            {
                gameObject.SetActive(false);
            }
        }

        private void PlayMissedBottleSound()
        {
            GetComponent<AudioSource>().Play();
            _markedToDestroy = true;
        }
    }
}