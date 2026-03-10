using UnityEngine;
using Random = UnityEngine.Random;

namespace _Scripts.LevelScene
{
    public class DifficultyManager : MonoBehaviour
    {
        public enum Difficulty
        {
            Easy,
            Medium,
            Hard
        }
        
        private struct DifficultySettings
        {
            public float StartSpeed;
            public float MaxSpeed;
            public float StartRespawn;
            public float MinRespawn;
            public float RampTarget;

            public DifficultySettings(
                float startSpeed,
                float maxSpeed,
                float startRespawn,
                float minRespawn,
                float rampTarget)
            {
                StartSpeed = startSpeed;
                MaxSpeed = maxSpeed;
                StartRespawn = startRespawn;
                MinRespawn = minRespawn;
                RampTarget = rampTarget;
            }
        }
        
        private static DifficultySettings SetDifficulty(Difficulty difficulty)
        {
            return difficulty switch
            {
                Difficulty.Easy => new DifficultySettings(
                    2.2f, 4.2f,
                    1.35f, 0.80f,
                    40f),

                Difficulty.Medium => new DifficultySettings(
                    2.8f, 5.4f,
                    1.10f, 0.60f,
                    35f),

                Difficulty.Hard => new DifficultySettings(
                    3.5f, 6.8f,
                    0.90f, 0.42f,
                    30f),

                _ => new DifficultySettings(
                    2.8f, 5.4f,
                    1.10f, 0.60f,
                    35f)
            };
        }
        
        public static float GetDifficultyBottleSpeed(float counter, Difficulty difficulty)
        {
            var settings = SetDifficulty(difficulty);
            var progress = Mathf.Clamp01(counter / settings.RampTarget);
            return Mathf.Lerp(settings.StartSpeed, settings.MaxSpeed, progress);
        }

        public static float GetDifficultyBottleRespawnTimer(float counter, Difficulty difficulty)
        {
            var settings = SetDifficulty(difficulty);
            var progress = Mathf.Clamp01(counter / settings.RampTarget);
            return Mathf.Lerp(settings.StartRespawn, settings.MinRespawn, progress);
        }
    }
}