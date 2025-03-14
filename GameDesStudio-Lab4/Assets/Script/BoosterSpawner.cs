using UnityEngine;

public class BoosterSpawner : MonoBehaviour
{
    public GameObject boosterPrefab; // Drag Booster prefab here
    public float spawnInterval = 10f; // Booster spawns every 10 sec

    void Start()
    {
        InvokeRepeating("SpawnBooster", 5f, spawnInterval);
    }

    void SpawnBooster()
    {
        if (boosterPrefab == null) return; // Prevent errors if no prefab is assigned

        float randomX = Random.Range(-7f, 7f); // Random X position
        float spawnY = 5f; // Adjust spawn height based on your game

        Vector2 spawnPosition = new Vector2(randomX, spawnY);

        GameObject newBooster = Instantiate(boosterPrefab, spawnPosition, Quaternion.identity);

        // Ensure the booster has the movement script
        if (newBooster.GetComponent<Booster>() == null)
        {
            newBooster.AddComponent<Booster>(); // Attach movement script if missing
        }
    }
}
