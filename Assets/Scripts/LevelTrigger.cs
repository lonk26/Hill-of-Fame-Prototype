using UnityEngine;

public class LevelTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.Instance?.IncreaseLevel();
            gameObject.SetActive(false); // Disable trigger after one use
        }
    }
}
