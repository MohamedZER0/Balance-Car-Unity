using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Spawns obstacles, coins, and fuel pickups for endless runner
/// Manages object pooling for better performance
/// </summary>
public class ObstacleSpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    [Tooltip("Minimum distance between spawns")]
    public float minSpawnDistance = 10f;

    [Tooltip("Maximum distance between spawns")]
    public float maxSpawnDistance = 20f;

    [Tooltip("Distance ahead of player to spawn")]
    public float spawnDistanceAhead = 50f;

    [Tooltip("Distance behind player to despawn")]
    public float despawnDistanceBehind = 20f;

    [Header("Prefabs")]
    [Tooltip("Array of obstacle prefabs to spawn")]
    public GameObject[] obstaclePrefabs;

    [Tooltip("Fuel pickup prefab")]
    public GameObject fuelPickupPrefab;

    [Tooltip("Coin pickup prefab")]
    public GameObject coinPickupPrefab;

    [Header("Spawn Chances (0-1)")]
    [Tooltip("Chance to spawn an obstacle at each spawn point")]
    [Range(0f, 1f)]
    public float obstacleSpawnChance = 0.7f;

    [Tooltip("Chance to spawn fuel at each spawn point")]
    [Range(0f, 1f)]
    public float fuelSpawnChance = 0.2f;

    [Tooltip("Chance to spawn coins at each spawn point")]
    [Range(0f, 1f)]
    public float coinSpawnChance = 0.5f;

    [Header("Height Variation")]
    [Tooltip("Minimum Y position for spawned objects")]
    public float minHeight = -2f;

    [Tooltip("Maximum Y position for spawned objects")]
    public float maxHeight = 2f;

    [Header("References")]
    [Tooltip("The player transform to track position")]
    public Transform playerTransform;

    // Object pooling
    private List<GameObject> spawnedObjects = new List<GameObject>();
    private float nextSpawnX = 0f;

    private void Start()
    {
        // Find player if not assigned
        if (playerTransform == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                playerTransform = player.transform;
            }
        }

        // Initial spawn position
        nextSpawnX = spawnDistanceAhead;

        // Pre-spawn some objects
        for (int i = 0; i < 10; i++)
        {
            SpawnNext();
        }
    }

    private void Update()
    {
        if (playerTransform == null) return;
        if (GameManager.Instance == null || !GameManager.Instance.isGameActive) return;

        // Spawn objects ahead of player
        while (nextSpawnX < playerTransform.position.x + spawnDistanceAhead)
        {
            SpawnNext();
        }

        // Despawn objects behind player
        DespawnBehindPlayer();
    }

    /// <summary>
    /// Spawn the next set of objects
    /// </summary>
    private void SpawnNext()
    {
        float spawnX = nextSpawnX;
        float spawnY = Random.Range(minHeight, maxHeight);
        Vector3 spawnPosition = new Vector3(spawnX, spawnY, 0f);

        // Decide what to spawn based on chances
        bool spawnedSomething = false;

        // Spawn obstacle
        if (Random.value < obstacleSpawnChance && obstaclePrefabs != null && obstaclePrefabs.Length > 0)
        {
            GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
            if (obstaclePrefab != null)
            {
                GameObject obstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
                spawnedObjects.Add(obstacle);
                spawnedSomething = true;
            }
        }

        // Spawn fuel pickup (less likely if obstacle was spawned)
        if (!spawnedSomething || Random.value < 0.3f)
        {
            if (Random.value < fuelSpawnChance && fuelPickupPrefab != null)
            {
                Vector3 fuelPosition = spawnPosition + Vector3.up * Random.Range(-1f, 1f);
                GameObject fuel = Instantiate(fuelPickupPrefab, fuelPosition, Quaternion.identity);
                spawnedObjects.Add(fuel);
            }
        }

        // Spawn coins (can spawn alongside obstacles at different heights)
        if (Random.value < coinSpawnChance && coinPickupPrefab != null)
        {
            int coinCount = Random.Range(1, 4); // Spawn 1-3 coins
            for (int i = 0; i < coinCount; i++)
            {
                Vector3 coinPosition = new Vector3(
                    spawnX + i * 2f,
                    Random.Range(minHeight, maxHeight),
                    0f
                );
                GameObject coin = Instantiate(coinPickupPrefab, coinPosition, Quaternion.identity);
                spawnedObjects.Add(coin);
            }
        }

        // Update next spawn position
        nextSpawnX += Random.Range(minSpawnDistance, maxSpawnDistance);

        // Increase spawn distance based on difficulty
        if (GameManager.Instance != null)
        {
            float difficulty = GameManager.Instance.GetDifficulty();
            nextSpawnX += difficulty * 5f; // Spawn further apart as difficulty increases
        }
    }

    /// <summary>
    /// Despawn objects that are behind the player
    /// </summary>
    private void DespawnBehindPlayer()
    {
        if (playerTransform == null) return;

        float despawnX = playerTransform.position.x - despawnDistanceBehind;

        // Remove objects that are too far behind
        for (int i = spawnedObjects.Count - 1; i >= 0; i--)
        {
            if (spawnedObjects[i] == null)
            {
                spawnedObjects.RemoveAt(i);
                continue;
            }

            if (spawnedObjects[i].transform.position.x < despawnX)
            {
                Destroy(spawnedObjects[i]);
                spawnedObjects.RemoveAt(i);
            }
        }
    }

    /// <summary>
    /// Clear all spawned objects (useful for game restart)
    /// </summary>
    public void ClearAll()
    {
        foreach (GameObject obj in spawnedObjects)
        {
            if (obj != null)
            {
                Destroy(obj);
            }
        }
        spawnedObjects.Clear();
        nextSpawnX = spawnDistanceAhead;
    }

    #if UNITY_EDITOR
    /// <summary>
    /// Draw spawn zones in editor
    /// </summary>
    private void OnDrawGizmos()
    {
        if (playerTransform == null) return;

        // Draw spawn zone
        Gizmos.color = Color.green;
        Vector3 spawnZoneStart = new Vector3(playerTransform.position.x + spawnDistanceAhead, minHeight, 0f);
        Vector3 spawnZoneEnd = new Vector3(playerTransform.position.x + spawnDistanceAhead, maxHeight, 0f);
        Gizmos.DrawLine(spawnZoneStart, spawnZoneEnd);

        // Draw despawn zone
        Gizmos.color = Color.red;
        Vector3 despawnZoneStart = new Vector3(playerTransform.position.x - despawnDistanceBehind, minHeight, 0f);
        Vector3 despawnZoneEnd = new Vector3(playerTransform.position.x - despawnDistanceBehind, maxHeight, 0f);
        Gizmos.DrawLine(despawnZoneStart, despawnZoneEnd);
    }
    #endif
}
