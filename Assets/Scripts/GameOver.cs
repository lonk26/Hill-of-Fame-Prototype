using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Drag UI text here in Inspector
    public GameObject gameOverUI;
    public GameObject restryButton;
    // 
    void OnCollisionEnter(Collision collision)
    {
        // 
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Show game over text
            gameOverUI.SetActive(true);
            // Show Retry Button
            restryButton.SetActive(true);
            // Pause game
            Time.timeScale = 0;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
