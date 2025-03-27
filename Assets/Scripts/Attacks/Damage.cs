using UnityEngine;

public class Damage : MonoBehaviour
{
    public float damage = 5f;  // Damage value to apply to the player's health

    private HealthSystem healthSystem; // Reference to the player's health system

    void Start()
    {
        // Try to get the HealthSystem component from the empty GameObject
        healthSystem = GameObject.FindObjectOfType<HealthSystem>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object collided with has the "Player" tag
        if (other.CompareTag("Player"))
        {
            // Ensure the healthSystem is not null before applying damage
            if (healthSystem != null)
            {
                healthSystem.TakeDamage((int)damage);  // Cast the float damage to int
                Debug.Log("Damage applied to player: " + damage);
            }

            // Optionally, destroy the object that applied the damage (like a fly, projectile, etc.)
            Destroy(gameObject);
        }
    }
}
