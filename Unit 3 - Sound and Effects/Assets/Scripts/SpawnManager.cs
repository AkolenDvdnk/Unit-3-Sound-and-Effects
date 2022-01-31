using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float startDelay;
    public float repeatRate;

    public GameObject obstaclePrefab;

    private Vector3 spawnPos = new Vector3(25f, 0, 0);
    
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }
    private void SpawnObstacle()
    {
        if (!PlayerController.instance.gameOver)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
    }
}
