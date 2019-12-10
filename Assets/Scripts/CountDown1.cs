using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDown1 : MonoBehaviour
{
    public string playAGame;
    private float time = 0.5f;
    private float counter = 0;
    public AudioSource beep; 
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Timer());
        beep.Play(); 
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(time);
        counter += time;
        Application.LoadLevel(playAGame);
    }
}
