using UnityEngine;

public class ObstacleRoll : MonoBehaviour
{
    public float rollForce = 5f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Apply rolling force along negative Z (downhill)
        rb.AddForce(Vector3.back * rollForce, ForceMode.Impulse);
    }
}
