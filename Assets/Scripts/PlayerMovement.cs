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

    // Declares animator
    private Animator animator;

    void Start()
    {
        // Get the Rigidbody component attached to this GameObject
        rb = GetComponent<Rigidbody>();
        // Get the Animator component from the child object (Casual_Hoode)
        animator = GetComponentInChildren<Animator>();

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

        // Animations for running, jumping
        if (animator != null)
        {
            float movementAmount = Mathf.Abs(move.x) + Mathf.Abs(move.z);
            Debug.Log("Speed: " + movementAmount);
            animator.SetFloat("Speed", movementAmount);
        }

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

    public void TriggerDeath()
    {
        // Trigger the death animation in the Animator
        if (animator != null)
        {
            animator.SetTrigger("Death"); // Trigger the death animation when called
        }
    }

}
