using UnityEngine;

public class ObstacleRoll : MonoBehaviour
{
    public float rollSpeed = 5f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.AddForce(Vector3.back * rollSpeed, ForceMode.Force);
    }
}
