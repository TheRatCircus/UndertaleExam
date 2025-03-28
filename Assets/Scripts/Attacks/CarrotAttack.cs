using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotAttack : MonoBehaviour
{
    public List<GameObject> spawnableObjects;
    public Transform spawnPoint;
    public float spawnDelay = 0.4f;
    public float randomRange = 2f; 

    private void Start()
    {
        StartCoroutine(SpawnObjects());
    }

    private IEnumerator SpawnObjects()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);
            SpawnRandomObject();
        }
    }

    private void SpawnRandomObject()
    {
        if (spawnableObjects.Count == 0 || spawnPoint == null)
        {
            Debug.LogWarning("No objects to spawn or spawn point not set.");
            return;
        }

        int randomIndex = Random.Range(0, spawnableObjects.Count);

        float randomX = spawnPoint.position.x + Random.Range(-randomRange, randomRange);

        Vector3 spawnPosition = new Vector3(randomX, spawnPoint.position.y, spawnPoint.position.z);

        GameObject spawnedObject = Instantiate(spawnableObjects[randomIndex], spawnPosition, Quaternion.identity);
        Destroy(spawnedObject, 1.1f);
    }
}
