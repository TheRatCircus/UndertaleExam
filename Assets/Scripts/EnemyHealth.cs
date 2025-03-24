using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Reference to the EnemyObjectt ScriptableObject
    public EnemyObjectt enemyData;

    public float maxHp;
    public float currentHp; 

    private void Start()
    {
        // Initialize the max and current health from the enemy data
        maxHp = enemyData.Hp;
        currentHp = maxHp;
    }

    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(30f); // Deal 30 damage when Space is pressed
            Debug.Log($"Dealt 30 damage! Current HP: {currentHp}");
        }*/
    }


    public void TakeDamage(float damage)
    {
        currentHp -= damage;

        if (currentHp < 0)
            currentHp = 0; // Prevent health from going below 0


        if (currentHp == 0)
        {
            Die();
        }
    }


    private void Die()
    {

        Debug.Log($"{enemyData.Name} has died.");
        gameObject.SetActive(false);
    }
}
