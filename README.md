# Catch the Bottle!

A mobile arcade game built with Unity where players catch falling bottles using touch controls. The game features increasing difficulty, difficulty levels (Easy, Medium, Hard), and integration with Google Mobile Ads.

## 🛠 Tech Stack

- **Game Engine:** Unity 6000.3.9f1
- **Language:** C# 9.0
- **Scripting Backend:** IL2CPP (Android)
- **Render Pipeline:** Universal Render Pipeline (URP)
- **Input System:** New Unity Input System
- **Ads:** Google Mobile Ads SDK (AdMob)
- **UI:** TextMeshPro (TMP)

## 📋 Requirements

- **Unity Editor:** Version 6000.3.9f1 or later.
- **Platform:** Android (v21+ recommended).
- **External Tools:** Android NDK/SDK/JDK (handled by Unity Hub).

## 🚀 Setup & Installation

1.  **Clone the Repository:**
    ```bash
    git clone https://github.com/[username]/MobileTouchControls.git
    ```
2.  **Open in Unity:**
    - Open Unity Hub.
    - Click `Add` and select the project root folder.
    - Ensure you have the **Unity 6000.3.9f1** editor version installed.
3.  **Resolve Dependencies:**
    - The project uses the Google Mobile Ads SDK. If prompted, resolve dependencies using the `External Dependency Manager for Unity`.
4.  **AdMob Configuration:**
    - Go to `Assets > Google Mobile Ads > Settings`.
    - Add your App ID for Android.
    - *Note:* The current `GameplayManager.cs` contains a hardcoded Banner ID.

## 🎮 How to Play

- **Objective:** Catch as many bottles as possible before you run out of lives.
- **Controls:** Touch and drag (or tap) on the screen to move the player horizontally.
- **Difficulty:**
    - **Easy:** 15 lives, low speed.
    - **Medium:** 10 lives, moderate speed.
    - **Hard:** 5 lives, high speed.
    - Difficulty also scales as you catch more bottles.

## 📂 Project Structure

- `Assets/_Scripts/`: Main gameplay logic.
    - `GameplayManager.cs`: Handles game state, UI updates, and AdMob initialization.
    - `PlayerManager.cs`: Manages player movement via touch input and collision detection.
    - `SpawnManager.cs`: Controls bottle spawning logic and timing.
    - `DifficultyManager.cs`: Defines difficulty settings and scaling math.
    - `BottleMovement.cs`: Handles individual bottle behavior (movement, sound, destruction).
- `Assets/Scenes/`: Game scenes (Main gameplay).
- `ProjectSettings/`: Unity project configuration files.
- `Packages/`: Project dependency manifest.

## ⚙️ Scripts & Components

| Script | Responsibility |
| :--- | :--- |
| `GameplayManager` | Game loop, Score tracking, Lives, UI management, AdMob init. |
| `PlayerManager` | Touch input processing, Horizontal movement constraints. |
| `SpawnManager` | Periodic instantiation of bottle prefabs. |
| `DifficultyManager` | Speed and spawn rate calculations based on score. |
| `BottleMovement` | Constant downward movement and "miss" detection. |

## 🌐 Environment Variables & Config

- **AdMob App ID:** Managed in Unity Project Settings (`GoogleMobileAdsSettings.asset`).
- **Banner ID:** Hardcoded in `GameplayManager.cs` (TODO: Move to a configuration file or Inspector).

## 🧪 Tests

- **Unit Tests:** TODO: Add Unity Test Framework tests for difficulty scaling math.
- **Manual Testing:** Use Unity Device Simulator or deploy to an Android device.

## 📦 Building for Android

1.  Go to `File > Build Settings`.
2.  Switch platform to **Android**.
3.  Ensure `IL2CPP` is selected in `Player Settings` for optimized performance (required for AAB).
4.  Click `Build` or `Build and Run`.

## 📄 License

TODO: Add license information (e.g., MIT, GPL).

---
*Created by Michael (Junie Agent).*
