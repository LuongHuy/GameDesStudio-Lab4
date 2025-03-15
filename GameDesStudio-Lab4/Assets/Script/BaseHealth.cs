using UnityEngine;
using UnityEngine.UI;

public class BaseHealth : MonoBehaviour
{
    public int maxHealth = 200; // Maximum HP
    public int currentHealth; // Current HP
    public Slider healthBar; // UI Slider
    public Text healthText; // UI Text
    public GameObject boosterButton; // UI Button for boosting health

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
        boosterButton.SetActive(false); // Hide the booster button at the start
        UpdateHealthUI();
        InvokeRepeating("RegenerateHealth", 3f, 3f); // Regenerate 1 HP every 3 sec
    }

    void UpdateHealthUI()
    {
        healthBar.value = currentHealth;

        if (healthText != null)
        {
            healthText.text = "Base HP: " + currentHealth;
        }

        // Ensure Booster Button appears when HP is 50 or below
        if (currentHealth <= 100)
        {
            boosterButton.SetActive(true);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0; // Prevent negative health
        }
        UpdateHealthUI();

        // ✅ Fix: Ensure Game Over triggers when HP is 0
        if (currentHealth == 0)
        {
            FindObjectOfType<GameManager>().GameOver();
        }
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        // Ignore enemy bullets (lasers)
        if (other.CompareTag("EnemyBullet"))
        {
            return; // Do nothing when hit by a laser
        }

        // Take damage only when an enemy (Fish) collides with the base
        if (other.CompareTag("Enemy"))
        {
            TakeDamage(15); // Reduce 15 HP per collision
            Destroy(other.gameObject); // Destroy enemy after collision
        }
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
        boosterButton.SetActive(false); // Hide the booster button after use
        UpdateHealthUI();
    }
}
