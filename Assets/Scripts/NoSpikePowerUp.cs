using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoSpikePowerUp : MonoBehaviour
{
    public bool doublePoints;
    public bool spikefree;

    public float spikeFreeDuration;

    private PowerUpManagement powerUpManagement;

    // Start is called before the first frame update
    void Start()
    {
        powerUpManagement = FindObjectOfType<PowerUpManagement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D item)
    {
        if(item.name == "Player")
        {
            powerUpManagement.NoSpikes(doublePoints, spikefree, spikeFreeDuration);
        }
        gameObject.SetActive(false);
    }
}
