using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TextMeshProUGUI scoreText;

    private int score;

    private Animator animator;

    private void Awake()
    {
        animator = scoreText.gameObject.GetComponent<Animator>();
    }
    private void Start()
    {
        instance = this;
    }
    private void Update()
    {
        scoreText.text = "Score: " + score;

        if (PlayerController.instance.gameOver)
        {
            animator.SetBool("GameOver", true);
        }
    }
    public int IncreaseScore()
    {
        return score++;
    }
}
