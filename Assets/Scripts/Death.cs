using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public string backToMainMenu;

    public void RestartGame()
    {
        FindObjectOfType<GameManagement>().Resetter();
    }

    public void BacktoMainMenu()
    {
        Application.LoadLevel(backToMainMenu);
    }
    
}
