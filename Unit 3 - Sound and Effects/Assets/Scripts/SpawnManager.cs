using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float startDelay;
    public float repeatRateMin;
    public float repeatRateMax;

    public GameObject[] obstaclePrefabs;

    private float maxSpawnPos = 60f;
    private float minSpawnPos = 50f;
    
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, Random.Range(repeatRateMin, repeatRateMax));
    }
    private void SpawnObstacle()
    {
        if (GameMaster.instance.introPlayed)
        {
            if (!PlayerController.instance.gameOver)
            {
                Vector3 spawnPoint = new Vector3(Random.Range(minSpawnPos, maxSpawnPos), 0, transform.position.z);
                Obstacle(spawnPoint);
            }
        }
    }
    private GameObject Obstacle(Vector3 point)
    {
        int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);
        return Instantiate(obstaclePrefabs[obstacleIndex], point, obstaclePrefabs[obstacleIndex].transform.rotation);
    }
}
