using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // UI elements assigned via Inspector
    public GameObject gameOverUI;
    public GameObject retryButton;
    public ParticleSystem hitEffect;

    void OnCollisionEnter(Collision collision)
    {
        // If player hits an object tagged as "Obstacle"
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Play hit visual effect if one is assigned
            if (hitEffect != null)
            {
                ParticleSystem effect = Instantiate(hitEffect, collision.transform.position, Quaternion.identity);
                effect.Play();
                Destroy(effect.gameObject, 1f); // clean up after 1 sec
            }

            // Stop player movement
            GetComponent<PlayerMovement>().enabled = false;

            // Destroy the obstacle
            Destroy(collision.gameObject);

            // Trigger Game Over screen after short delay
            Invoke("ShowGameOverScreen", 0.5f);
        }
    }

    void ShowGameOverScreen()
    {
        // Show UI and stop time
        gameOverUI.SetActive(true);
        retryButton.SetActive(true);
        Time.timeScale = 0;
    }
}
