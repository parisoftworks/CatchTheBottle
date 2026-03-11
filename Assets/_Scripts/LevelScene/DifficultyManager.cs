using UnityEngine;

namespace _Scripts.LevelScene
{
    public class DifficultyManager : MonoBehaviour
    {
        public enum Difficulty
        {
            Easy,
            Medium,
            Hard,
            Expert
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
                    2.4f, 0.05f,
                    1.20f, 0.008f,
                    0.65f, 10),

                Difficulty.Medium => new DifficultySettings(
                    3.1f, 0.07f,
                    1.00f, 0.010f,
                    0.50f, 6),

                Difficulty.Hard => new DifficultySettings(
                    3.9f, 0.10f,
                    0.85f, 0.013f,
                    0.35f, 3),

                Difficulty.Expert => new DifficultySettings(
                    4.5f, 0.12f,
                    0.70f, 0.015f,
                    0.20f, 1),

                _ => new DifficultySettings(
                    3.1f, 0.07f,
                    1.00f, 0.010f,
                    0.50f, 6)
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