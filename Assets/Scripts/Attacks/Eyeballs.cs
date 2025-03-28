using UnityEngine;
using System.Collections;

public class Eyeballs : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject objectToSpawn;
    public int numberOfObjects = 5;
    public float spawnAreaSize = 5f;
    public float spawnDelay = 0.5f;

    void Start()
    {
        StartCoroutine(SpawnEyeballs());
    }

    IEnumerator SpawnEyeballs()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            float randomX = Random.Range(-spawnAreaSize / 2, spawnAreaSize / 2);
            float randomY = Random.Range(-spawnAreaSize / 2, spawnAreaSize / 2);
            Vector3 spawnPosition = new Vector3(randomX, randomY, 0f) + spawnPoint.position;
            GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
            spawnedObject.transform.SetParent(spawnPoint);

            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
