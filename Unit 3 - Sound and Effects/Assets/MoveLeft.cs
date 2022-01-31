using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed;

    private float leftBound = -15f;

    private void Update()
    {
        if (!PlayerController.instance.gameOver)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}
