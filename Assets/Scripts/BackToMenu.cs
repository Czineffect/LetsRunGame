using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToMenu : MonoBehaviour
{
    public string sceneToRun;

    public void GoBackToMenu()
    {
        Time.timeScale = 1f;
        Application.LoadLevel(sceneToRun);
    }
}
