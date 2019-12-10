using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectGem : MonoBehaviour
{
    public int scoreForPlayer;

    private ScoreManagement theScoreManager;

    private AudioSource gemSound; 

    // Start is called before the first frame update
    void Start()
    {
        theScoreManager = FindObjectOfType<ScoreManagement>();
        gemSound = GameObject.Find("coin_collecting").GetComponent<AudioSource>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D item)
    {
        if(item.gameObject.name == "Player")
        {
            theScoreManager.GiveScore(scoreForPlayer);
            gameObject.SetActive(false);

            if (gemSound.isPlaying)
            {
                gemSound.Stop();
                gemSound.Play(); 
            }
            gemSound.Play(); 
        }
    }
}
