using UnityEngine;
using System.Collections;

public class SwitchObject : MonoBehaviour
{
    public Animator animator;
    public GameObject PlayerSoul;
    public EnemyObjectt enemyObject;

    public void StartAnimationWithDelay()
    {
        StartCoroutine(TriggerAnimationWithDelay());
    }

    private IEnumerator TriggerAnimationWithDelay()
    {
        yield return new WaitForSeconds(0.1f);
        animator.SetTrigger("TextIn");

        yield return new WaitForSeconds(0.7f);
        PlayerSoul.SetActive(true);

        yield return new WaitForSeconds(0.5f); // Delay before spawning the prefab

        SpawnRandomPrefab();
    }

    private void SpawnRandomPrefab()
    {
        if (enemyObject != null && enemyObject.AttackPrefabs.Count > 0)
        {
            int randomIndex = Random.Range(0, enemyObject.AttackPrefabs.Count);
            GameObject prefabToSpawn = enemyObject.AttackPrefabs[randomIndex];

            // Instantiate the prefab at the prefab's own original position
            Instantiate(prefabToSpawn, prefabToSpawn.transform.position, Quaternion.identity);
        }
    }
}
