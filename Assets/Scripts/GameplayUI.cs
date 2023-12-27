using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameplayUI : MonoBehaviour
{
    public void HomeButton()
    {
        SceneManager.LoadScene("MainMenu");

    }
}
