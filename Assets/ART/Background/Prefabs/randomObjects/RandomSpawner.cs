using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject mummyPrefab;
    public int numberObjects;
    private int spawnedCount;

    public Collider spawnAreaCollider; // Reference to the spawn area collider

    IEnumerator SpawnMummies()
    {
        while (spawnedCount < numberObjects)
        {
            // Get the bounds of the spawn area
            Bounds bounds = spawnAreaCollider.bounds;

            // Generate a random position within the bounds of the spawn area
            Vector3 randomSpawnPosition = new Vector3(
                Random.Range(bounds.min.x, bounds.max.x),
                bounds.center.y, // Assuming you want to spawn at the center y level of the collider
                Random.Range(bounds.min.z, bounds.max.z)
            );

            // Spawn the mummy at the generated position
            Instantiate(mummyPrefab, randomSpawnPosition, Random.rotation);
            spawnedCount++;

            // Wait for a second before spawning the next mummy
            yield return new WaitForSeconds(1.0f);
        }
    }

    void Start()
    {
        StartCoroutine(SpawnMummies());
    }
}
