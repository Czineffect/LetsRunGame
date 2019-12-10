using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    /*
    public string countDown1;
    public string countDown2;
    */
    public string countDown3;
    public AudioSource themeMusic; 
    public string playAGame;
    public string instructions;
    //
    


    public void PlayGame()
    {

        Application.LoadLevel(countDown3);
        themeMusic.Play();
        
        /*
        Time.timeScale = 2f;
        Application.LoadLevel(countDown2);
        Time.timeScale = 2f;
        Application.LoadLevel(countDown1);
        Time.timeScale = 2f;
        Application.LoadLevel(playAGame);
        */
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    //

    public void HowTo()
    {
        Application.LoadLevel(instructions);
    }
}
