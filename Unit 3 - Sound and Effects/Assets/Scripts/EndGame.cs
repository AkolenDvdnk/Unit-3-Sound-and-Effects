using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    public GameObject panel;

    private void Update()
    {
        if (PlayerController.instance.gameOver)
        {
            panel.SetActive(true);
        }

        CheckInput();
    }
    public void CheckInput()
    {
        if (PlayerController.instance.gameOver)
        {
            if (Input.GetKeyDown(KeyCode.R))
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
            if (Input.GetKeyDown(KeyCode.Escape))
                Application.Quit();
    }
}
