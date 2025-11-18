using UnityEngine;

/// <summary>
/// Handles death/collision events in endless runner mode
/// Triggers game over when player hits obstacles
/// </summary>
public class EndGame : MonoBehaviour
{
    [Header("Game Over Settings")]
    [Tooltip("Delay before showing game over screen")]
    public float gameOverDelay = 0.5f;

    [Header("Effects")]
    [Tooltip("Particle effect to spawn on crash")]
    public GameObject crashEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if colliding with deadly obstacles
        if (collision.CompareTag("Collidable"))
        {
            TriggerGameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Also check for collision-based death
        if (collision.gameObject.CompareTag("Collidable"))
        {
            TriggerGameOver();
        }
    }

    /// <summary>
    /// Trigger game over sequence
    /// </summary>
    private void TriggerGameOver()
    {
        // Prevent multiple triggers
        if (GameManager.Instance != null && GameManager.Instance.isGameOver)
            return;

        // Play crash sound
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayCrash();
            AudioManager.Instance.VibrateHeavy();
        }

        // Spawn crash effect
        if (crashEffect != null)
        {
            Instantiate(crashEffect, transform.position, Quaternion.identity);
        }

        // Trigger game over
        Invoke("CallGameOver", gameOverDelay);
    }

    /// <summary>
    /// Call game over on GameManager
    /// </summary>
    private void CallGameOver()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.GameOver();
        }

        // Stop the car
        CarController car = FindObjectOfType<CarController>();
        if (car != null)
        {
            car.enabled = false;
        }
    }
}
