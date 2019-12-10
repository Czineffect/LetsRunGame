using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public string sceneToRun;

    public GameObject pauseMenu;

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    public void Continue()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        FindObjectOfType<GameManagement>().Resetter();
    }

    public void Quit()
    {
        Time.timeScale = 1f;
        Application.LoadLevel(sceneToRun);
    }
}
