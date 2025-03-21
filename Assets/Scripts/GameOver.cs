using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // 
    void OnCollisionEnter(Collision collision)
    {
        // 
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Console log for testing
            Debug.Log("Game Over!");
            // Restart level
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
