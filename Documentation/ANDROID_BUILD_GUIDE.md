# Android Build Configuration Guide

This guide will help you configure and build your Balance Car endless runner game for Android and prepare it for Google Play Store submission.

## Prerequisites

1. **Unity 2017.1.0f3 or newer** (Recommended: Unity 2021 LTS or newer for better Android support)
2. **Android SDK and NDK** (Install via Unity Hub)
3. **JDK (Java Development Kit)** version 8 or higher
4. **Google Play Console Account** ($25 one-time registration fee)

---

## Step 1: Android Build Settings

### 1.1 Configure Player Settings

1. Open Unity Editor
2. Go to **File > Build Settings**
3. Select **Android** platform
4. Click **Switch Platform** if not already on Android
5. Click **Player Settings** button

### 1.2 Player Settings Configuration

#### **Company & Product**
```
Company Name: [Your Company Name]
Product Name: Balance Car Runner
Default Icon: [1024x1024 PNG]
Default Cursor: Auto
Cursor Hotspot: 0, 0
```

#### **Resolution and Presentation**
```
Fullscreen Mode: Fullscreen Window
Default Orientation: Landscape Left (or Auto Rotation)
Allowed Orientations for Auto Rotation:
  ✓ Landscape Left
  ✓ Landscape Right
  ☐ Portrait
  ☐ Portrait Upside Down

Use 32-bit Display Buffer: ✓
Show Splash Screen: As desired
```

#### **Icon Settings**
Create icons in the following sizes:
- **432x432** - XXXHDPI
- **324x324** - XXHDPI
- **216x216** - XHDPI
- **162x162** - HDPI
- **108x108** - MDPI

#### **Other Settings**
```
Package Name: com.[YourCompany].[GameName]
  Example: com.yourstudio.balancecar

Version: 1.0
Bundle Version Code: 1

Minimum API Level: Android 5.1 'Lollipop' (API level 22) or higher
Target API Level: Automatic (Highest Installed)
  Note: Google Play requires API 31+ (Android 12) for new apps

Scripting Backend: IL2CPP (recommended for better performance)
ARM64: ✓ (Required by Google Play as of August 2021)
ARMv7: ✓ (for older devices, optional)

Target Architectures:
  ✓ ARM64
  ✓ ARMv7 (optional, for wider device compatibility)

Internet Access: Auto (or Require if using ads)
Write Permission: Internal Only
```

#### **Publishing Settings**
```
Build:
  Create symbols.zip: ✓ (for crash reporting)

Keystore Manager:
  - Create new keystore for release builds
  - Store keystore file safely (you cannot recover it if lost!)

Keystore Settings:
  Path: [Path to your .keystore file]
  Password: [Your secure password]
  Alias: [Key alias name]
  Alias Password: [Alias password]

IMPORTANT: Back up your keystore file! You need it for all future updates.
```

---

## Step 2: Android Manifest Configuration

Unity will auto-generate the manifest, but you may need to add permissions for ads and analytics.

Create file at: `Assets/Plugins/Android/AndroidManifest.xml`

```xml
<?xml version="1.0" encoding="utf-8"?>
<manifest
    xmlns:android="http://schemas.android.com/apk/res/android"
    package="com.yourcompany.balancecar"
    xmlns:tools="http://schemas.android.com/tools">

    <!-- Required for ads -->
    <uses-permission android:name="android.permission.INTERNET" />
    <uses-permission android:name="android.permission.ACCESS_NETWORK_STATE" />

    <!-- For better ad targeting (optional) -->
    <uses-permission android:name="android.permission.ACCESS_WIFI_STATE" />

    <!-- Google Play Services (required for AdMob) -->
    <application>
        <meta-data
            android:name="com.google.android.gms.ads.APPLICATION_ID"
            android:value="ca-app-pub-XXXXXXXXXXXXXXXX~YYYYYYYYYY"/>
    </application>
</manifest>
```

**Replace** `ca-app-pub-XXXXXXXXXXXXXXXX~YYYYYYYYYY` with your actual AdMob App ID.

---

## Step 3: Build the APK/AAB

### For Testing (APK):
1. Go to **File > Build Settings**
2. Ensure Android is selected
3. Click **Build**
4. Choose save location
5. Install APK on your Android device for testing

### For Google Play Release (AAB - Recommended):
1. Go to **File > Build Settings**
2. Check **Build App Bundle (Google Play)**
3. Click **Build**
4. Choose save location
5. Upload the .aab file to Google Play Console

**App Bundle (AAB) is required** by Google Play Store for new apps.

---

## Step 4: Testing Checklist

Before uploading to Play Store, test thoroughly:

### Device Testing:
- [ ] Test on multiple Android devices (different screen sizes)
- [ ] Test on minimum API level device (Android 5.1+)
- [ ] Test on latest Android version
- [ ] Test landscape orientation
- [ ] Test touch controls responsiveness
- [ ] Test game performance (60 FPS target)

### Feature Testing:
- [ ] Game starts correctly
- [ ] Score system works
- [ ] Fuel system depletes over time
- [ ] Fuel pickups restore fuel
- [ ] Coin pickups add score
- [ ] Obstacles trigger game over
- [ ] Game over screen appears correctly
- [ ] Restart button works
- [ ] High score saves correctly
- [ ] Ad placements appear (even if test ads)
- [ ] Sound effects play
- [ ] Music plays and loops
- [ ] Settings (volume, vibration) work
- [ ] No crashes or freezes

### Performance Testing:
- [ ] Game loads in < 5 seconds
- [ ] No frame drops during gameplay
- [ ] Memory usage is reasonable (< 500MB)
- [ ] Battery drain is acceptable
- [ ] No overheating issues

---

## Step 5: Build Optimization

### Reduce APK/AAB Size:
1. **Project Settings > Player > Publishing Settings**
   - Enable **Strip Engine Code**
   - Set **Managed Stripping Level** to High

2. **Edit > Project Settings > Quality**
   - Disable quality levels you don't need
   - Keep only 2-3 quality presets

3. **Texture Compression**
   - Use ASTC format for textures (best for Android)
   - Set Max Size appropriately (1024 or less for mobile)

4. **Audio Compression**
   - Use Vorbis compression for music
   - Use PCM for short sound effects

### Improve Performance:
1. **Enable GPU Instancing** for repeated objects
2. **Use Object Pooling** (already implemented in ObstacleSpawner)
3. **Optimize Physics** (reduce FixedUpdate calls if needed)
4. **Bake Lighting** (if using 3D)
5. **Reduce Draw Calls** (combine meshes, use atlases)

---

## Step 6: Google Play Services Integration

### AdMob Setup:
1. Create AdMob account at https://admob.google.com
2. Create new app in AdMob console
3. Create ad units (Banner, Interstitial, Rewarded)
4. Copy Ad Unit IDs
5. Import Google Mobile Ads Unity Plugin
6. Update `GoogleAdsManager.cs` with your ad unit IDs

### Google Play Games Services (Optional):
For leaderboards and achievements:
1. Set up in Google Play Console
2. Import Play Games Plugin for Unity
3. Configure leaderboards and achievements

---

## Common Build Issues & Solutions

### Issue: "Unable to list target platforms"
**Solution:** Install Android SDK via Unity Hub

### Issue: "Gradle build failed"
**Solution:**
- Update to latest Gradle version
- Check Android SDK path in Unity preferences
- Clear Gradle cache

### Issue: "Keystore not found"
**Solution:** Verify keystore path in Player Settings

### Issue: "Minimum API level error"
**Solution:** Update target API to 31+ in Player Settings

### Issue: "App Bundle not supported"
**Solution:** Update Unity to 2018.3 or newer

---

## Next Steps

After building successfully:
1. ✅ Test APK on multiple devices
2. ✅ Create app store listing (see GOOGLE_PLAY_SUBMISSION.md)
3. ✅ Upload AAB to Google Play Console
4. ✅ Complete store listing with screenshots and description
5. ✅ Submit for review

---

## Additional Resources

- [Unity Android Build Documentation](https://docs.unity3d.com/Manual/android-BuildProcess.html)
- [Google Play Console Help](https://support.google.com/googleplay/android-developer)
- [AdMob Documentation](https://developers.google.com/admob/unity/start)
- [Android App Bundle Info](https://developer.android.com/guide/app-bundle)

---

**Last Updated:** 2025
**Unity Version:** 2017.1.0f3+
**Target API:** Android 12+ (API 31+)
