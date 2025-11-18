# Script Documentation - Balance Car Runner

Detailed technical documentation for all C# scripts in the project.

---

## Table of Contents
1. [Core Managers](#core-managers)
2. [Gameplay Scripts](#gameplay-scripts)
3. [Collectible Scripts](#collectible-scripts)
4. [UI Scripts](#ui-scripts)
5. [Integration Scripts](#integration-scripts)
6. [Script Dependencies](#script-dependencies)

---

## Core Managers

### GameManager.cs
**Location:** `Assets/Scripts/GameManager.cs`
**Purpose:** Central game state management, score tracking, fuel system, and difficulty progression

#### **Singleton Pattern**
```csharp
public static GameManager Instance { get; }
```
Access the manager from anywhere using `GameManager.Instance`

#### **Public Properties**
| Property | Type | Description |
|----------|------|-------------|
| `scoreMultiplier` | float | Points earned per second of survival |
| `coinValue` | int | Points awarded per coin collected |
| `maxFuel` | float | Maximum fuel capacity |
| `fuelConsumptionRate` | float | Fuel consumed per second |
| `fuelPickupAmount` | float | Fuel restored per pickup |
| `isGameActive` | bool | Whether game is currently running |
| `isGameOver` | bool | Whether game has ended |
| `difficultyIncreaseInterval` | float | Time between difficulty increases |
| `maxDifficulty` | float | Maximum difficulty multiplier |

#### **Public Methods**

**StartGame()**
- Initializes new game session
- Resets all game state
- Shows gameplay UI

**GameOver()**
- Ends the game
- Updates high score if beaten
- Shows game over screen
- Triggers interstitial ad

**RestartGame()**
- Reloads current scene
- Resets game state

**AddScore(int points)**
- Adds points to current score
- Called by collectibles and checkpoints

**AddFuel(float amount)**
- Restores fuel (capped at maxFuel)
- Called by fuel pickups

**GetDifficulty() → float**
- Returns current difficulty multiplier
- Used by ObstacleSpawner to adjust spawn rates

**GetScore() → int**
- Returns current score

**GetFuel() → float**
- Returns current fuel amount

**GetHighScore() → int**
- Returns saved high score from PlayerPrefs

**ContinueWithAd()**
- Restores 50% fuel
- Continues game after watching rewarded ad

#### **How It Works**
1. **Update Loop:**
   - Tracks game time
   - Increases score based on time
   - Consumes fuel
   - Increases difficulty
   - Checks for fuel depletion → triggers game over

2. **Score System:**
   - Distance score: `scoreMultiplier * Time.deltaTime`
   - Collectible bonuses added via `AddScore()`

3. **Difficulty:**
   - `currentDifficulty = 1 + (gameTime / difficultyIncreaseInterval)`
   - Capped at `maxDifficulty`

4. **Persistence:**
   - High score saved in PlayerPrefs
   - Key: `"HighScore"`

---

### UIManager.cs
**Location:** `Assets/Scripts/UIManager.cs`
**Purpose:** Manages all UI panels, buttons, and visual updates

#### **Singleton Pattern**
```csharp
public static UIManager Instance { get; }
```

#### **Required UI References (Assign in Inspector)**

**Panels:**
- `mainMenuPanel` - GameObject for main menu
- `gameplayPanel` - GameObject for HUD during gameplay
- `gameOverPanel` - GameObject for game over screen
- `pausePanel` - GameObject for pause menu
- `settingsPanel` - GameObject for settings menu

**Gameplay UI:**
- `scoreText` - Text showing current score
- `distanceText` - Text showing distance traveled
- `fuelBar` - Image (fill type) for fuel bar
- `fuelPercentText` - Text showing fuel percentage

**Game Over UI:**
- `finalScoreText` - Text showing final score
- `highScoreText` - Text showing high score
- `finalDistanceText` - Text showing distance
- `restartButton` - Button to restart game
- `mainMenuButton` - Button to return to menu
- `continueWithAdButton` - Button to watch ad and continue

**Main Menu UI:**
- `playButton` - Button to start game
- `mainMenuHighScoreText` - Text showing high score on menu
- `settingsButton` - Button to open settings
- `rateButton` - Button to rate app
- `removeAdsButton` - Button for IAP

**Pause UI:**
- `resumeButton` - Button to resume game
- `pauseMenuButton` - Button to pause game

**Settings:**
- `musicVolumeSlider` - Slider for music volume
- `sfxVolumeSlider` - Slider for SFX volume
- `vibrationToggle` - Toggle for vibration

**Ad Banner:**
- `adBannerPlaceholder` - GameObject placeholder for banner ad

#### **Public Methods**

**ShowMainMenu()**
- Shows main menu
- Hides all other panels
- Displays high score
- Resumes time

**ShowGameUI()**
- Shows gameplay HUD
- Hides all other panels
- Resumes time

**ShowGameOver(int finalScore, int highScore, int distance)**
- Shows game over screen
- Displays final stats
- Pauses time (Time.timeScale = 0)

**ShowPause() / HidePause()**
- Toggle pause panel
- Pauses/resumes time

**UpdateScore(int score)**
- Updates score text display

**UpdateDistance(int distance)**
- Updates distance text display

**UpdateFuel(float currentFuel, float maxFuel)**
- Updates fuel bar fill amount
- Changes fuel bar color (green > yellow > red)
- Updates fuel percentage text

**ShowToast(string message)**
- Shows temporary message (placeholder)

#### **Button Callbacks**
All button callbacks automatically:
- Play click sound via AudioManager
- Perform appropriate action
- Update game state

---

### AudioManager.cs
**Location:** `Assets/Scripts/AudioManager.cs`
**Purpose:** Manages all game audio including music and sound effects

#### **Singleton Pattern**
```csharp
public static AudioManager Instance { get; }
```

#### **Audio Sources**
- `musicSource` - AudioSource for background music
- `sfxSource` - AudioSource for sound effects

#### **Audio Clips (Assign in Inspector)**

**Music:**
- `backgroundMusic` - Looping background music
- `gameOverMusic` - Game over music (non-looping)

**Sound Effects:**
- `buttonClickSFX` - UI button clicks
- `coinPickupSFX` - Coin collection
- `fuelPickupSFX` - Fuel collection
- `crashSFX` - Collision/death
- `engineSFX` - Engine sound (optional)
- `lowFuelWarningSFX` - Low fuel alert

#### **Public Methods**

**Music Control:**
- `PlayBackgroundMusic()` - Starts background music loop
- `PlayGameOverMusic()` - Plays game over music
- `StopMusic()` - Stops current music

**Sound Effects:**
- `PlaySFX(AudioClip clip)` - Plays any sound effect
- `PlayButtonClick()` - Plays button click sound
- `PlayCoinPickup()` - Plays coin sound
- `PlayFuelPickup()` - Plays fuel sound
- `PlayCrash()` - Plays crash sound
- `PlayEngine()` - Plays engine sound
- `PlayLowFuelWarning()` - Plays low fuel warning

**Volume Control:**
- `SetMusicVolume(float volume)` - Sets music volume (0-1)
- `SetSFXVolume(float volume)` - Sets SFX volume (0-1)
- `ToggleMute()` - Mutes/unmutes all audio

**Vibration (Mobile):**
- `Vibrate()` - Triggers haptic feedback
- `VibrateLight()` - Light vibration (UI)
- `VibrateHeavy()` - Heavy vibration (crash)

#### **Low Fuel Warning**
Automatically plays warning sound when fuel drops below threshold (default 25%)

---

## Gameplay Scripts

### CarController.cs
**Location:** `Assets/Scripts/CarController.cs`
**Purpose:** Controls vehicle physics using WheelJoint2D and torque-based rotation

#### **Public Properties**
| Property | Type | Description |
|----------|------|-------------|
| `speed` | float | Motor speed multiplier |
| `rotationSpeed` | float | Torque rotation speed |
| `backWheel` | WheelJoint2D | Rear wheel joint reference |
| `frontWheel` | WheelJoint2D | Front wheel joint reference |
| `maxMotorTorque` | int | Maximum motor torque for wheels |
| `rB` | Rigidbody2D | Main rigidbody reference |

#### **Public Methods**

**Move(float moveInput)**
- Parameters: `moveInput` (-1 to 1)
- Called by input systems (keyboard or touch)
- Sets motor speed: `movement = speed * moveInput`

**Rotation(float rotationValue)**
- Parameters: `rotationValue` (-1 to 1)
- Called by input systems
- Applies torque to rigidbody for rotation

#### **How It Works**

1. **Start()** - Validates all references, logs errors if missing
2. **Update()** - Reads input (desktop only with #if UNITY_STANDALONE)
3. **FixedUpdate()** - Applies physics:
   - Sets wheel motor on/off based on movement
   - Applies motor speed to both wheels
   - Applies rotation torque to rigidbody

#### **Platform-Specific Input**
```csharp
#if UNITY_STANDALONE || UNITY_EDITOR
    Move(-Input.GetAxisRaw("Vertical"));
    Rotation(-Input.GetAxisRaw("Horizontal"));
#endif
```
Mobile uses TouchControllers instead

#### **Null Safety**
All methods check for null references before use to prevent crashes

---

### CameraController.cs
**Location:** `Assets/Scripts/CameraController.cs`
**Purpose:** Follows the player car smoothly

#### **Public Properties**
| Property | Type | Description |
|----------|------|-------------|
| `target` | Transform | Player transform to follow |

#### **How It Works**
- **FixedUpdate()** - Follows target position in X and Y
- Maintains fixed Z position (-10 for 2D)
- Includes null check for target

#### **Setup**
1. Attach to Main Camera
2. Assign player car's Transform to `target`
3. Camera automatically follows player

---

### TouchControllers.cs
**Location:** `Assets/Scripts/TouchControllers.cs`
**Purpose:** Provides touch button input for mobile devices

#### **How It Works**
1. **Start()** - Finds CarController in scene
2. **Public methods** - Called by UI button events

#### **Public Methods (Assign to UI Buttons)**

**Movement:**
- `LeftArrow()` - Move left/backward
- `RightArrow()` - Move right/forward
- `UnpressedArrow()` - Stop movement

**Rotation:**
- `RotateRight()` - Rotate clockwise
- `RotateLeft()` - Rotate counterclockwise
- `UnRotate()` - Stop rotation

#### **Setup in Unity**
1. Create UI buttons for each control
2. Assign methods to button's `OnPointerDown`/`OnClick` events:
   - Left button → `LeftArrow()`
   - Right button → `RightArrow()`
   - Release → `UnpressedArrow()`

#### **Null Safety**
All methods check if `theCar` is null before calling methods

---

### ObstacleSpawner.cs
**Location:** `Assets/Scripts/ObstacleSpawner.cs`
**Purpose:** Procedurally generates obstacles, coins, and fuel pickups

#### **Public Properties**

**Spawn Settings:**
- `minSpawnDistance` - Minimum gap between spawns
- `maxSpawnDistance` - Maximum gap between spawns
- `spawnDistanceAhead` - How far ahead to spawn
- `despawnDistanceBehind` - When to remove old objects

**Prefabs:**
- `obstaclePrefabs[]` - Array of obstacle prefabs
- `fuelPickupPrefab` - Fuel can prefab
- `coinPickupPrefab` - Coin prefab

**Spawn Chances (0-1):**
- `obstacleSpawnChance` - Probability of obstacle (default 0.7)
- `fuelSpawnChance` - Probability of fuel (default 0.2)
- `coinSpawnChance` - Probability of coins (default 0.5)

**Height Variation:**
- `minHeight` / `maxHeight` - Y position range for spawns

**References:**
- `playerTransform` - Player to track position

#### **How It Works**

1. **Start()** - Pre-spawns 10 sets of objects
2. **Update():**
   - Spawns objects ahead of player
   - Despawns objects behind player
3. **SpawnNext():**
   - Decides what to spawn based on probabilities
   - Spawns obstacles, coins (1-3), and fuel
   - Adjusts spawn distance by difficulty

#### **Object Pooling**
- Tracks spawned objects in list
- Destroys objects when too far behind
- Optimized for mobile performance

#### **Gizmos (Editor Only)**
- Green line = spawn zone
- Red line = despawn zone

---

## Collectible Scripts

### FuelPickup.cs
**Location:** `Assets/Scripts/FuelPickup.cs`
**Purpose:** Fuel collectible that restores player's fuel

#### **Public Properties**
| Property | Type | Description |
|----------|------|-------------|
| `fuelAmount` | float | Fuel to restore (default 30) |
| `scoreValue` | int | Points awarded (default 50) |
| `destroyAfterPickup` | bool | Whether to destroy after collection |
| `pickupEffect` | GameObject | Particle effect prefab |
| `rotationSpeed` | float | Visual rotation speed |
| `pickupSound` | AudioClip | Sound to play |

#### **How It Works**
1. **Update()** - Rotates for visual appeal
2. **OnTriggerEnter2D()** - Detects player collision
3. **CollectFuel():**
   - Calls `GameManager.AddFuel()`
   - Calls `GameManager.AddScore()`
   - Plays sound via AudioManager
   - Spawns particle effect
   - Destroys self

#### **Setup**
1. Create GameObject with sprite
2. Add Collider2D (trigger)
3. Add this script
4. Tag: doesn't need tag (player has "Player" tag)

---

### CoinPickup.cs
**Location:** `Assets/Scripts/CoinPickup.cs`
**Purpose:** Coin collectible for score points

#### **Public Properties**
Same structure as FuelPickup but for score only

| Property | Type | Description |
|----------|------|-------------|
| `scoreValue` | int | Points awarded (default 100) |
| `destroyAfterPickup` | bool | Whether to destroy |
| `pickupEffect` | GameObject | Particle effect |
| `rotationSpeed` | float | Visual rotation |
| `pickupSound` | AudioClip | Sound |

#### **How It Works**
1. Rotates visually
2. Detects player collision
3. Adds score
4. Plays sound and effect
5. Destroys self

---

### Goal.cs (Checkpoint)
**Location:** `Assets/Scripts/Goal.cs`
**Purpose:** Checkpoint that gives bonus score and fuel

#### **Public Properties**
| Property | Type | Description |
|----------|------|-------------|
| `checkpointBonus` | int | Score bonus (default 500) |
| `fuelBonus` | float | Fuel bonus (default 20) |
| `destroyAfterUse` | bool | One-time use |
| `checkpointEffect` | GameObject | Particle effect |

#### **How It Works**
Acts as collectible that gives both score and fuel bonus

---

### EndGame.cs
**Location:** `Assets/Scripts/EndGame.cs`
**Purpose:** Handles player death on collision with obstacles

#### **Public Properties**
| Property | Type | Description |
|----------|------|-------------|
| `gameOverDelay` | float | Delay before game over screen |
| `crashEffect` | GameObject | Particle effect on death |

#### **How It Works**
1. **OnTriggerEnter2D()** / **OnCollisionEnter2D()** - Detects collision with "Collidable" tag
2. **TriggerGameOver():**
   - Plays crash sound
   - Triggers vibration
   - Spawns crash effect
   - Delays game over by `gameOverDelay`
3. **CallGameOver():**
   - Calls `GameManager.GameOver()`
   - Disables CarController

#### **Setup**
1. Attach to player car
2. Tag obstacles with "Collidable"
3. Obstacles need Collider2D (trigger or collision)

---

## Integration Scripts

### GoogleAdsManager.cs
**Location:** `Assets/Scripts/GoogleAdsManager.cs`
**Purpose:** AdMob integration with placeholder implementation

#### **IMPORTANT: This is a Placeholder**
The script contains placeholder methods. To use real ads:
1. Import Google Mobile Ads Unity Plugin
2. Replace ad unit IDs with your own
3. Uncomment SDK code sections
4. Remove Debug.Log placeholders

#### **Public Properties**
- `appId` - AdMob app ID
- `bannerAdUnitId` - Banner ad unit
- `interstitialAdUnitId` - Interstitial ad unit
- `rewardedAdUnitId` - Rewarded video ad unit
- `showBannerOnStart` - Auto-show banner
- `interstitialCooldown` - Time between interstitials

#### **Public Methods**

**Banner Ads:**
- `ShowBannerAd()` - Shows banner at bottom
- `HideBannerAd()` - Hides banner

**Interstitial Ads:**
- `ShowInterstitialAd()` - Shows full-screen ad (game over)

**Rewarded Ads:**
- `ShowRewardedAd()` - Shows video for reward (continue game)

**In-App Purchase:**
- `PurchaseRemoveAds()` - Removes ads (IAP integration needed)

#### **How It Works**
1. **Awake()** - Checks if ads removed via PlayerPrefs
2. **Start()** - Initializes AdMob (when uncommented)
3. **Ads shown automatically:**
   - Banner on start
   - Interstitial on game over (with cooldown)
   - Rewarded on continue button

---

### BackgroundAudio.cs
**Location:** `Assets/Scripts/BackgroundAudio.cs`
**Purpose:** Persists background music across scene loads

#### **Singleton Pattern**
Prevents duplicate AudioSources when reloading scenes

#### **How It Works**
- **Awake():**
  - Destroys duplicate instances
  - Calls `DontDestroyOnLoad()`
- Keeps music playing between scene transitions

#### **Setup**
1. Create GameObject with AudioSource
2. Add this script
3. Assign music clip to AudioSource
4. Set AudioSource to loop
5. Place in first scene

---

## Script Dependencies

### Dependency Graph

```
GameManager (core, no dependencies)
    ↑ used by
    ├── UIManager
    ├── ObstacleSpawner
    ├── FuelPickup
    ├── CoinPickup
    ├── Goal
    └── EndGame

AudioManager (core, no dependencies)
    ↑ used by
    ├── UIManager
    ├── FuelPickup
    ├── CoinPickup
    ├── Goal
    └── EndGame

UIManager
    ├── uses: GameManager
    ├── uses: GoogleAdsManager
    └── uses: AudioManager

CarController (independent)
    ↑ used by
    ├── TouchControllers
    ├── CameraController (references Transform)
    └── EndGame

GoogleAdsManager (independent, used by UIManager and GameManager)

BackgroundAudio (completely independent)
```

### Scene Setup Order

1. **Create Core Managers First:**
   - GameManager
   - UIManager
   - AudioManager
   - GoogleAdsManager

2. **Create Gameplay Objects:**
   - Player Car (with CarController, EndGame)
   - Camera (with CameraController)
   - ObstacleSpawner

3. **Setup UI:**
   - Canvas with TouchControllers
   - Assign all UIManager references

4. **Create Prefabs:**
   - Obstacles
   - FuelPickup
   - CoinPickup
   - Goal/Checkpoint

---

## Best Practices

### Performance Optimization
- Use object pooling (ObstacleSpawner already does this)
- Avoid `FindObjectOfType` in Update loops
- Cache component references in Start/Awake
- Use `CompareTag()` instead of string comparison

### Error Handling
- All managers check for null before use
- Debug.LogError for missing references
- Graceful degradation if components missing

### Coding Standards
- XML documentation comments on all public methods
- Descriptive variable names
- Editor tooltips via [Tooltip] attribute
- Header organization via [Header] attribute

---

**Last Updated:** 2025
**Unity Version:** 2017.1.0f3+
**Language:** C# 4.0+
