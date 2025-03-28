using UnityEngine;

public class Damage : MonoBehaviour
{
    public float damage = 5f;  

    private HealthSystem healthSystem; 

    void Start()
    {
        healthSystem = GameObject.FindObjectOfType<HealthSystem>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (healthSystem != null)
            {
                healthSystem.TakeDamage((int)damage);  
                Debug.Log("Damage applied to player: " + damage);
            }
            Destroy(gameObject);
        }
    }
}
