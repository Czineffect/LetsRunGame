using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CountDown3 : MonoBehaviour
{
    public string countDown2;
    private float time = 0.5f;
    private float counter = 0;
    private int x;
    public AudioSource beep; 
    // Update is called once per frame
    void Start()
    {
        StartCoroutine(Timer());
        beep.Play(); 
        
    }
  
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(time);
        counter+=time;
        Application.LoadLevel(countDown2);
    }
}
