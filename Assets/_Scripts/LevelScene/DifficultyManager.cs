using UnityEngine;

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
            public readonly float StartSpeed;
            public readonly float SpeedIncreasePerBottle;
            public readonly float StartRespawn;
            public readonly float RespawnDecreasePerBottle;
            public readonly float MinRespawn;
            public readonly int BottlesLeft;

            public DifficultySettings(
                float startSpeed,
                float speedIncreasePerBottle,
                float startRespawn,
                float respawnDecreasePerBottle,
                float minRespawn,
                int bottlesLeft)
            {
                StartSpeed = startSpeed;
                SpeedIncreasePerBottle = speedIncreasePerBottle;
                StartRespawn = startRespawn;
                RespawnDecreasePerBottle = respawnDecreasePerBottle;
                MinRespawn = minRespawn;
                BottlesLeft = bottlesLeft;
            }
        }
        
        private static DifficultySettings SetDifficulty(Difficulty difficulty)
        {
            return difficulty switch
            {
                Difficulty.Easy => new DifficultySettings(
                    3.2f, 0.08f,
                    1.00f, 0.012f,
                    0.45f, 8),

                Difficulty.Medium => new DifficultySettings(
                    4.3f, 0.11f,
                    0.80f, 0.016f,
                    0.30f, 5),

                Difficulty.Hard => new DifficultySettings(
                    5.5f, 0.15f,
                    0.65f, 0.020f,
                    0.20f, 3),

                _ => new DifficultySettings(
                    4.3f, 0.11f,
                    0.80f, 0.016f,
                    0.30f, 5)
            };
        }
        
        public static float GetDifficultyBottleSpeed(float counter, Difficulty difficulty)
        {
            var settings = SetDifficulty(difficulty);
            return settings.StartSpeed + counter * settings.SpeedIncreasePerBottle;
        }

        public static float GetDifficultyBottleRespawnTimer(float counter, Difficulty difficulty)
        {
            var settings = SetDifficulty(difficulty);
            return Mathf.Max(
                settings.MinRespawn,
                settings.StartRespawn - counter * settings.RespawnDecreasePerBottle);
        }

        public static int GetDifficultyBottlesLeft(Difficulty difficulty)
        {
            return SetDifficulty(difficulty).BottlesLeft;
        }
    }
}