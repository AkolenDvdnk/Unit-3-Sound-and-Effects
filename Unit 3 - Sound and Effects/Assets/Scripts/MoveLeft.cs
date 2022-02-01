﻿using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed;

    private float leftBound = -15f;

    private void Update()
    {
        if (!PlayerController.instance.gameOver)
        {
            if (PlayerController.instance.isRunning)
            {
                transform.Translate(Vector3.left * (speed * 2f) * Time.deltaTime);
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
