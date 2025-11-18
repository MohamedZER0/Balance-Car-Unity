# Google Play Store Submission Guide

Complete guide for submitting Balance Car Runner to the Google Play Store with all compliance requirements met.

---

## Table of Contents
1. [Prerequisites](#prerequisites)
2. [Google Play Console Setup](#google-play-console-setup)
3. [App Content Declarations](#app-content-declarations)
4. [Privacy Policy Requirements](#privacy-policy-requirements)
5. [Store Listing](#store-listing)
6. [Content Rating](#content-rating)
7. [Data Safety Section](#data-safety-section)
8. [Compliance Checklist](#compliance-checklist)
9. [Submission Process](#submission-process)

---

## Prerequisites

### Required Items:
- [ ] Google Play Console account ($25 one-time fee)
- [ ] Signed AAB (App Bundle) file
- [ ] App icon (512x512 PNG)
- [ ] Feature graphic (1024x500 PNG)
- [ ] Screenshots (at least 2, up to 8)
- [ ] Privacy Policy URL (required if app collects data)
- [ ] App description and metadata
- [ ] Content rating questionnaire completed

---

## Google Play Console Setup

### 1. Create New App

1. Go to [Google Play Console](https://play.google.com/console)
2. Click **"Create app"**
3. Fill in app details:
   - **App name:** Balance Car Runner
   - **Default language:** English (US)
   - **App or game:** Game
   - **Free or paid:** Free
4. Accept declarations:
   - [ ] App adheres to Google Play Developer Program Policies
   - [ ] App complies with US export laws

### 2. Complete Dashboard Tasks

The dashboard will show required tasks. Complete them in this order:

---

## App Content Declarations

### Target Audience and Content

1. **Target Age Groups:**
   - Select age groups your game is suitable for
   - For this game, suggest: **Ages 7 and up** (or Everyone)

2. **Store Presence:**
   - Select whether your app should be discoverable in the Google Play Family program
   - **Recommended:** No (unless you want stricter family-friendly restrictions)

3. **News Apps:**
   - This app is NOT a news app ❌

4. **COVID-19 Contact Tracing/Status:**
   - This app does NOT provide COVID-19 related features ❌

5. **Data Safety:**
   - See [Data Safety Section](#data-safety-section) below

6. **Government Apps:**
   - Not a government app ❌

7. **Financial Features:**
   - No financial features ❌

8. **Health & Fitness:**
   - No health or fitness features ❌

---

## Privacy Policy Requirements

### When is it required?
Privacy Policy is **REQUIRED** if your app:
- Collects personal or sensitive user data
- Shows ads (which collect data)
- Uses analytics

Since this game uses AdMob, a **Privacy Policy is REQUIRED**.

### Create Privacy Policy

Use the template in `Documentation/PRIVACY_POLICY_TEMPLATE.md` or generate one at:
- https://www.privacypolicygenerator.info/
- https://www.freeprivacypolicy.com/

### Host Privacy Policy

Options:
1. **GitHub Pages** (Free)
   - Create repository with privacy policy
   - Enable GitHub Pages
   - Use URL: `https://[username].github.io/privacy-policy/`

2. **Your Website**
   - Host at `https://yoursite.com/privacy-policy/`

3. **Privacy Policy Generators** (some offer free hosting)

### Privacy Policy Must Include:
- What data is collected (device info, ad data)
- Why data is collected (ads, analytics)
- How data is used
- Third parties that receive data (Google AdMob)
- User rights and contact information
- Data retention and deletion policy

---

## Store Listing

### App Details

**App name:** Balance Car Runner

**Short description** (80 characters max):
```
Fast-paced 2D physics racing game! Balance, dodge obstacles, collect fuel!
```

**Full description** (4000 characters max):
```
🚗 BALANCE CAR RUNNER 🚗

Test your skills in this addictive 2D physics-based endless runner! Control a balance car through challenging terrain, dodge obstacles, collect coins, and manage your fuel to survive as long as possible!

🎮 EXCITING GAMEPLAY
• Intuitive tilt or touch controls
• Realistic 2D physics simulation
• Endless procedurally generated levels
• Increasing difficulty as you progress

⛽ FUEL MANAGEMENT SYSTEM
• Keep an eye on your fuel meter!
• Collect fuel pickups to keep going
• Strategic planning needed to survive

🏆 COMPETE FOR HIGH SCORES
• Beat your personal best
• Track your distance traveled
• Earn coins and points for every meter

✨ FEATURES
• Smooth 60 FPS gameplay
• Colorful graphics and animations
• Engaging sound effects and music
• Easy to learn, hard to master
• Completely free to play

🎯 OBJECTIVES
• Travel as far as you can
• Collect coins to boost your score
• Grab fuel pickups before you run out
• Avoid deadly obstacles
• Master the balance mechanics

Perfect for quick gaming sessions or extended play. Can you become the ultimate Balance Car champion?

Download now and start your endless journey!

---
Note: This game contains ads. Support the developer by watching optional video ads for rewards!
```

### Graphics Assets

#### **App Icon (Required)**
- Size: **512 x 512 pixels**
- Format: 32-bit PNG
- No transparency
- No rounded corners (Google applies them)

#### **Feature Graphic (Required)**
- Size: **1024 x 500 pixels**
- Format: JPG or 24-bit PNG (no alpha)
- Showcases your game visually
- Can include game title/logo

#### **Screenshots (Required: at least 2)**
Phone Screenshots:
- Minimum 2, maximum 8
- Dimensions:
  - 16:9 aspect ratio: **1920 x 1080** (landscape)
  - 9:16 aspect ratio: **1080 x 1920** (portrait)
- Format: PNG or JPG
- **Recommended:** 4-6 screenshots showing:
  1. Main menu
  2. Gameplay in action
  3. Fuel/score UI elements
  4. Game over screen
  5. Different obstacles/environments

#### **Promo Video (Optional)**
- YouTube URL
- 30-120 seconds showcasing gameplay
- Very helpful for downloads!

### Categorization

- **Category:** Games > Racing (or Games > Casual)
- **Tags:** racing, physics, endless runner, casual, 2D, cars
- **Email:** your_developer_email@example.com
- **Website (Optional):** Your website or GitHub page

---

## Content Rating

Complete the **Content Rating Questionnaire**:

1. Select **"Start questionnaire"**
2. **Email for certificate:** your_email@example.com

### Balance Car Runner Answers:

#### Violence
- Does app contain depictions of violence? **NO**
- Does app contain any imagery of weapons? **NO**

#### Sexual Content
- Does app contain any sexual content? **NO**

#### Language
- Does app contain profanity or crude humor? **NO**

#### Drugs/Alcohol/Tobacco
- Does app reference or depict drugs, alcohol, or tobacco? **NO**

#### Gambling
- Does app simulate gambling? **NO**

#### User Interaction
- Does app allow users to interact? **NO** (no chat, no user-generated content)
- Can users share location? **NO**
- Does app share personal info? **NO** (only anonymous ad data)

#### Misleading Content
- Does app contain misleading content? **NO**

Based on these answers, your app should receive:
- **ESRB:** Everyone
- **PEGI:** 3+
- **USK:** All ages
- **Generic:** All ages

---

## Data Safety Section

**IMPORTANT:** Google requires detailed data safety declarations.

### Does your app collect or share data?
**YES** (due to AdMob)

### Data Types Collected/Shared:

#### 1. Location (via AdMob)
- **Approximate location:** Collected, Shared
- **Purpose:** Advertising
- **Is this data collected optional?** NO
- **Is this data ephemeral?** YES

#### 2. Device or other IDs (via AdMob)
- **Device or other IDs:** Collected, Shared
- **Purpose:** Advertising, Analytics
- **Is this data collected optional?** NO
- **Is this data ephemeral?** YES

### Data Security
- [ ] Data is encrypted in transit (YES - via HTTPS)
- [ ] Users can request data deletion (YES - via privacy policy email)
- [ ] Data follows Families Policy (if targeting children)
- [ ] Independent security review (Optional, likely NO)

### Data Usage
- **Purpose of data collection:**
  - App functionality (NO)
  - Analytics (YES - for improving app)
  - Advertising or marketing (YES - AdMob)
  - Personalization (YES - personalized ads)

---

## Compliance Checklist

### Technical Requirements
- [ ] **Target API Level 31+** (Android 12 or higher)
- [ ] **64-bit support** (ARM64 architecture)
- [ ] **App Bundle (AAB)** used instead of APK
- [ ] **Signed with production keystore**
- [ ] **Version code increments** with each update
- [ ] **No crashes or ANR** (App Not Responding)

### Policy Requirements
- [ ] **Privacy Policy** created and hosted
- [ ] **Content Rating** completed
- [ ] **Data Safety** section filled
- [ ] **App content declarations** completed
- [ ] **No deceptive behavior**
- [ ] **No malware or spam**
- [ ] **Proper permissions** (only necessary ones)

### AdMob Compliance
- [ ] **AdMob App ID** added to AndroidManifest.xml
- [ ] **Test ads working** properly
- [ ] **Production ads configured** (replace test IDs)
- [ ] **GDPR consent** implemented (for EU users)
- [ ] **COPPA compliant** (if targeting children under 13)

### Store Listing
- [ ] **App icon** (512x512)
- [ ] **Feature graphic** (1024x500)
- [ ] **Screenshots** (minimum 2)
- [ ] **Descriptions** written
- [ ] **Category** selected
- [ ] **Contact email** provided

---

## Submission Process

### 1. Upload App Bundle

1. Go to **Production > Releases**
2. Click **Create new release**
3. Click **Upload** and select your AAB file
4. Unity symbols: Upload if you created symbols.zip
5. **Release name:** `1.0` (or version number)
6. **Release notes:**
   ```
   🎉 Initial release of Balance Car Runner!

   Features:
   • Endless runner gameplay with realistic physics
   • Fuel management system
   • Score and leaderboards
   • Smooth controls and animations
   • Free to play with optional ads

   Enjoy the game and please rate if you like it!
   ```

### 2. Review Release

- Check that app size is reasonable (< 100MB recommended)
- Verify version code and version name
- Ensure production keystore was used

### 3. Save and Review

1. Click **Save** (saves as draft)
2. Complete all other dashboard sections
3. When all tasks are complete, click **Send for review**

### 4. Review Process

- **Typical review time:** 1-7 days
- **Status:** Check in Google Play Console
- **Possible outcomes:**
  - ✅ **Approved:** App goes live
  - ❌ **Rejected:** Fix issues and resubmit
  - ⚠️ **Policy violation:** Address violations and appeal if needed

---

## Post-Launch Tasks

### After App is Live:

1. **Monitor Reviews**
   - Respond to user feedback
   - Fix reported bugs in updates

2. **Track Performance**
   - Install metrics
   - User retention
   - Crash reports

3. **Update Regularly**
   - Bug fixes
   - New features
   - Performance improvements

4. **Marketing**
   - Share on social media
   - Create promo materials
   - Engage with community

---

## Common Rejection Reasons

### How to Avoid Rejection:

1. **Target API Too Low**
   - ✅ Use API 31+ (Android 12)

2. **Missing Privacy Policy**
   - ✅ Add privacy policy URL

3. **Incomplete Data Safety**
   - ✅ Declare all data collection accurately

4. **Missing 64-bit Support**
   - ✅ Build with ARM64 architecture

5. **Permissions Issues**
   - ✅ Only request necessary permissions
   - ✅ Explain permissions in description

6. **Policy Violations**
   - ✅ No deceptive content
   - ✅ No copyright infringement
   - ✅ Family-friendly content

---

## Resources

- [Google Play Console](https://play.google.com/console)
- [Developer Policy Center](https://play.google.com/about/developer-content-policy/)
- [Android App Bundle Guide](https://developer.android.com/guide/app-bundle)
- [Data Safety Help](https://support.google.com/googleplay/android-developer/answer/10787469)
- [AdMob Policy](https://support.google.com/admob/answer/6128543)

---

**Good luck with your submission! 🚀**

---

**Last Updated:** 2025
**Google Play Requirements:** Current as of 2025
**Compliance:** API 31+, 64-bit, Data Safety
