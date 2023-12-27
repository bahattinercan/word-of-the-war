using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public float winDelay, loseDelay;
    public EndGamePanel endGamePanel;
    public event Action<bool> OnGameFinished;
    private string targetWord;

    public string TargetWord { get => targetWord; set => targetWord = value; }

    private void Awake()
    {
        Application.targetFrameRate = 60;
        MakeInstance();
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }

    public void WinTheGame()
    {
        StartCoroutine(WinCo());
    }
    public void LoseTheGame()
    {
        StartCoroutine(LoseCo());
    }

    private IEnumerator WinCo()
    {
        yield return new WaitForSeconds(winDelay);
        endGamePanel.gameObject.SetActive(true);
        endGamePanel.SetupPanel(true, targetWord);
        OnGameFinished?.Invoke(true);
    }

    private IEnumerator LoseCo()
    {
        yield return new WaitForSeconds(loseDelay);
        endGamePanel.gameObject.SetActive(true);
        endGamePanel.SetupPanel(false, targetWord);
        OnGameFinished?.Invoke(false);
    }

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

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
