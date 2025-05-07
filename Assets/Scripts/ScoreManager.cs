using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    public int Level { get; private set; } = 0;
    private float elapsedTime = 0f;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
    }

    public void IncreaseLevel()
    {
        Level++;
    }

    public int GetMinutes()
    {
        return Mathf.FloorToInt(elapsedTime / 60f);
    }

    public int GetSeconds()
    {
        return Mathf.FloorToInt(elapsedTime % 60f);
    }
}
