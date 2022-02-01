using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    private int Score;

    private void Start()
    {
        instance = this;
    }
    private void Update()
    {
        Debug.Log(Score);
    }
    public int IncreaseScore()
    {
        return Score++;
    }
}
