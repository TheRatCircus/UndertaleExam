using UnityEngine;

public class HealingObject : MonoBehaviour
{
    public int healAmount = 5;
    public HealthSystem playerHealthSystem;

    private void Start()
    {
        // Automatically find the object with HealthSystem attached
        if (playerHealthSystem == null)
        {
            playerHealthSystem = FindObjectOfType<HealthSystem>();
        }

        if (playerHealthSystem == null)
        {
            Debug.LogWarning("PlayerHealthSystem not found in the scene!");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (playerHealthSystem != null)
            {
                playerHealthSystem.Heal(healAmount);
                Debug.Log("Player healed by " + healAmount);
                Destroy(gameObject);
            }
            else
            {
                Debug.LogWarning("PlayerHealthSystem is not assigned or found!");
            }
        }
    }
}
