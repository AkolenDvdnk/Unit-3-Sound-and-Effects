using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    public float startDelay;
    public float repeatRate;

    public GameObject obstaclePrefab;

    private Vector3 spawnPos = new Vector3(25f, 0, 0);
    
    void Start()
    {
        StartCoroutine(SpawnObstacle());
    }
    private IEnumerator SpawnObstacle()
    {
        yield return new WaitForSeconds(startDelay);

        GameObject prefab = (GameObject)Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        Destroy(prefab, 3f);

        yield return new WaitForSeconds(repeatRate);
    }

}
