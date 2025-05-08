using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float spawnInterval = 2f;
    public float startDelay = 0f;
     [Header("Obstacle Settings")]
    public Vector3 obstacleScale = Vector3.one;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(SpawnObstacle), startDelay, spawnInterval);
    }

    void SpawnObstacle()
    {
        GameObject obstacle = Instantiate(obstaclePrefab, transform.position, Quaternion.identity);
        obstacle.transform.localScale = obstacleScale;
    }
}
