using UnityEngine;

/// <summary>
/// Checkpoint/Goal system for endless runner
/// In endless mode, goals act as checkpoints that give bonus score
/// </summary>
public class Goal : MonoBehaviour
{
    [Header("Checkpoint Settings")]
    [Tooltip("Score bonus for reaching this checkpoint")]
    public int checkpointBonus = 500;

    [Tooltip("Fuel bonus for reaching checkpoint")]
    public float fuelBonus = 20f;

    [Tooltip("Should this checkpoint be destroyed after collection?")]
    public bool destroyAfterUse = true;

    [Header("Visual Feedback")]
    [Tooltip("Particle effect on checkpoint reach")]
    public GameObject checkpointEffect;

    private bool hasBeenReached = false;

    private void Start()
    {
        // Ensure the collider is set to trigger
        Collider2D col = GetComponent<Collider2D>();
        if (col != null)
        {
            col.isTrigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hasBeenReached) return;

        if (collision.CompareTag("Player"))
        {
            ReachCheckpoint();
        }
    }

    /// <summary>
    /// Reached checkpoint - give bonuses
    /// </summary>
    private void ReachCheckpoint()
    {
        hasBeenReached = true;

        Debug.Log("Checkpoint reached! Bonus: " + checkpointBonus);

        // Give bonuses
        if (GameManager.Instance != null)
        {
            GameManager.Instance.AddScore(checkpointBonus);
            GameManager.Instance.AddFuel(fuelBonus);
        }

        // Play sound
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.PlayCoinPickup(); // Reuse coin sound or create custom
        }

        // Spawn effect
        if (checkpointEffect != null)
        {
            Instantiate(checkpointEffect, transform.position, Quaternion.identity);
        }

        // Destroy or keep checkpoint
        if (destroyAfterUse)
        {
            Destroy(gameObject, 0.1f);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }

    #if UNITY_EDITOR
    /// <summary>
    /// Draw gizmo in editor
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, Vector3.one);
    }
    #endif
}

