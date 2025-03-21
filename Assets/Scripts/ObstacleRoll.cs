using UnityEngine;

public class ObstacleRoll : MonoBehaviour
{
    // Set a roll speed for the obstacle
    public float rollSpeed = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(Vector3.back * rollSpeed, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
