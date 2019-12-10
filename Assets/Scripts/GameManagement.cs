using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : MonoBehaviour
{
    public Transform platformGenerator;
    private Vector3 platformStartPoint;
    public PlayerController thePlayer;
    private Vector3 playerStartPoint;
    public bool functionUsed;
    private PlatformDestroyer[] platforms;
    private ScoreManagement scoreManagement;
    public Death deathScreen;
    // Start is called before the first frame update
    void Start()
    {
        platformStartPoint = platformGenerator.position;
        playerStartPoint = thePlayer.transform.position;
        scoreManagement = FindObjectOfType<ScoreManagement>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RestartGame()
    {
        scoreManagement.scoreIncreasing = false;
        thePlayer.gameObject.SetActive(false);
        deathScreen.gameObject.SetActive(true);
        //StartCoroutine ("RestartGameCo");
    }

    public void Resetter()
    {
        deathScreen.gameObject.SetActive(false);
        platforms = FindObjectsOfType<PlatformDestroyer>();
        for (int i = 0; i < platforms.Length; i++)
        {
            platforms[i].gameObject.SetActive(false);
        }
        thePlayer.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        thePlayer.gameObject.SetActive(true);
        scoreManagement.scoreCounter = 0;
        scoreManagement.scoreIncreasing = true;
        functionUsed = false;
    }
    /*
    public IEnumerator RestartGameCo()
    {
        
        functionUsed = true;
       
        yield return new WaitForSeconds(0.05f);
        platforms = FindObjectsOfType<PlatformDestroyer>();
        for(int i = 0; i < platforms.Length; i++)
        {
            platforms[i].gameObject.SetActive(false);
        }
        thePlayer.transform.position = playerStartPoint;
        platformGenerator.position = platformStartPoint;
        thePlayer.gameObject.SetActive(true);
        scoreManagement.scoreCounter = 0;
        scoreManagement.scoreIncreasing = true;
        functionUsed = false;
    }
    */
}
