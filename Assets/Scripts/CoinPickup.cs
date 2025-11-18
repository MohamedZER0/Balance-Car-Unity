using UnityEngine;

/// <summary>
/// Coin/Score pickup collectible
/// Place this on coin objects in the scene for score collection
/// </summary>
[RequireComponent(typeof(Collider2D))]
public class CoinPickup : MonoBehaviour
{
    [Header("Pickup Settings")]
    [Tooltip("Points awarded for collecting this coin")]
    public int scoreValue = 100;

    [Tooltip("Auto-destroy after collection")]
    public bool destroyAfterPickup = true;

    [Header("Visual Feedback")]
    [Tooltip("Optional particle effect to spawn on collection")]
    public GameObject pickupEffect;

    [Tooltip("Rotation speed for visual appeal")]
    public float rotationSpeed = 180f;

    [Header("Audio")]
    [Tooltip("Sound to play on collection")]
    public AudioClip pickupSound;

    private bool hasBeenCollected = false;

    private void Start()
    {
        // Ensure the collider is set to trigger
        Collider2D col = GetComponent<Collider2D>();
        if (col != null)
        {
            col.isTrigger = true;
        }
    }

    private void Update()
    {
        // Rotate the coin for visual effect
        if (rotationSpeed > 0f)
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hasBeenCollected) return;

        // Check if the colliding object is the player
        if (collision.CompareTag("Player"))
        {
            CollectCoin();
        }
    }

    /// <summary>
    /// Collect the coin pickup
    /// </summary>
    private void CollectCoin()
    {
        hasBeenCollected = true;

        // Add score to the game manager
        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddScore(scoreValue);
        }

        // Play pickup sound
        if (AudioManager.Instance != null && pickupSound != null)
        {
            AudioManager.Instance.PlaySFX(pickupSound);
        }
        else if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayCoinPickup();
        }

        // Spawn particle effect
        if (pickupEffect != null)
        {
            Instantiate(pickupEffect, transform.position, Quaternion.identity);
        }

        // Destroy or disable the pickup
        if (destroyAfterPickup)
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    #if UNITY_EDITOR
    /// <summary>
    /// Draw gizmo in editor for easy visualization
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, Vector3.one * 0.5f);
    }
    #endif
}
