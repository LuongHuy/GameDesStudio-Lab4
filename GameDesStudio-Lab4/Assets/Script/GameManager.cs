using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI; // Drag "EndGame" UI here in Unity Inspector

    void Start()
    {
        gameOverUI.SetActive(false); // Hide Game Over UI at start
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true); // Show Game Over UI
        Time.timeScale = 0; // Pause the game
    }

    public void RestartGame()
    {
        Time.timeScale = 1; // Resume time
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload scene
    }

    public void BackToMenu()
    {
        Time.timeScale = 1; // Ensure game speed is reset
        SceneManager.LoadScene("MainMenu"); // Load Main Menu scene
    }
}
