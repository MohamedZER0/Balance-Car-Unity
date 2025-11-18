using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Main game manager for endless runner mode
/// Handles score, fuel, game state, and player progression
/// </summary>
public class GameManager : MonoBehaviour
{
    // Singleton instance
    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();
                if (instance == null)
                {
                    GameObject go = new GameObject("GameManager");
                    instance = go.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }

    [Header("Score Settings")]
    public float scoreMultiplier = 10f; // Points per second
    public int coinValue = 50; // Points per coin collected
    private float currentScore = 0f;
    private float highScore = 0f;
    private float distanceTraveled = 0f;

    [Header("Fuel Settings")]
    public float maxFuel = 100f;
    public float fuelConsumptionRate = 5f; // Fuel consumed per second
    public float fuelPickupAmount = 30f; // Fuel restored per pickup
    private float currentFuel = 100f;

    [Header("Game State")]
    public bool isGameActive = false;
    public bool isGameOver = false;

    [Header("Difficulty Settings")]
    public float difficultyIncreaseInterval = 30f; // Increase difficulty every 30 seconds
    public float maxDifficulty = 3f;
    private float currentDifficulty = 1f;
    private float gameTime = 0f;

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

        // Load high score
        highScore = PlayerPrefs.GetFloat("HighScore", 0f);
    }

    private void Start()
    {
        ResetGame();
    }

    private void Update()
    {
        if (!isGameActive || isGameOver) return;

        gameTime += Time.deltaTime;

        // Update score based on time survived
        currentScore += scoreMultiplier * Time.deltaTime;
        distanceTraveled += Time.deltaTime * 10f; // Arbitrary distance calculation

        // Consume fuel over time
        currentFuel -= fuelConsumptionRate * Time.deltaTime;

        // Check if fuel is depleted
        if (currentFuel <= 0f)
        {
            currentFuel = 0f;
            GameOver();
        }

        // Increase difficulty over time
        currentDifficulty = Mathf.Min(maxDifficulty, 1f + (gameTime / difficultyIncreaseInterval));

        // Update UI
        if (UIManager.Instance != null)
        {
            UIManager.Instance.UpdateScore((int)currentScore);
            UIManager.Instance.UpdateFuel(currentFuel, maxFuel);
            UIManager.Instance.UpdateDistance((int)distanceTraveled);
        }
    }

    /// <summary>
    /// Start the game
    /// </summary>
    public void StartGame()
    {
        isGameActive = true;
        isGameOver = false;
        currentFuel = maxFuel;
        currentScore = 0f;
        distanceTraveled = 0f;
        gameTime = 0f;
        currentDifficulty = 1f;

        if (UIManager.Instance != null)
        {
            UIManager.Instance.ShowGameUI();
        }
    }

    /// <summary>
    /// End the game
    /// </summary>
    public void GameOver()
    {
        if (isGameOver) return;

        isGameOver = true;
        isGameActive = false;

        // Update high score
        if (currentScore > highScore)
        {
            highScore = currentScore;
            PlayerPrefs.SetFloat("HighScore", highScore);
            PlayerPrefs.Save();
        }

        // Show game over UI
        if (UIManager.Instance != null)
        {
            UIManager.Instance.ShowGameOver((int)currentScore, (int)highScore, (int)distanceTraveled);
        }

        // Show rewarded ad for continue (placeholder)
        if (GoogleAdsManager.Instance != null)
        {
            GoogleAdsManager.Instance.ShowInterstitialAd();
        }
    }

    /// <summary>
    /// Restart the current game
    /// </summary>
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        ResetGame();
    }

    /// <summary>
    /// Reset game state
    /// </summary>
    public void ResetGame()
    {
        currentScore = 0f;
        currentFuel = maxFuel;
        distanceTraveled = 0f;
        gameTime = 0f;
        currentDifficulty = 1f;
        isGameActive = false;
        isGameOver = false;
    }

    /// <summary>
    /// Add score to the current total
    /// </summary>
    public void AddScore(int points)
    {
        if (!isGameActive || isGameOver) return;
        currentScore += points;
    }

    /// <summary>
    /// Add fuel to the current total
    /// </summary>
    public void AddFuel(float amount)
    {
        if (!isGameActive || isGameOver) return;
        currentFuel = Mathf.Min(currentFuel + amount, maxFuel);
    }

    /// <summary>
    /// Get current difficulty multiplier
    /// </summary>
    public float GetDifficulty()
    {
        return currentDifficulty;
    }

    /// <summary>
    /// Get current score
    /// </summary>
    public int GetScore()
    {
        return (int)currentScore;
    }

    /// <summary>
    /// Get current fuel amount
    /// </summary>
    public float GetFuel()
    {
        return currentFuel;
    }

    /// <summary>
    /// Get high score
    /// </summary>
    public int GetHighScore()
    {
        return (int)highScore;
    }

    /// <summary>
    /// Continue game after watching rewarded ad (to be implemented with actual ads)
    /// </summary>
    public void ContinueWithAd()
    {
        currentFuel = maxFuel * 0.5f; // Restore 50% fuel
        isGameOver = false;
        isGameActive = true;

        if (UIManager.Instance != null)
        {
            UIManager.Instance.ShowGameUI();
        }
    }
}
