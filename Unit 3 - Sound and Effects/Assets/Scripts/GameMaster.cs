using UnityEngine;
using TMPro;

public class GameMaster : MonoBehaviour
{
    public static GameMaster instance;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreTextEndGame;
    public GameObject controlText;

    private int score;

    private Transform player;

    [Header("Intro")]
    public float introSpeed = 5f;
    public float introTime = 3f;
    public Vector3 startIntroPos;
    public Vector3 endIntroPos;
    public bool introPlayed = false;

    private void Start()
    {
        instance = this;

        player = PlayerController.instance.transform;
        player.position = startIntroPos;
    }
    private void Update()
    {
        Intro();

        scoreText.text = "Score: " + score;

        if (PlayerController.instance.gameOver)
        {
            scoreTextEndGame.text = scoreText.text;
            scoreText.gameObject.SetActive(false);
            scoreTextEndGame.gameObject.SetActive(true);
        }
    }
    public int IncreaseScore()
    {
        return score++;
    }
    private void Intro()
    {
        PlayerController.instance.WalkAnimation();

        if (!introPlayed)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, endIntroPos, introSpeed * Time.deltaTime);
            introTime -= Time.deltaTime;

            if (introTime <= 0)
            {
                PlayerController.instance.IdleAnimation();

                if (Input.GetKeyDown(KeyCode.F))
                {
                    introPlayed = true;
                }
            }
            return;
        }
        controlText.SetActive(false);
        PlayerController.instance.ResetAnimation();
    }
}
