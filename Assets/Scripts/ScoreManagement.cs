using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManagement : MonoBehaviour
{
    public Text distanceText;
    public Text personalBest;

    public float scoreCounter;
    public float scoreRecord;

    public float pointsPerSecond;

    public bool scoreIncreasing;

    public bool activateDoublePoints;
    // Start is called before the first frame update
    void Start()
    {
        scoreIncreasing = true;
     
        if(PlayerPrefs.HasKey("HighScore"))
        {
            scoreRecord = PlayerPrefs.GetFloat("HighScore");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreIncreasing)
        {
            scoreCounter += pointsPerSecond * Time.deltaTime;
        }
        if(scoreCounter > scoreRecord)
        {
            scoreRecord = scoreCounter;
            PlayerPrefs.SetFloat("HighScore", scoreRecord);
        }
        distanceText.text = "Score: " + Mathf.Round(scoreCounter);
        personalBest.text = "High Score: " + Mathf.Round(scoreRecord);
    }

    public void GiveScore(int pointsAdded)
    {
        if (activateDoublePoints)
        {
            pointsAdded = pointsAdded * 2;
        }
        scoreCounter += pointsAdded;
    }
}
