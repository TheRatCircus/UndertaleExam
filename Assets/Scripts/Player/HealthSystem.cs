using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public int maxHP = 20;
    public int currentHP;
    public Slider healthSlider;
    public Text healthText;

    void Start()
    {
        currentHP = maxHP;
        healthSlider.maxValue = maxHP;
        healthSlider.value = currentHP;
        UpdateHealthUI();
    }

    void Update()
    {
        healthSlider.value = currentHP;
        UpdateHealthUI();
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
        healthSlider.value = currentHP;
        UpdateHealthUI();
    }

    public void Heal(int healAmount)
    {
        currentHP += healAmount;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
        healthSlider.value = currentHP;
        UpdateHealthUI();
    }

    void UpdateHealthUI()
    {
        healthText.text = currentHP + "/" + maxHP;
    }
}
