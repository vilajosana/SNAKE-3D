using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static int currentScore = 0;
    public static int bestScore = 0;
    public TMP_Text scoreText;
    public TMP_Text bestScoreText;
    public GameObject gameOverCanvas;

    void Start()
    {
        UpdateScoreUI();
        UpdateBestScoreUI();
    }

    public void IncreaseScore()
    {
        currentScore++;
        UpdateScoreUI();

        // Check and update the best score
        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            UpdateBestScoreUI();
        }
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + currentScore.ToString();
    }

    void UpdateBestScoreUI()
    {
        bestScoreText.text = "Best Score: " + bestScore.ToString();
    }

    
}