using UnityEngine;

public class BirdSpawner : MonoBehaviour
{
    public GameObject birdPrefab; // Assign your bird prefab in the Inspector
    public float spawnInterval = 2f; // Time between spawns
    public float minY = -3f; // Minimum height for spawning
    public float maxY = 3f; // Maximum height for spawning
    public float spawnXOffset = 10f; // Distance from center to spawn on the left or right
    public float minSpacing = 2f; // Minimum spacing to prevent collisions

    private float lastYPosition = 0f;

    void Start()
    {
        // Repeatedly call the SpawnBird function
        InvokeRepeating(nameof(SpawnBird), 0f, spawnInterval);
    }

    void SpawnBird()
    {
        // Determine whether to spawn on the left or right side
        bool spawnOnRight = Random.Range(0, 2) == 0;

        // Generate a valid y position with spacing and parity rules
        float yPosition = GenerateYPosition(spawnOnRight);

        // Set the spawn position
        float xPosition = spawnOnRight ? spawnXOffset : -spawnXOffset;
        Vector3 spawnPosition = new Vector3(xPosition, yPosition, 0f);

        // Instantiate the bird
        GameObject bird = Instantiate(birdPrefab, spawnPosition, Quaternion.identity);

        // Rotate the bird to face the correct direction
        bird.transform.rotation = spawnOnRight ? Quaternion.Euler(0f, -90f, 0f) : Quaternion.Euler(0f, 90f, 0f);

        // Update last y position for spacing control
        lastYPosition = yPosition;
    }

    float GenerateYPosition(bool spawnOnRight)
    {
        float yPosition;
        do
        {
            // Generate a random height within bounds
            yPosition = Random.Range(minY, maxY);

            // Ensure the y position is odd if on the right, even if on the left
            yPosition = spawnOnRight ? (float)((int)Mathf.Round(yPosition) | 1) : (float)((int)Mathf.Round(yPosition) & ~1);
        }
        while (Mathf.Abs(yPosition - lastYPosition) < minSpacing); // Ensure spacing between consecutive spawns

        return yPosition;
    }
}
