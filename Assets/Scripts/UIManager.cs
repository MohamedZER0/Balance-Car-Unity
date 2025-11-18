using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// Manages all UI elements for the endless runner game
/// Requires Unity UI components to be assigned in the Inspector
/// </summary>
public class UIManager : MonoBehaviour
{
    // Singleton instance
    private static UIManager instance;
    public static UIManager Instance
    {
        get { return instance; }
    }

    [Header("Game UI Panels")]
    public GameObject mainMenuPanel;
    public GameObject gameplayPanel;
    public GameObject gameOverPanel;
    public GameObject pausePanel;

    [Header("Gameplay UI Elements")]
    public Text scoreText;
    public Text distanceText;
    public Image fuelBar;
    public Text fuelPercentText;

    [Header("Game Over UI Elements")]
    public Text finalScoreText;
    public Text highScoreText;
    public Text finalDistanceText;
    public Button restartButton;
    public Button mainMenuButton;
    public Button continueWithAdButton;

    [Header("Main Menu UI Elements")]
    public Button playButton;
    public Text mainMenuHighScoreText;
    public Button settingsButton;
    public Button rateButton;
    public Button removeAdsButton;

    [Header("Pause UI Elements")]
    public Button resumeButton;
    public Button pauseMenuButton;

    [Header("Settings")]
    public GameObject settingsPanel;
    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;
    public Toggle vibrationToggle;

    [Header("Ad Banner Placeholder")]
    public GameObject adBannerPlaceholder;

    private void Awake()
    {
        // Singleton pattern
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;

        // Setup button listeners
        SetupButtonListeners();
    }

    private void Start()
    {
        ShowMainMenu();

        // Show banner ad placeholder
        if (adBannerPlaceholder != null)
        {
            adBannerPlaceholder.SetActive(true);
        }
    }

    /// <summary>
    /// Setup all button click listeners
    /// </summary>
    private void SetupButtonListeners()
    {
        if (playButton != null)
            playButton.onClick.AddListener(OnPlayButtonClicked);

        if (restartButton != null)
            restartButton.onClick.AddListener(OnRestartButtonClicked);

        if (mainMenuButton != null)
            mainMenuButton.onClick.AddListener(OnMainMenuButtonClicked);

        if (continueWithAdButton != null)
            continueWithAdButton.onClick.AddListener(OnContinueWithAdClicked);

        if (resumeButton != null)
            resumeButton.onClick.AddListener(OnResumeButtonClicked);

        if (pauseMenuButton != null)
            pauseMenuButton.onClick.AddListener(OnPauseMenuButtonClicked);

        if (settingsButton != null)
            settingsButton.onClick.AddListener(OnSettingsButtonClicked);

        if (rateButton != null)
            rateButton.onClick.AddListener(OnRateButtonClicked);

        if (removeAdsButton != null)
            removeAdsButton.onClick.AddListener(OnRemoveAdsButtonClicked);

        // Settings sliders
        if (musicVolumeSlider != null)
            musicVolumeSlider.onValueChanged.AddListener(OnMusicVolumeChanged);

        if (sfxVolumeSlider != null)
            sfxVolumeSlider.onValueChanged.AddListener(OnSFXVolumeChanged);

        if (vibrationToggle != null)
            vibrationToggle.onValueChanged.AddListener(OnVibrationToggled);
    }

    #region UI Panel Management

    /// <summary>
    /// Show main menu panel
    /// </summary>
    public void ShowMainMenu()
    {
        SetPanelActive(mainMenuPanel, true);
        SetPanelActive(gameplayPanel, false);
        SetPanelActive(gameOverPanel, false);
        SetPanelActive(pausePanel, false);

        if (mainMenuHighScoreText != null && GameManager.Instance != null)
        {
            mainMenuHighScoreText.text = "High Score: " + GameManager.Instance.GetHighScore();
        }

        Time.timeScale = 1f;
    }

    /// <summary>
    /// Show gameplay UI
    /// </summary>
    public void ShowGameUI()
    {
        SetPanelActive(mainMenuPanel, false);
        SetPanelActive(gameplayPanel, true);
        SetPanelActive(gameOverPanel, false);
        SetPanelActive(pausePanel, false);

        Time.timeScale = 1f;
    }

    /// <summary>
    /// Show game over panel
    /// </summary>
    public void ShowGameOver(int finalScore, int highScore, int distance)
    {
        SetPanelActive(mainMenuPanel, false);
        SetPanelActive(gameplayPanel, false);
        SetPanelActive(gameOverPanel, true);
        SetPanelActive(pausePanel, false);

        if (finalScoreText != null)
            finalScoreText.text = "Score: " + finalScore;

        if (highScoreText != null)
            highScoreText.text = "Best: " + highScore;

        if (finalDistanceText != null)
            finalDistanceText.text = "Distance: " + distance + "m";

        Time.timeScale = 0f;
    }

    /// <summary>
    /// Show pause panel
    /// </summary>
    public void ShowPause()
    {
        SetPanelActive(pausePanel, true);
        Time.timeScale = 0f;
    }

    /// <summary>
    /// Hide pause panel
    /// </summary>
    public void HidePause()
    {
        SetPanelActive(pausePanel, false);
        Time.timeScale = 1f;
    }

    /// <summary>
    /// Helper method to set panel active state
    /// </summary>
    private void SetPanelActive(GameObject panel, bool active)
    {
        if (panel != null)
            panel.SetActive(active);
    }

    #endregion

    #region Update UI Elements

    /// <summary>
    /// Update score display
    /// </summary>
    public void UpdateScore(int score)
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }

    /// <summary>
    /// Update distance display
    /// </summary>
    public void UpdateDistance(int distance)
    {
        if (distanceText != null)
            distanceText.text = distance + "m";
    }

    /// <summary>
    /// Update fuel bar and percentage
    /// </summary>
    public void UpdateFuel(float currentFuel, float maxFuel)
    {
        float fuelPercent = currentFuel / maxFuel;

        if (fuelBar != null)
        {
            fuelBar.fillAmount = fuelPercent;

            // Change color based on fuel level
            if (fuelPercent > 0.5f)
                fuelBar.color = Color.green;
            else if (fuelPercent > 0.25f)
                fuelBar.color = Color.yellow;
            else
                fuelBar.color = Color.red;
        }

        if (fuelPercentText != null)
        {
            fuelPercentText.text = Mathf.CeilToInt(fuelPercent * 100) + "%";
        }
    }

    #endregion

    #region Button Callbacks

    private void OnPlayButtonClicked()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.StartGame();
        }

        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayButtonClick();
        }
    }

    private void OnRestartButtonClicked()
    {
        Time.timeScale = 1f;

        if (GameManager.Instance != null)
        {
            GameManager.Instance.RestartGame();
        }

        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayButtonClick();
        }
    }

    private void OnMainMenuButtonClicked()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayButtonClick();
        }
    }

    private void OnContinueWithAdClicked()
    {
        // This will be connected to actual rewarded ad system
        if (GoogleAdsManager.Instance != null)
        {
            GoogleAdsManager.Instance.ShowRewardedAd();
        }

        if (GameManager.Instance != null)
        {
            GameManager.Instance.ContinueWithAd();
        }

        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayButtonClick();
        }
    }

    private void OnResumeButtonClicked()
    {
        HidePause();

        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayButtonClick();
        }
    }

    private void OnPauseMenuButtonClicked()
    {
        ShowPause();

        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayButtonClick();
        }
    }

    private void OnSettingsButtonClicked()
    {
        if (settingsPanel != null)
        {
            settingsPanel.SetActive(!settingsPanel.activeSelf);
        }

        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayButtonClick();
        }
    }

    private void OnRateButtonClicked()
    {
        // Open Play Store rating page
        #if UNITY_ANDROID
        Application.OpenURL("market://details?id=" + Application.identifier);
        #elif UNITY_IOS
        Application.OpenURL("itms-apps://itunes.apple.com/app/idYOUR_APP_ID");
        #endif

        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayButtonClick();
        }
    }

    private void OnRemoveAdsButtonClicked()
    {
        // This will be connected to in-app purchase system
        if (GoogleAdsManager.Instance != null)
        {
            GoogleAdsManager.Instance.PurchaseRemoveAds();
        }

        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayButtonClick();
        }
    }

    private void OnMusicVolumeChanged(float value)
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.SetMusicVolume(value);
        }
    }

    private void OnSFXVolumeChanged(float value)
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.SetSFXVolume(value);
        }
    }

    private void OnVibrationToggled(bool enabled)
    {
        PlayerPrefs.SetInt("Vibration", enabled ? 1 : 0);
        PlayerPrefs.Save();
    }

    #endregion

    /// <summary>
    /// Show toast message (optional feature)
    /// </summary>
    public void ShowToast(string message)
    {
        Debug.Log("Toast: " + message);
        // Implement toast UI if needed
    }
}
