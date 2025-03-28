using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public int maxHP = 20;
    public int currentHP;
    public Slider healthSlider;
    public Text healthText;
    public GameObject gameOverScreen;
    public HealthSystem playerHealthSystem; 

    void Start()
    {
        currentHP = maxHP; 
        healthSlider.maxValue = maxHP;
        healthSlider.value = currentHP;
        UpdateHealthUI();

        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(false); 
        }

        if (playerHealthSystem != null)
        {
            playerHealthSystem.currentHP = currentHP;
            playerHealthSystem.maxHP = maxHP;
        }
    }

    void Update()
    {
        if (playerHealthSystem != null)
        {
            healthSlider.value = playerHealthSystem.currentHP;
            UpdateHealthUI();
        }
    }

    public void TakeDamage(int damage)
    {
        if (playerHealthSystem != null)
        {
            playerHealthSystem.currentHP -= damage;
            playerHealthSystem.currentHP = Mathf.Clamp(playerHealthSystem.currentHP, 0, playerHealthSystem.maxHP);
            healthSlider.value = playerHealthSystem.currentHP;
            UpdateHealthUI();

            if (playerHealthSystem.currentHP <= 0)
            {
                Die();
            }
        }
    }

    public void Heal(int healAmount)
    {
        if (playerHealthSystem != null)
        {
            playerHealthSystem.currentHP += healAmount;
            playerHealthSystem.currentHP = Mathf.Clamp(playerHealthSystem.currentHP, 0, playerHealthSystem.maxHP);
            healthSlider.value = playerHealthSystem.currentHP;
            UpdateHealthUI();
        }
    }

    void Die()
    {
        Debug.Log("Player has died. Game Paused.");
        Time.timeScale = 0f;

        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true);
        }
    }

    void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = playerHealthSystem.currentHP + "/" + playerHealthSystem.maxHP;
        }
    }
}
