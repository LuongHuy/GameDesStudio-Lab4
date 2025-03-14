using UnityEngine;
using UnityEngine.UI;

public class BaseHealth : MonoBehaviour
{
    public int maxHealth = 200; // Maximum HP
    public int currentHealth; // Current HP
    public Slider healthBar; // UI Slider
    public Text healthText; // UI Text

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
        UpdateHealthUI();
        InvokeRepeating("RegenerateHealth", 3f, 3f); // Regain 1 HP every 3 sec
    }

    void UpdateHealthUI()
    {
        healthBar.value = currentHealth;

        if (healthText != null)
        {
            healthText.text = "Base HP: " + currentHealth; // Ensure this updates
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyBullet") || other.CompareTag("Enemy"))
        {
            TakeDamage(15); // Reduce 15 HP per hit
            Destroy(other.gameObject);
        }
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0; // Prevent negative health
        }
        UpdateHealthUI();
    }

    void RegenerateHealth()
    {
        if (currentHealth < maxHealth)
        {
            currentHealth += 1;
            UpdateHealthUI();
        }
    }

    public void ResetHealthTo500()
    {
        currentHealth = 500;
        healthBar.maxValue = 500; // Adjust the max value
        healthBar.value = currentHealth;
        UpdateHealthUI();
    }

}
