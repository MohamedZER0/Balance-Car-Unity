# Asset Requirements for Balance Car Runner

Complete guide for all visual, audio, and resource assets needed for the game and Google Play Store submission.

---

## Table of Contents
1. [Game Assets](#game-assets)
2. [UI Assets](#ui-assets)
3. [Audio Assets](#audio-assets)
4. [Google Play Store Assets](#google-play-store-assets)
5. [Asset Sources](#asset-sources)
6. [Technical Specifications](#technical-specifications)

---

## 🎨 Game Assets

### Vehicle Sprites

#### **Player Car**
- **Format:** PNG with transparency
- **Size:** 128x64 pixels (or higher, maintain aspect ratio)
- **Details:** Top-down or side view of a car/vehicle
- **Layers:** Body, wheels (separate if using WheelJoint2D)
- **Animation:** Optional: exhaust particles, wheel rotation

#### **Wheels** (if separate)
- **Format:** PNG with transparency
- **Size:** 32x32 pixels each
- **Quantity:** 2 wheels (front and back)

### Obstacle Sprites

Create 3-5 different obstacle types:

1. **Rock/Boulder**
   - Size: 64x64 to 128x128 pixels
   - Irregular, natural shape

2. **Barrier/Fence**
   - Size: 64x128 pixels (tall)
   - Man-made obstacle

3. **Spikes/Hazard**
   - Size: 128x32 pixels (wide and low)
   - Dangerous-looking

4. **Tree/Log**
   - Size: 64x128 pixels
   - Natural environment

5. **Broken Vehicle/Debris**
   - Size: 96x64 pixels
   - Adds variety

### Collectible Sprites

#### **Coin**
- **Format:** PNG with transparency
- **Size:** 48x48 pixels
- **Style:** Shiny, golden coin
- **Animation:** Optional rotating sprite sheet (4-8 frames)

#### **Fuel Can**
- **Format:** PNG with transparency
- **Size:** 48x48 pixels
- **Style:** Gas can, fuel pump, or battery
- **Color:** Red or yellow to stand out

#### **Checkpoint Flag** (optional)
- **Format:** PNG with transparency
- **Size:** 64x128 pixels
- **Style:** Checkered flag or goal marker

### Environment Assets

#### **Ground/Terrain**
- **Format:** Tileable PNG
- **Size:** 256x256 pixels (tile)
- **Style:** Dirt, asphalt, or desert texture
- **Seamless:** Must tile horizontally

#### **Background Layers** (parallax)
- **Layer 1 (Far):** Mountains/hills - 512x256 px
- **Layer 2 (Mid):** Trees/buildings - 512x256 px
- **Layer 3 (Near):** Bushes/rocks - 512x256 px
- **All:** Seamless horizontal tiling

### Particle Effects (Optional)

1. **Crash Explosion**
   - Sprite sheet: 512x512 (8x8 grid = 64 frames)
   - Or use Unity particle system

2. **Dust/Smoke Trail**
   - Single sprite: 64x64
   - Use with particle system

3. **Coin Sparkle**
   - Sprite sheet: 256x256 (4x4 grid)

4. **Fuel Glow**
   - Simple glow sprite: 64x64

---

## 🖼️ UI Assets

### Buttons

Create button sprites in 3 states: Normal, Pressed, Disabled

**Required Buttons:**
- Play/Start (120x40 px)
- Pause (40x40 px)
- Restart/Retry (100x40 px)
- Settings/Gear icon (40x40 px)
- Close/X button (40x40 px)
- Left/Right arrows (50x50 px each)
- Rotation arrows (50x50 px each)

**Format:** PNG with transparency
**Style:** Consistent with game theme

### Panels

- **Main Menu Panel:** 800x600 px (rounded corners)
- **Game Over Panel:** 600x400 px
- **Settings Panel:** 500x500 px
- **Pause Panel:** 400x300 px

**Format:** PNG with transparency, 9-slice compatible
**Style:** Semi-transparent with borders

### HUD Elements

1. **Fuel Bar Background:** 200x40 px (empty bar)
2. **Fuel Bar Fill:** 200x40 px (filled bar, green/yellow/red)
3. **Score Icon:** 32x32 px (trophy or star)
4. **Distance Icon:** 32x32 px (road sign or speedometer)
5. **Coin Icon:** 32x32 px (same as collectible)

### Fonts

**Primary Font (Headings):**
- Bold, game-style font
- Example: "Bangers", "Press Start 2P", "Baloo"

**Secondary Font (UI Text):**
- Clean, readable sans-serif
- Example: "Roboto", "Open Sans"

**Download from:** Google Fonts (https://fonts.google.com)

---

## 🔊 Audio Assets

### Music

1. **Background Music (Main Menu & Gameplay)**
   - **Format:** .ogg (compressed, smaller file size)
   - **Length:** 1-3 minutes looping
   - **Style:** Upbeat, energetic, suitable for racing
   - **BPM:** 120-140 (fast-paced)
   - **File Size:** < 3 MB

2. **Game Over Music** (optional)
   - **Format:** .ogg
   - **Length:** 10-20 seconds
   - **Style:** Disappointing but not depressing
   - **File Size:** < 500 KB

### Sound Effects

1. **Button Click**
   - Format: .wav
   - Length: < 0.2 seconds
   - Volume: Medium

2. **Coin Pickup**
   - Format: .wav
   - Length: < 0.3 seconds
   - Pitch: High, pleasant "ding"

3. **Fuel Pickup**
   - Format: .wav
   - Length: < 0.5 seconds
   - Sound: Gas pouring or power-up

4. **Crash/Collision**
   - Format: .wav
   - Length: < 1 second
   - Sound: Impact, breaking

5. **Engine/Motor** (optional looping)
   - Format: .ogg
   - Length: 2-3 seconds loop
   - Sound: Car engine running

6. **Low Fuel Warning**
   - Format: .wav
   - Length: < 0.5 seconds
   - Sound: Alert beep

7. **Checkpoint Reached** (optional)
   - Format: .wav
   - Length: < 0.5 seconds
   - Sound: Success chime

**Total Audio Budget:** < 10 MB for all audio

---

## 📱 Google Play Store Assets

### App Icon

**Specifications:**
- **Size:** 512x512 pixels
- **Format:** 32-bit PNG with alpha
- **No Transparency:** Must have opaque background
- **No Rounded Corners:** Google applies them automatically
- **Safe Zone:** Keep important elements in center 80%
- **Content:** Car or game logo, clear and recognizable

**Design Tips:**
- Simple, iconic design
- Readable at small sizes
- Vibrant colors
- Avoid text (or keep minimal)
- Test at 48x48 px to ensure clarity

### Feature Graphic

**Specifications:**
- **Size:** 1024x500 pixels
- **Format:** JPG or 24-bit PNG (no alpha)
- **Aspect Ratio:** ~2:1
- **File Size:** < 1 MB

**Content:**
- Game title/logo
- Main character/vehicle
- Action scene or gameplay
- Call to action (optional)
- No excessive text

**Design Tips:**
- Landscape orientation
- Vibrant, eye-catching colors
- Professional look
- Avoid clutter
- Consistent with app icon style

### Screenshots

**Phone Screenshots:**
- **Quantity:** Minimum 2, Maximum 8
- **Recommended:** 4-6 screenshots
- **Aspect Ratio:** 16:9 (landscape) - **1920x1080 pixels**
- **Format:** PNG or JPG
- **File Size:** < 8 MB each

**Screenshot Ideas:**
1. **Main Menu** - Show game title and play button
2. **Gameplay Action** - Car navigating obstacles
3. **HUD Display** - Show score, fuel meter in action
4. **Fuel Collection** - Collecting fuel pickup
5. **Game Over** - Final score and restart option
6. **Settings/Features** - Show game features

**Design Tips:**
- Capture in-game or add decorative frames
- Add captions explaining features
- Show best moments of gameplay
- Keep UI visible and clear
- No fake screenshots

### Promo Video (Optional but Recommended)

**Specifications:**
- **Platform:** YouTube
- **Length:** 30 seconds to 2 minutes
- **Format:** MP4, 1920x1080, 60fps
- **Aspect Ratio:** 16:9

**Content:**
- 3-5 seconds: Game logo/title
- 15-30 seconds: Gameplay footage
- 5-10 seconds: Features highlight
- 3-5 seconds: Call to action (download)

**Tips:**
- Background music (royalty-free)
- Show exciting moments
- Keep it fast-paced
- Add text overlays for features

---

## 🔗 Asset Sources

### Free Graphics

1. **OpenGameArt.org**
   - Large collection of free game assets
   - License: CC0, CC-BY, GPL

2. **itch.io Assets**
   - Free and paid asset packs
   - 2D sprites, UI elements

3. **Kenney.nl**
   - High-quality free game assets
   - UI packs, sprites, sounds

4. **Unity Asset Store**
   - Free and paid assets
   - Filter by "Free Only"

5. **Freepik.com / Flaticon.com**
   - Icons and graphics
   - Free with attribution

### Free Audio

1. **Freesound.org**
   - User-uploaded sounds
   - CC licenses, attribution required

2. **Incompetech.com (Kevin MacLeod)**
   - Royalty-free music
   - Attribution required

3. **Bensound.com**
   - Royalty-free music
   - Free with attribution

4. **ZapSplat.com**
   - Sound effects library
   - Free account required

5. **OpenGameArt.org**
   - Game music and SFX

### Paid/Premium

1. **Unity Asset Store** (Paid)
2. **Envato Market** (AudioJungle, GraphicRiver)
3. **itch.io** (Paid packs)
4. **Humble Bundle** (Game dev asset bundles)

---

## ⚙️ Technical Specifications

### Import Settings (Unity)

#### **Sprites:**
```
Texture Type: Sprite (2D and UI)
Sprite Mode: Single (or Multiple for sheets)
Pixels Per Unit: 100
Filter Mode: Bilinear
Max Size: 2048 (or lower for performance)
Format: RGBA Compressed ETC2 (Android)
Compression: Normal Quality
```

#### **UI Images:**
```
Texture Type: Sprite (2D and UI)
Mesh Type: Tight (for transparency)
Max Size: 1024
Format: RGBA Compressed ETC2
Mip Maps: Disabled
```

#### **Audio - Music:**
```
Load Type: Streaming
Compression: Vorbis
Quality: 70%
Sample Rate: Preserve Sample Rate
```

#### **Audio - SFX:**
```
Load Type: Decompress On Load
Compression: PCM (short sounds) or Vorbis (longer)
Quality: 100% (PCM) or 70% (Vorbis)
```

### File Naming Convention

```
Sprites:
  spr_car_player.png
  spr_obstacle_rock_01.png
  spr_coin.png

UI:
  ui_btn_play_normal.png
  ui_panel_menu.png
  ui_icon_fuel.png

Audio:
  mus_background_loop.ogg
  sfx_coin_pickup.wav
  sfx_crash.wav
```

### Organization

```
Assets/
  Sprites/
    Player/
    Obstacles/
    Collectibles/
    Environment/
  UI/
    Buttons/
    Panels/
    Icons/
  Audio/
    Music/
    SFX/
  Fonts/
```

---

## ✅ Asset Checklist

### Minimum Required (MVP):

**Graphics:**
- [ ] Player car sprite
- [ ] 2-3 obstacle sprites
- [ ] Coin sprite
- [ ] Fuel sprite
- [ ] Ground/terrain tile
- [ ] Basic UI buttons

**Audio:**
- [ ] Background music
- [ ] Coin pickup SFX
- [ ] Crash SFX
- [ ] Button click SFX

**Store Assets:**
- [ ] App icon (512x512)
- [ ] Feature graphic (1024x500)
- [ ] 2+ screenshots

### Recommended (Full Release):

**Graphics:**
- [ ] All minimum assets
- [ ] 5+ obstacle varieties
- [ ] Parallax background layers
- [ ] Particle effects
- [ ] Polished UI elements
- [ ] Checkpoint/goal sprite

**Audio:**
- [ ] All minimum audio
- [ ] Fuel pickup SFX
- [ ] Engine loop SFX
- [ ] Low fuel warning
- [ ] Game over music

**Store Assets:**
- [ ] All minimum assets
- [ ] 4-6 screenshots
- [ ] Promo video
- [ ] Localized screenshots (if targeting multiple languages)

---

## 🎨 Design Guidelines

### Color Palette

Suggested colors for cohesive design:

**Primary Colors:**
- Bright Blue: #2196F3
- Energetic Orange: #FF9800
- Success Green: #4CAF50

**Accent Colors:**
- Yellow (coins/fuel): #FFC107
- Red (danger/low fuel): #F44336

**Neutrals:**
- Dark Gray: #424242
- Light Gray: #E0E0E0
- White: #FFFFFF

### Style Guide

- **Art Style:** Cartoon/Casual or Retro/Pixel
- **Consistency:** All assets should match in style
- **Readability:** Ensure UI is readable on small screens
- **Accessibility:** High contrast for better visibility

---

## 📐 Templates & Tools

### Design Tools (Free):

1. **GIMP** - Free Photoshop alternative
2. **Inkscape** - Vector graphics editor
3. **Krita** - Digital painting
4. **Aseprite** - Pixel art (paid but worth it)
5. **Canva** - UI/Marketing graphics (free tier)

### Audio Tools (Free):

1. **Audacity** - Audio editing
2. **LMMS** - Music creation
3. **Bfxr/Sfxr** - 8-bit sound effects generator
4. **Bosca Ceoil** - Simple music maker

### Screenshot Tools:

1. **Unity Recorder** (Unity Package)
2. **OBS Studio** (Screen recording)
3. **Screenshot Mate** (Android device screenshots)

---

**Need Help?**

If you need assistance creating any of these assets, consider:
- Hiring on Fiverr/Upwork
- Posting on game dev forums
- Using AI generators (for concepts)
- Collaborating with artists

---

**Last Updated:** 2025
