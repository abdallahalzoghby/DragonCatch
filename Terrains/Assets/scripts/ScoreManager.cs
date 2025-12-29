using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [Header("UI Reference")]
    public Text scoreText;   // اربط الـ Text من الـ Inspector
    [Header("Score Settings")]
    public int score = 0;    // يبدأ من 0

    void Start()
    {
        UpdateScoreUI();
    }

    // تزود نقطة
    public void CollectPoint(int amount = 1)
    {
        score += amount;
        UpdateScoreUI();
    }

    // تحديث النص في الشاشة
    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }

    // تقدر تعمل Reset للسكور
    public void ResetScore()
    {
        score = 0;
        UpdateScoreUI();
    }
}
