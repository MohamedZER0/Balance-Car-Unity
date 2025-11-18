using UnityEngine;

/// <summary>
/// Audio Manager for handling all game sounds
/// Manages background music, sound effects, and audio settings
/// </summary>
[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    // Singleton instance
    private static AudioManager instance;
    public static AudioManager Instance
    {
        get { return instance; }
    }

    [Header("Audio Sources")]
    [Tooltip("Audio source for background music")]
    public AudioSource musicSource;

    [Tooltip("Audio source for sound effects")]
    public AudioSource sfxSource;

    [Header("Background Music")]
    [Tooltip("Background music clip")]
    public AudioClip backgroundMusic;

    [Tooltip("Game over music clip")]
    public AudioClip gameOverMusic;

    [Header("Sound Effects")]
    [Tooltip("Button click sound")]
    public AudioClip buttonClickSFX;

    [Tooltip("Coin pickup sound")]
    public AudioClip coinPickupSFX;

    [Tooltip("Fuel pickup sound")]
    public AudioClip fuelPickupSFX;

    [Tooltip("Crash/collision sound")]
    public AudioClip crashSFX;

    [Tooltip("Engine/motor sound")]
    public AudioClip engineSFX;

    [Tooltip("Low fuel warning sound")]
    public AudioClip lowFuelWarningSFX;

    [Header("Volume Settings")]
    [Range(0f, 1f)]
    public float musicVolume = 0.7f;

    [Range(0f, 1f)]
    public float sfxVolume = 1f;

    [Header("Low Fuel Warning")]
    public float lowFuelThreshold = 25f; // Percentage
    private bool lowFuelWarningPlayed = false;

    private void Awake()
    {
        // Singleton pattern
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);

        // Setup audio sources
        if (musicSource == null)
        {
            musicSource = gameObject.AddComponent<AudioSource>();
        }

        if (sfxSource == null)
        {
            sfxSource = gameObject.AddComponent<AudioSource>();
        }

        musicSource.loop = true;
        musicSource.playOnAwake = false;
        sfxSource.playOnAwake = false;

        // Load saved volume settings
        LoadVolumeSettings();
    }

    private void Start()
    {
        PlayBackgroundMusic();
    }

    private void Update()
    {
        // Check for low fuel warning
        if (GameManager.Instance != null && GameManager.Instance.isGameActive)
        {
            float fuelPercent = (GameManager.Instance.GetFuel() / GameManager.Instance.maxFuel) * 100f;

            if (fuelPercent < lowFuelThreshold && !lowFuelWarningPlayed)
            {
                PlayLowFuelWarning();
                lowFuelWarningPlayed = true;
            }
            else if (fuelPercent >= lowFuelThreshold)
            {
                lowFuelWarningPlayed = false;
            }
        }
    }

    #region Background Music

    /// <summary>
    /// Play background music
    /// </summary>
    public void PlayBackgroundMusic()
    {
        if (backgroundMusic != null && musicSource != null)
        {
            musicSource.clip = backgroundMusic;
            musicSource.volume = musicVolume;
            musicSource.Play();
        }
    }

    /// <summary>
    /// Play game over music
    /// </summary>
    public void PlayGameOverMusic()
    {
        if (gameOverMusic != null && musicSource != null)
        {
            musicSource.clip = gameOverMusic;
            musicSource.volume = musicVolume;
            musicSource.loop = false;
            musicSource.Play();
        }
    }

    /// <summary>
    /// Stop background music
    /// </summary>
    public void StopMusic()
    {
        if (musicSource != null)
        {
            musicSource.Stop();
        }
    }

    #endregion

    #region Sound Effects

    /// <summary>
    /// Play a generic sound effect
    /// </summary>
    public void PlaySFX(AudioClip clip)
    {
        if (clip != null && sfxSource != null)
        {
            sfxSource.PlayOneShot(clip, sfxVolume);
        }
    }

    /// <summary>
    /// Play button click sound
    /// </summary>
    public void PlayButtonClick()
    {
        PlaySFX(buttonClickSFX);
    }

    /// <summary>
    /// Play coin pickup sound
    /// </summary>
    public void PlayCoinPickup()
    {
        PlaySFX(coinPickupSFX);
    }

    /// <summary>
    /// Play fuel pickup sound
    /// </summary>
    public void PlayFuelPickup()
    {
        PlaySFX(fuelPickupSFX);
    }

    /// <summary>
    /// Play crash sound
    /// </summary>
    public void PlayCrash()
    {
        PlaySFX(crashSFX);
    }

    /// <summary>
    /// Play engine sound
    /// </summary>
    public void PlayEngine()
    {
        PlaySFX(engineSFX);
    }

    /// <summary>
    /// Play low fuel warning sound
    /// </summary>
    public void PlayLowFuelWarning()
    {
        PlaySFX(lowFuelWarningSFX);
    }

    #endregion

    #region Volume Control

    /// <summary>
    /// Set music volume
    /// </summary>
    public void SetMusicVolume(float volume)
    {
        musicVolume = Mathf.Clamp01(volume);
        if (musicSource != null)
        {
            musicSource.volume = musicVolume;
        }
        SaveVolumeSettings();
    }

    /// <summary>
    /// Set SFX volume
    /// </summary>
    public void SetSFXVolume(float volume)
    {
        sfxVolume = Mathf.Clamp01(volume);
        SaveVolumeSettings();
    }

    /// <summary>
    /// Mute/unmute all audio
    /// </summary>
    public void ToggleMute()
    {
        AudioListener.volume = AudioListener.volume > 0 ? 0 : 1;
    }

    /// <summary>
    /// Save volume settings to PlayerPrefs
    /// </summary>
    private void SaveVolumeSettings()
    {
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
        PlayerPrefs.SetFloat("SFXVolume", sfxVolume);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// Load volume settings from PlayerPrefs
    /// </summary>
    private void LoadVolumeSettings()
    {
        musicVolume = PlayerPrefs.GetFloat("MusicVolume", 0.7f);
        sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 1f);

        if (musicSource != null)
        {
            musicSource.volume = musicVolume;
        }
    }

    #endregion

    #region Vibration (Android/iOS)

    /// <summary>
    /// Trigger haptic vibration (mobile only)
    /// </summary>
    public void Vibrate()
    {
        #if UNITY_ANDROID || UNITY_IOS
        if (PlayerPrefs.GetInt("Vibration", 1) == 1)
        {
            Handheld.Vibrate();
        }
        #endif
    }

    /// <summary>
    /// Light vibration for UI feedback
    /// </summary>
    public void VibrateLight()
    {
        // For more advanced haptics, you would use platform-specific plugins
        Vibrate();
    }

    /// <summary>
    /// Heavy vibration for crashes/impacts
    /// </summary>
    public void VibrateHeavy()
    {
        // For more advanced haptics, you would use platform-specific plugins
        Vibrate();
    }

    #endregion
}
