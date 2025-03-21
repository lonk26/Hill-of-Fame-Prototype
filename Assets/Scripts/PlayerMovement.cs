using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Movement speed
    public float speed = 5.0f;
    // Jump force
    public float jumpForce = 5.0f;
    // Reference to the Rigidbody component attached to this GameObject
    private Rigidbody rb;
    // Check if the player is on the ground
    private bool isGrounded = true;
    
    
    void Start()
    {
        // Get the Rigidbody component attached to this GameObject
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get input for movement (WASD or Arrow Keys)
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        // Move the player based on input
        Vector3 move = new Vector3(moveX, 0.0f, moveY) * speed * Time.deltaTime;
        transform.Translate(move, Space.World);

        // Jump when Spacebar is pressed and Player on the ground
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) 
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    // Check for collisions with ground
    void OnCollisionEnter(Collision collision)
    {
        // If the collision is with the ground, set isGrounded to true
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
