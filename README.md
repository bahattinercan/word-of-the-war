# Word of the War

Word of the War is a 3D turn-based word-puzzle battle game prototype created in Unity. The core gameplay loop blends Wordle-style five-letter word guessing with 1v1 combat: the player types word guesses using an on-screen keyboard to reveal a hidden five-letter target word across up to six attempts. Guessing matching letters triggers player attacks that damage the opposing enemy, while guessing the exact word performs a lethal finisher attack to win the battle; conversely, failed guesses allow the enemy to counterattack, and failing to guess the word before attempts run out triggers an enemy finisher attack that defeats the player. This repository is a personal prototype and demo project, not a maintained product, with the last substantial work committed in 2023.

## Gameplay

- **Random Target Word Selection**: Selects a random five-letter target word from a serialized list and sanitizes Turkish characters (`Assets/Scripts/WordLists.cs`).
- **Letter Grid & Feedback Coloring**: Displays typed letters across a six-attempt grid and colors letter boxes green for exact placement, yellow for present letters, and gray for absent letters (`Assets/Scripts/WordController.cs`).
- **On-Screen Keyboard & Turn Progression**: Handles virtual keyboard input, backspace, row submission, evaluation delays, and layout toggling (`Assets/Scripts/KeyboardScript.cs`).
- **Player Combat Actions & Animation**: Plays attack and finisher animations, applies damage delays, plays audio clips, and triggers game over on defeat (`Assets/Scripts/Player.cs`).
- **Enemy Counter-Attacks & Finisher**: Executes normal counter-attacks on invalid guesses and a fatal finisher attack if the player exhausts all six attempts (`Assets/Scripts/Enemy.cs`).
- **Health Management**: Tracks player and enemy health pools and updates current values on UI sliders (`Assets/Scripts/HealthController.cs`).
- **Match State & Level Transitions**: Manages win/loss conditions, end-game delays, and scene reloading or transitions (`Assets/Scripts/GameController.cs`).
- **End-Game Overlay**: Displays the outcome banner ("Completed!" or "Try Again!") along with the revealed target word (`Assets/Scripts/EndGamePanel.cs`).
- **Audio & Result Music**: Plays distinct audio clips for victory and defeat upon game completion (`Assets/Scripts/MusicController.cs`).
- **UI Navigation**: Provides home navigation from gameplay back to the main menu (`Assets/Scripts/GameplayUI.cs`, `Assets/Scripts/MainMenu.cs`).
- **Frame Rate Cap**: Enforces a target frame rate of 60 FPS on startup (`Assets/Scripts/GameController.cs`, `Assets/Scripts/Options.cs`).

## Tech Stack

- **Engine**: Unity 2020.3.48f1 (`ProjectSettings/ProjectVersion.txt`)
- **Scripting Runtime**: C# (.NET Standard 2.0 / Unity Mono)
- **UI System**: Unity UI (uGUI) `com.unity.ugui` (1.0.0) and TextMesh Pro `com.unity.textmeshpro` (3.0.6)
- **Shaders / Rendering**: Unity Shader Graph `com.unity.shadergraph` (10.10.1) and custom toon shaders (`Assets/Packages/JMO Assets/Toony Colors`)
- **Device Simulator**: `com.unity.device-simulator` (3.0.3-preview)
- **Test Framework**: `com.unity.test-framework` (1.1.33) (declared in `Packages/manifest.json`, no test suites implemented)

## Project Structure

| Path | Description | Category |
| :--- | :--- | :--- |
| `Assets/Scripts/` | Game loop, word validation, combat controllers, and UI scripts | Own code |
| `Assets/Scenes/` | `MainMenu.unity` and `Gameplay.unity` scenes | Own data |
| `Assets/Models And Animations/` | 3D character models (Mixamo Ch03/Ch14) and FBX combat animations | Third-party / Data |
| `Assets/Materials/` | Surface and character materials | Own data |
| `Assets/Lighting/` | Lighting settings and environment skyboxes | Own data |
| `Assets/Sounds/` | Sound effects (sword hits, win/lose sounds) and background music | Third-party / Data |
| `Assets/Sprites/` | UI sprites and 2D button art | Own data |
| `Assets/Keyboard Package/` | Virtual on-screen keyboard scripts, prefabs, and demo scenes | Third-party |
| `Assets/Packages/JMO Assets/` | Toony Colors Free 2.0 toon shading package and demo | Third-party |
| `Assets/Packages/OSK/` | On-Screen Keyboard UI prefabs, art, and demo scenes | Third-party |
| `Assets/Packages/TextMesh Pro/` | TextMesh Pro font assets, emoji sprites, and resources | Third-party |
| `Assets/Packages/Unvik_3D/` | Woodland environment 3D models, textures, and prefabs | Third-party |
| `Packages/` | Unity Package Manager manifest defining dependencies | Configuration |
| `ProjectSettings/` | Unity project configurations, tags, layers, and build settings | Configuration |

## Running / Building

### Requirements
- Unity Editor version `2020.3.48f1` (as declared in `ProjectSettings/ProjectVersion.txt`).

### Steps
1. Install Unity Editor `2020.3.48f1` using the Unity Hub.
2. Open Unity Hub, click **Add**, and select the `word-of-the-war` directory.
3. Open the project in Unity 2020.3.48f1. Wait for asset importing and package resolution to complete.
4. Open the entry scene: `Assets/Scenes/MainMenu.unity` (configured as scene index 0 in `ProjectSettings/EditorBuildSettings.asset`).
5. Press the **Play** button in the Unity Editor toolbar to start the game, or click **Start** in the main menu to transition into `Assets/Scenes/Gameplay.unity`.
6. To build standalone binaries:
   - Navigate to **File > Build Settings...**.
   - Ensure `Assets/Scenes/MainMenu.unity` (index 0) and `Assets/Scenes/Gameplay.unity` (index 1) are included in the build list.
   - Choose the desired target platform (e.g., Windows Standalone or Android) and click **Build**.

## Repository Notes

- **Prototype Status**: This repository is a personal learning prototype developed in late 2023 to experiment with hybrid word-puzzle and turn-based combat gameplay.
- **Commit History**: Minimal four-commit linear history (`Initial commit`, `project`, `.`, `update`).
- **Tests**: No automated test suites are present in the repository despite `com.unity.test-framework` being listed in `Packages/manifest.json`.
- **CI / Automation**: No continuous integration workflows or build scripts exist (`.github/` is not present).
- **Verification Note**: Codebase functionality was analyzed purely through static file inspection; the project was not built or executed during this assessment.

## Third-Party Assets

- `Assets/Keyboard Package`: Virtual on-screen keyboard UI components, prefabs, and controller scripts. No separate license file present.
- `Assets/Packages/JMO Assets/Toony Colors`: Toony Colors Free v2.0 toon shader package by Jean Moreno. Contains `!ToonyColors Readme.txt`; no dedicated license file present.
- `Assets/Packages/OSK`: On-Screen Keyboard UI prefabs and layout assets. No separate license file present.
- `Assets/Packages/TextMesh Pro`: TextMesh Pro font assets and EmojiOne sprite sheet. Contains `EmojiOne Attribution.txt` (attributing EmojiOne); no separate license file present.
- `Assets/Packages/Unvik_3D/Woodland`: 3D low-poly woodland environment models and textures. No license file present.
- `Assets/Models And Animations`: Mixamo humanoid character meshes (`Ch03_nonPBR.fbx`, `Ch14_nonPBR.fbx`) and combat animation clips. No license file present.
