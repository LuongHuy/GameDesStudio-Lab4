using UnityEngine;
using UnityEngine.UI;

public class SharkManager : MonoBehaviour
{
    public int sharkLives = 3; // Shark starts with 3 lives
    public Text livesText; // UI Text for displaying lives

    void Start()
    {
        ResetLives();
    }

    void ResetLives()
    {
        sharkLives = 3;
        UpdateLivesUI();
    }

    void UpdateLivesUI()
    {
        if (livesText != null)
        {
            livesText.text = "Lives: " + sharkLives;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Shark loses 1 life only when hit by an enemy bullet
        if (other.CompareTag("EnemyBullet"))
        {
            LoseLife();
            Destroy(other.gameObject); // Destroy bullet after collision
        }

        if (other.CompareTag("Booster"))
        {
            FindObjectOfType<BaseHealth>().ResetHealthTo500();
            Destroy(other.gameObject); // Destroy the booster after collection
        }
    }

    void LoseLife()
    {
        sharkLives--;

        if (sharkLives < 0)
        {
            sharkLives = 0; // Prevents negative lives
        }

        UpdateLivesUI();
    }
}
