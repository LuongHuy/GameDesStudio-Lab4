using UnityEngine;
using UnityEngine.UI; // For UI display

public class SharkController : MonoBehaviour
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
        // Check if Shark collides with an Enemy or Trash
        if (other.CompareTag("Enemy") || other.CompareTag("Trash"))
        {
            LoseLife(); // Reduce 1 life
            Destroy(other.gameObject); // Remove the enemy/trash
        }
    }

    void LoseLife()
    {
        sharkLives--;

        if (sharkLives <= 0)
        {
            GameOver();
        }

        UpdateLivesUI(); // Update UI after losing a life
    }

    void GameOver()
    {
        Debug.Log("Game Over! Shark has no lives left.");
        // You can add game-over logic here (restart, UI pop-up, etc.)
    }
}
