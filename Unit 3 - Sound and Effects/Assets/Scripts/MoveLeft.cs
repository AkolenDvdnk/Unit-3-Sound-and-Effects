using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed;

    private float leftBound = -15f;

    private void Update()
    {
        if (GameMaster.instance.introPlayed)
        {
            if (!PlayerController.instance.gameOver)
            {
                if (PlayerController.instance.isRunning)
                {
                    transform.Translate(Vector3.left * (speed * 1.5f) * Time.deltaTime);
                }
                else
                {
                    transform.Translate(Vector3.left * speed * Time.deltaTime);
                }
            }
            if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
            {
                Destroy(gameObject);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameMaster.instance.IncreaseScore();
        }
    }
}
