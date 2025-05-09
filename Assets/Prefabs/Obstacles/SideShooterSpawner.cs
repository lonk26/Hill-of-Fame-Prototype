using UnityEngine;

public class SideShooterSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float spawnInterval = 1.5f;
    public float startDelay = 0f;
    public float forceAmount = 10f;
    public float spreadAngle = 20f; // Limit horizontal spread
    public float obstacleMass = 1f;
    public Vector3 obstacleScale = Vector3.one;
    public PhysicsMaterial physicsMaterial;

    void Start()
    {
        InvokeRepeating(nameof(SpawnObstacle), startDelay, spawnInterval);
    }

    void SpawnObstacle()
    {
        GameObject obstacle = Instantiate(obstaclePrefab, transform.position, Quaternion.identity);
        obstacle.transform.localScale = obstacleScale;

        Rigidbody rb = obstacle.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.mass = obstacleMass;

            // Flip base direction to shoot toward player (not toward next level)
            Vector3 baseDirection = -transform.forward;

            float angle = Random.Range(-spreadAngle, spreadAngle);
            Quaternion rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 shootDirection = rotation * baseDirection;

            rb.AddForce(shootDirection.normalized * forceAmount, ForceMode.Impulse);
        }

        Collider col = obstacle.GetComponent<Collider>();
        if (col != null && physicsMaterial != null)
        {
            col.material = physicsMaterial;
        }
    }
}
