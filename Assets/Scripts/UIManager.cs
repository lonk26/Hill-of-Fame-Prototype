using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI timeText;

    void Update()
    {
        if (ScoreManager.Instance != null)
        {
            levelText.text = "Level: " + ScoreManager.Instance.Level;
            timeText.text = $"Time: {ScoreManager.Instance.GetMinutes():00}:{ScoreManager.Instance.GetSeconds():00}";
        }
    }
}
