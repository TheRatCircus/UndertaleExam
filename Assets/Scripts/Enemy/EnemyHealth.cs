using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public EnemyObjectt enemyData;
    public Slider healthBar;

    public float maxHp;
    public float currentHp;

    private void Start()
    {
        maxHp = enemyData.Hp;
        currentHp = maxHp;

        if (healthBar != null)
        {
            healthBar.maxValue = maxHp;
            healthBar.value = currentHp;
        }
    }

    private void Update()
    {
        // Debugging purposes
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(30f);
            Debug.Log($"Dealt 30 damage! Current HP: {currentHp}");
        }*/
    }

    public void TakeDamage(float damage)
    {
        currentHp -= damage;
        currentHp = Mathf.Clamp(currentHp, 0, maxHp); // Ensures health stays within bounds

        if (healthBar != null)
        {
            healthBar.value = currentHp;
        }

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
