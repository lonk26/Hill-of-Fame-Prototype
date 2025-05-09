using UnityEngine;

public class GhostGapSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;

    public Transform spawnerLeft;
    public Transform spawnerMid;
    public Transform spawnerRight;

    public float spawnInterval = 2f;
    public float startDelay = 0f;

    public Vector3 obstacleScale = new Vector3(1f, 1f, 1f); // Set scale in Inspector

    void Start()
    {
        InvokeRepeating(nameof(SpawnWave), startDelay, spawnInterval);
    }

    void SpawnWave()
    {
        int gapIndex = Random.Range(0, 3); // 0 = Left, 1 = Mid, 2 = Right

        if (gapIndex != 0) SpawnObstacle(spawnerLeft);
        if (gapIndex != 1) SpawnObstacle(spawnerMid);
        if (gapIndex != 2) SpawnObstacle(spawnerRight);
    }

    void SpawnObstacle(Transform spawnPoint)
    {
        GameObject obstacle = Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity);
        obstacle.transform.localScale = obstacleScale;
    }
}
