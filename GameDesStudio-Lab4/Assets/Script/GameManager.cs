using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI; // Drag "EndGame" from Hierarchy into this in Unity

    public void GameOver()
    {
        gameOverUI.SetActive(true); // Show Game Over UI
        Time.timeScale = 0; // Pause the game
    }

    public void RestartGame()
    {
        Time.timeScale = 1; // Resume game speed
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Reload current scene
    }

    public void BackToMenu()
    {
        Time.timeScale = 1; // Reset time before loading
        SceneManager.LoadScene("MainMenu"); // Change "MainMenu" to your actual menu scene name
    }


    void Start()
    {
        gameOverUI.SetActive(false); // Hide Game Over UI when the game starts
    }
}
