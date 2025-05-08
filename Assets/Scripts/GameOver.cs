using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Drag UI text here in Inspector
    public GameObject gameOverUI;
    // Retry object
    public GameObject retryButton;
    // Assign hit VFX
    public ParticleSystem hitEffect;
    // Reference to the PlayerAnimator
    private Animator playerAnimator;

    void Start()
    {
        // Get the Animator component from the player object
        playerAnimator = GetComponentInParent<Animator>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the player collides with Obstacle
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Check if a hit effect is assigned
            if (hitEffect != null)
            {
                // Instantiate the hit effect at the obstacle's position with no rotation
                ParticleSystem effect = Instantiate(hitEffect, collision.transform.position, Quaternion.identity);
                // Play the VFX animation
                effect.Play();
                // Destroy the VFX GameObject after 1 second to free up memory
                Destroy(effect.gameObject, 1f);
            }


            // Trigger the death animation from the PlayerAnimator script
            if (playerAnimator != null)
            {
                playerAnimator.SetTrigger("Death"); // Use the trigger to play the death animation
            }

            // Stop Player Movement (disable movement script)
            GetComponent<PlayerMovement>().enabled = false;
            // Destroy Obstacle Immediately
            Destroy(collision.gameObject);
            Invoke("ShowGameOverScreen", 0.5f); // 1-second
        }
    }

    void ShowGameOverScreen()
    {
        // Show game over text
        gameOverUI.SetActive(true);
        // Show Retry Button
        retryButton.SetActive(true);
        // Pause game
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
