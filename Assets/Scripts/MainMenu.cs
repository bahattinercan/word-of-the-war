using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadAnotherLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartTheGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void RestartTheGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitTheGame()
    {
        Application.Quit();
    }

    public void OptionMenu()
    {

    }


    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
