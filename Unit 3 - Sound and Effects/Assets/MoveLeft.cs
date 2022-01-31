using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
