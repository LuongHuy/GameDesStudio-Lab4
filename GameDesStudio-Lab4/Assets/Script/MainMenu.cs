using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public int sceneIndex;
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(sceneIndex);
    }

    public void ExitGame()
    {
        //   Debug.Log("QuitGame");
        Application.Quit();
    }
}

