using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public int maxHP = 20;
    public int currentHP;
    public Slider healthSlider;
    public Text healthText;
    public GameObject gameOverScreen; // Assign this in the Inspector to the object that should appear when you die
    public HealthSystem playerHealthSystem; // Reference to the player's HealthSystem

    void Start()
    {
        // Initialize the health to max at the start, regardless of whether the player is active
        currentHP = maxHP; // Set to max HP to avoid it being 0 at the start
        healthSlider.maxValue = maxHP;
        healthSlider.value = currentHP;
        UpdateHealthUI();

        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(false); // Ensure the game-over screen is hidden at the start
        }

        // If the playerHealthSystem reference is assigned, update the player's health as well
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
        Time.timeScale = 0f; // Pause the game

        if (gameOverScreen != null)
        {
            gameOverScreen.SetActive(true); // Show the game-over screen
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
