using UnityEngine;

public class JumpGapSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;           // normal rolling ball
    public GameObject jumpableObstaclePrefab;   // football (jumpable)
    
    public Transform[] spawners;                // 4 spawners total
    public float spawnInterval = 2f;
    public float startDelay = 0f;

    public float obstacleMass = 1f;
    public Vector3 obstacleScale = Vector3.one;
    public Vector3 jumpableObstacleScale = new Vector3(1f, 1f, 1f);
    public float rollForce = 5f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnWave), startDelay, spawnInterval);
    }

    void SpawnWave()
    {
        int jumpIndex = Random.Range(0, spawners.Length);

        for (int i = 0; i < spawners.Length; i++)
        {
            if (i == jumpIndex)
            {
                SpawnJumpableObstacle(spawners[i]);
            }
            else
            {
                SpawnRollingObstacle(spawners[i]);
            }
        }
    }

    void SpawnRollingObstacle(Transform spawnPoint)
    {
        GameObject obj = Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity);
        obj.transform.localScale = obstacleScale;

        Rigidbody rb = obj.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.mass = obstacleMass;
            rb.useGravity = true;
            rb.isKinematic = false;
            rb.AddForce(Vector3.back * rollForce, ForceMode.Impulse); // Roll downhill
        }
    }

    void SpawnJumpableObstacle(Transform spawnPoint)
    {
        GameObject obj = Instantiate(jumpableObstaclePrefab, spawnPoint.position, Quaternion.identity);
        obj.transform.localScale = jumpableObstacleScale;

        Rigidbody rb = obj.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.mass = obstacleMass;
            rb.useGravity = true;
            rb.isKinematic = false;
            rb.AddForce(Vector3.back * rollForce, ForceMode.Impulse); // Make it roll too
        }
    }
}
