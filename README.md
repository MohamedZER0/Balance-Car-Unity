# 🚗 Balance Car Runner - Unity Endless Runner Game

A 2D physics-based endless runner mobile game built with Unity. Navigate challenging terrain, manage your fuel, collect coins, and survive as long as possible!

![Unity](https://img.shields.io/badge/Unity-2017.1.0f3+-black?logo=unity)
![Platform](https://img.shields.io/badge/Platform-Android-green?logo=android)
![License](https://img.shields.io/badge/License-MIT-blue)

---

## 📋 Table of Contents

- [Features](#features)
- [Game Mechanics](#game-mechanics)
- [Project Structure](#project-structure)
- [Setup Instructions](#setup-instructions)
- [Building for Android](#building-for-android)
- [Scripts Documentation](#scripts-documentation)
- [Google Play Store Submission](#google-play-store-submission)
- [Monetization](#monetization)
- [Contributing](#contributing)
- [License](#license)

---

## ✨ Features

### Core Gameplay
- **Endless Runner Mechanics** - Procedurally generated obstacles and collectibles
- **Fuel Management System** - Strategic gameplay requiring fuel pickups
- **Score System** - Distance-based scoring with coin bonuses
- **Physics-Based Vehicle** - Realistic 2D wheel physics using Unity's WheelJoint2D
- **Progressive Difficulty** - Game gets harder as you survive longer

### Technical Features
- **Singleton Managers** - Clean architecture with GameManager, UIManager, AudioManager
- **Object Pooling** - Optimized spawning system for better performance
- **Mobile-Optimized** - Touch controls with Android support
- **Ad Integration Ready** - Google AdMob placeholder implementation
- **Audio System** - Complete sound effects and background music system
- **Save System** - High score persistence using PlayerPrefs

### UI/UX
- **Main Menu** - Clean interface with high score display
- **Gameplay HUD** - Real-time score, distance, and fuel meter
- **Game Over Screen** - Final stats with restart/continue options
- **Pause Menu** - Mid-game pause functionality
- **Settings Panel** - Volume controls and vibration toggle

---

## 🎮 Game Mechanics

### Controls

**Desktop (Unity Editor):**
- **Arrow Up/W** - Accelerate
- **Arrow Down/S** - Brake/Reverse
- **Arrow Left/A** - Rotate counterclockwise
- **Arrow Right/D** - Rotate clockwise

**Mobile (Android):**
- **Touch Buttons** - On-screen controls for movement and rotation
- **Responsive UI** - Optimized for touchscreen gameplay

### Fuel System
- Fuel depletes over time at a constant rate
- Fuel pickups restore 30% of max fuel
- Game over when fuel reaches 0%
- Fuel bar changes color: Green (>50%), Yellow (25-50%), Red (<25%)

### Scoring
- **Distance:** 10 points per second survived
- **Coins:** 100 points each
- **Checkpoints:** 500 points each
- **Fuel Pickups:** 50 points each

### Difficulty Progression
- Difficulty increases every 30 seconds
- Max difficulty: 3x
- Affects obstacle spawn rate and spacing

---

## 📁 Project Structure

```
Balance-Car-Unity/
│
├── Assets/
│   ├── Scenes/
│   │   └── Main.unity              # Main game scene
│   │
│   ├── Scripts/
│   │   ├── GameManager.cs          # Core game logic and state management
│   │   ├── UIManager.cs            # All UI handling
│   │   ├── AudioManager.cs         # Sound effects and music
│   │   ├── GoogleAdsManager.cs     # AdMob integration (placeholder)
│   │   │
│   │   ├── CarController.cs        # Vehicle physics and controls
│   │   ├── CameraController.cs     # Camera following player
│   │   ├── TouchControllers.cs     # Mobile touch input
│   │   │
│   │   ├── ObstacleSpawner.cs      # Procedural level generation
│   │   ├── FuelPickup.cs           # Fuel collectible
│   │   ├── CoinPickup.cs           # Coin collectible
│   │   ├── Goal.cs                 # Checkpoint system
│   │   ├── EndGame.cs              # Death/collision handler
│   │   │
│   │   └── BackgroundAudio.cs      # Persistent background music
│   │
│   ├── Prefabs/                    # Game object prefabs
│   ├── Materials/                  # 2D materials and physics materials
│   ├── Sprites/                    # 2D graphics and UI sprites
│   └── Audio/                      # Sound effects and music files
│
├── Documentation/
│   ├── ANDROID_BUILD_GUIDE.md      # Complete Android build guide
│   ├── GOOGLE_PLAY_SUBMISSION.md   # Play Store submission guide
│   ├── PRIVACY_POLICY_TEMPLATE.md  # Privacy policy template
│   ├── SCRIPT_DOCUMENTATION.md     # Detailed script documentation
│   └── ASSET_REQUIREMENTS.md       # Required assets and specifications
│
├── README.md                       # This file
└── .gitignore                      # Git ignore rules
```

---

## 🚀 Setup Instructions

### Prerequisites
- Unity 2017.1.0f3 or newer (Recommended: Unity 2021 LTS+)
- Android SDK and NDK (for Android builds)
- JDK 8 or higher
- Git

### Installation

1. **Clone the repository:**
   ```bash
   git clone https://github.com/MohamedZER0/Balance-Car-Unity.git
   cd Balance-Car-Unity
   ```

2. **Open in Unity:**
   - Open Unity Hub
   - Click "Add" and select the project folder
   - Open the project

3. **Setup Scene:**
   - Open `Assets/Scenes/Main.unity`
   - Create required GameObjects:
     - GameManager (empty GameObject with GameManager.cs)
     - UIManager (Canvas with UIManager.cs)
     - AudioManager (empty GameObject with AudioManager.cs)
     - ObstacleSpawner (empty GameObject with ObstacleSpawner.cs)

4. **Assign References:**
   - In UIManager: Assign all UI panel and text references
   - In ObstacleSpawner: Assign prefabs for obstacles, coins, and fuel
   - In GameManager: Adjust fuel and score settings as needed

5. **Configure Touch Controls:**
   - Create UI buttons for mobile controls
   - Assign TouchControllers methods to button onClick events

### Required Tags
Create these tags in Unity (Edit > Project Settings > Tags and Layers):
- `Player` - For the car GameObject
- `Collidable` - For deadly obstacles

---

## 📱 Building for Android

See detailed guide: [Documentation/ANDROID_BUILD_GUIDE.md](Documentation/ANDROID_BUILD_GUIDE.md)

### Quick Build Steps:

1. **Switch Platform:**
   - File > Build Settings > Android > Switch Platform

2. **Player Settings:**
   ```
   Package Name: com.yourcompany.balancecar
   Minimum API: Android 5.1 (API 22)
   Target API: Automatic (highest)
   Scripting Backend: IL2CPP
   Target Architectures: ARM64 ✓, ARMv7 ✓
   ```

3. **Build:**
   - Check "Build App Bundle (Google Play)"
   - Click Build
   - Save as .aab file

---

## 📚 Scripts Documentation

### Core Managers

#### **GameManager.cs**
Singleton that manages overall game state, score, fuel, and difficulty.

**Key Methods:**
- `StartGame()` - Initializes new game session
- `GameOver()` - Ends game and shows results
- `AddScore(int points)` - Adds to current score
- `AddFuel(float amount)` - Restores fuel
- `GetDifficulty()` - Returns current difficulty multiplier

#### **UIManager.cs**
Handles all UI panels, buttons, and visual updates.

**Key Methods:**
- `ShowMainMenu()` - Displays main menu
- `ShowGameUI()` - Shows gameplay HUD
- `ShowGameOver()` - Displays game over screen
- `UpdateScore()` / `UpdateFuel()` - Updates HUD elements

#### **AudioManager.cs**
Manages all game audio including music and SFX.

**Key Methods:**
- `PlayBackgroundMusic()` - Starts background music
- `PlaySFX(AudioClip)` - Plays sound effect
- `SetMusicVolume()` / `SetSFXVolume()` - Volume control
- `Vibrate()` - Triggers haptic feedback (mobile)

### Gameplay Scripts

#### **CarController.cs**
Controls vehicle physics, wheel motors, and torque-based rotation.

**Key Features:**
- WheelJoint2D motor control
- Platform-specific input (#if UNITY_STANDALONE)
- Public API for touch controls
- Null safety checks

#### **ObstacleSpawner.cs**
Procedurally generates obstacles, coins, and fuel pickups.

**Key Features:**
- Object pooling for performance
- Distance-based spawning/despawning
- Difficulty-based spawn rates
- Configurable spawn chances

#### **FuelPickup.cs / CoinPickup.cs**
Collectible items that add fuel/score when touched by player.

**Key Features:**
- Trigger-based collision
- Visual rotation animation
- Particle effects on collection
- Sound effect integration

### Ad Integration

#### **GoogleAdsManager.cs**
Placeholder implementation for Google AdMob ads.

**Supported Ad Types:**
- Banner Ads (bottom of screen)
- Interstitial Ads (game over)
- Rewarded Video Ads (continue after death)

**Setup Required:**
1. Import Google Mobile Ads Unity Plugin
2. Replace test ad unit IDs with your own
3. Uncomment SDK-specific code sections
4. Configure GDPR consent (for EU)

See detailed comments in script for integration steps.

---

## 🏪 Google Play Store Submission

Complete guide: [Documentation/GOOGLE_PLAY_SUBMISSION.md](Documentation/GOOGLE_PLAY_SUBMISSION.md)

### Checklist:
- [ ] App Bundle (AAB) built and signed
- [ ] Privacy Policy created and hosted
- [ ] App icon (512x512)
- [ ] Feature graphic (1024x500)
- [ ] Screenshots (minimum 2)
- [ ] Content rating completed
- [ ] Data safety section filled
- [ ] Target API 31+ (Android 12)
- [ ] 64-bit support enabled

---

## 💰 Monetization

### Implemented Systems:

#### **AdMob Integration (Placeholder)**
- Banner ads on main menu
- Interstitial ads on game over
- Rewarded videos for continue feature
- In-app purchase: Remove ads

**Revenue Estimate:**
- Banner: $0.50-2 per 1000 impressions
- Interstitial: $3-10 per 1000 impressions
- Rewarded: $10-20 per 1000 views

#### **In-App Purchases (To Be Implemented)**
Potential IAPs:
- Remove Ads ($2.99)
- Coin Packs
- Premium Skins/Vehicles
- Fuel Boosters

---

## 🎨 Asset Requirements

See: [Documentation/ASSET_REQUIREMENTS.md](Documentation/ASSET_REQUIREMENTS.md)

### Graphics Needed:
- Car sprite (player vehicle)
- Obstacle sprites (rocks, barriers, etc.)
- Coin sprite (collectible)
- Fuel can sprite (collectible)
- Background terrain/ground
- UI elements (buttons, panels)
- Particle effects (optional)

### Audio Needed:
- Background music (looping)
- Coin pickup sound
- Fuel pickup sound
- Crash/collision sound
- Button click sound
- Engine/motor sound (optional)
- Low fuel warning (optional)

### Tools & Resources:
- **Sprites:** Unity Asset Store, OpenGameArt.org, itch.io
- **Audio:** Freesound.org, Incompetech.com, OpenGameArt.org
- **Icons:** Flaticon.com, Icons8.com
- **Fonts:** Google Fonts, DaFont.com

---

## 🛠️ Development Roadmap

### Phase 1: Core Mechanics ✅
- [x] Basic car physics
- [x] Touch controls
- [x] Endless runner logic
- [x] Fuel system
- [x] Score system

### Phase 2: Polish & Features ✅
- [x] UI/UX complete
- [x] Audio system
- [x] Save/load high scores
- [x] Difficulty progression

### Phase 3: Monetization (In Progress)
- [x] AdMob placeholder setup
- [ ] Implement actual AdMob SDK
- [ ] GDPR consent flow
- [ ] In-app purchases

### Phase 4: Publishing 🚀
- [ ] Final testing on devices
- [ ] Create marketing materials
- [ ] Submit to Google Play
- [ ] Post-launch support

### Future Updates:
- Multiple vehicle skins
- Power-ups system
- Daily challenges
- Leaderboards (Google Play Games)
- Achievements
- Different terrain themes

---

## 🐛 Known Issues

None at the moment. Report issues at: [GitHub Issues](https://github.com/MohamedZER0/Balance-Car-Unity/issues)

---

## 🤝 Contributing

Contributions are welcome! Please:

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit changes (`git commit -m 'Add AmazingFeature'`)
4. Push to branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

---

## 📄 License

This project is licensed under the MIT License - see LICENSE file for details.

---

## 👥 Credits

**Developer:** [Your Name]
**Unity Version:** 2017.1.0f3+
**Platform:** Android

### Third-Party Assets:
- Google Mobile Ads SDK (AdMob)
- Unity Physics Engine
- [List any asset packs or audio used]

---

## 📞 Contact & Support

- **Email:** your.email@example.com
- **GitHub:** [@MohamedZER0](https://github.com/MohamedZER0)
- **Issues:** [Report Bug](https://github.com/MohamedZER0/Balance-Car-Unity/issues)

---

## 🌟 Acknowledgments

- Unity Technologies for the game engine
- Google AdMob for monetization platform
- Community contributors and testers

---

**Made with ❤️ using Unity**

---

_Last Updated: 2025_
