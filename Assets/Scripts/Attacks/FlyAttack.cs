using System.Collections;
using UnityEngine;

public class FlyAttack : MonoBehaviour
{
    public float speed = 5f;
    public float pauseTime = 0.3f;
    public float pauseDuration = 0.1f;
    public float separationDistance = 1.5f;
    public float damage = 5f;  // Damage the fly does to the player

    private Transform player;
    private bool isMoving = false;
    private Vector2 moveDirection;

    private HealthSystem healthSystem; // Reference to the player's health system

    void Start()
    {
        // Try to get the HealthSystem component from the empty GameObject
        healthSystem = GameObject.FindObjectOfType<HealthSystem>();

        if (healthSystem != null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;  // Get the player for movement purpose
        }

        float initialDelay = Random.Range(0f, 0.04f);
        StartCoroutine(DelayedStart(initialDelay));
    }

    void Update()
    {
        if (isMoving)
        {
            Vector2 newPosition = (Vector2)transform.position + moveDirection * speed * Time.deltaTime;

            if (IsPositionValid(newPosition))
            {
                transform.position = newPosition;
            }
        }
    }

    IEnumerator DelayedStart(float delay)
    {
        yield return new WaitForSeconds(delay);
        StartCoroutine(MovementCycle());
    }

    IEnumerator MovementCycle()
    {
        while (true)
        {
            yield return new WaitForSeconds(pauseTime);
            isMoving = false;
            yield return new WaitForSeconds(pauseDuration);
            if (player != null)
            {
                moveDirection = (player.position - transform.position).normalized;
            }
            isMoving = true;
        }
    }

    bool IsPositionValid(Vector2 targetPosition)
    {
        foreach (FlyAttack other in FindObjectsOfType<FlyAttack>())
        {
            if (other != this)
            {
                float distance = Vector2.Distance(other.transform.position, targetPosition);
                if (distance < separationDistance)
                {
                    return false;
                }
            }
        }
        return true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (healthSystem != null)
            {
                // Use the healthSystem from the empty GameObject to apply damage to the player
                healthSystem.TakeDamage((int)damage);  // Cast the float damage to int
            }

            // Destroy the FlyAttack object after it deals damage
            Destroy(gameObject);
        }
    }
}
