using UnityEngine;

/// <summary>
/// Periodically spawns the specified prefab in a random location.
/// </summary>
public class Spawner : MonoBehaviour
{
    /// <summary>
    /// Object to spawn
    /// </summary>
    public GameObject Prefab;

    /// <summary>
    /// Seconds between spawn operations
    /// </summary>
    public float SpawnInterval = 20f;

    /// <summary>
    /// Time of the next spawn operation
    /// </summary>
    public float nextSpawnTime = 0f;

    /// <summary>
    /// How many units of free space to try to find around the spawned object
    /// </summary>
    public float FreeRadius = 10;

    /// <summary>
    /// Check if we need to spawn and if so, do so.
    /// </summary>
    // ReSharper disable once UnusedMember.Local
    void Update()
    {
        // TODO
        if (Time.time > nextSpawnTime)
        {
            Spawn();
            nextSpawnTime = Time.time + SpawnInterval;
        }
    }

    void Spawn()
    {
        Vector2 spawnPosition = SpawnUtilities.RandomFreePoint(FreeRadius);
        Instantiate(Prefab, spawnPosition, Quaternion.identity);
    }
}
