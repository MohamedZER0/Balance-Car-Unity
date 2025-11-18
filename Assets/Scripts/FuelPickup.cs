using UnityEngine;

/// <summary>
/// Fuel pickup collectible that restores player's fuel
/// Place this on fuel can/gas station objects in the scene
/// </summary>
[RequireComponent(typeof(Collider2D))]
public class FuelPickup : MonoBehaviour
{
    [Header("Pickup Settings")]
    [Tooltip("Amount of fuel to restore when collected")]
    public float fuelAmount = 30f;

    [Tooltip("Points awarded for collecting this fuel")]
    public int scoreValue = 50;

    [Tooltip("Auto-destroy after collection")]
    public bool destroyAfterPickup = true;

    [Header("Visual Feedback")]
    [Tooltip("Optional particle effect to spawn on collection")]
    public GameObject pickupEffect;

    [Tooltip("Rotation speed for visual appeal")]
    public float rotationSpeed = 100f;

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
        // Rotate the pickup for visual effect
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
            CollectFuel();
        }
    }

    /// <summary>
    /// Collect the fuel pickup
    /// </summary>
    private void CollectFuel()
    {
        hasBeenCollected = true;

        // Add fuel to the game manager
        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddFuel(fuelAmount);
            GameManager.Instance.AddScore(scoreValue);
        }

        // Play pickup sound
        if (AudioManager.Instance != null && pickupSound != null)
        {
            AudioManager.Instance.PlaySFX(pickupSound);
        }
        else if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayFuelPickup();
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
        Gizmos.DrawWireSphere(transform.position, 0.5f);
    }
    #endif
}
