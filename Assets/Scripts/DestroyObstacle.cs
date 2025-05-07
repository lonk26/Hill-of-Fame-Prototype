using UnityEngine;

public class DestroyObstacle : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle")) {
            Destroy(other.gameObject);
        }
    }
}
