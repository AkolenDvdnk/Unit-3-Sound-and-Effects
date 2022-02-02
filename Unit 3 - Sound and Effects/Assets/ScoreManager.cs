using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TextMeshProUGUI scoreText;

    private int score;

    private void Start()
    {
        instance = this;
    }
    private void Update()
    {
        scoreText.text = "Score: " + score;
    }
    public int IncreaseScore()
    {
        return score++;
    }
}
