using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManagement : MonoBehaviour
{
    private bool doublePoints;
    private bool spikefree;

    private bool spikeFreeActive;
    private float spikeFreeActiveDurationCounter;

    private ScoreManagement scoreManagement;
    private PlatformGenerator platformGenerator;

    private float avgPointsPerSecond;
    private float numOfSpikes;

    private PlatformDestroyer[] spikeDestroyer;

    // Start is called before the first frame update
    void Start()
    {
        scoreManagement = FindObjectOfType<ScoreManagement>();
        platformGenerator = FindObjectOfType<PlatformGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spikeFreeActive)
        {
            spikeFreeActiveDurationCounter -= Time.deltaTime;
            if(doublePoints)
            {
                scoreManagement.pointsPerSecond = avgPointsPerSecond * 2f;
                scoreManagement.activateDoublePoints = true;
            }
            if(spikefree)
            {
                platformGenerator.spikeLimit = 0;
            }
            if (spikeFreeActiveDurationCounter <= 0)
            {
                scoreManagement.pointsPerSecond = avgPointsPerSecond;
                scoreManagement.activateDoublePoints = false;
                platformGenerator.spikeLimit = numOfSpikes;
                spikeFreeActive = false;
            }
        }
        
    }

    public void NoSpikes(bool points, bool safeMode, float duration)
    {
        
        doublePoints = points;
        spikefree = safeMode;
        spikeFreeActiveDurationCounter = duration;
        avgPointsPerSecond = scoreManagement.pointsPerSecond;
        numOfSpikes = platformGenerator.spikeLimit;
        if (safeMode)
        {
            spikeDestroyer = FindObjectsOfType<PlatformDestroyer>();
            for (int i = 0; i < spikeDestroyer.Length; i++)
            {
                if (spikeDestroyer[i].gameObject.name.Contains("spikes"))
                {
                    spikeDestroyer[i].gameObject.SetActive(false);
                }
            }
        }
        spikeFreeActive = true;
    }
}
