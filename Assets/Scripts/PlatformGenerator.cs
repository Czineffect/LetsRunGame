using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject thePlatform; //the platform/ ground the character will run on
    public Transform generationPoint; //the coordinates of the platformgenrator
    private float distanceBetween; //distance between each platform
    private float[] platformWidths; //
    private int platformIndex;

    public float minDistance;
    public float maxDistance;

    public ObjectPooler[] theObjectPools;

    private float minHeight;
    public Transform heightLimit;
    private float maxHeight;
    public float maxHeightChange;
    private float heightChange;

    private GemGenerator gemGenerator;

    public float gemLimit;

    public float spikeLimit;
    public ObjectPooler spikePooler;

    public float powerUpHeight;
    public ObjectPooler powerUpPool;
    public float powerUpLimit;


    // Start is called before the first frame update
    void Start()
    {
        platformWidths = new float[theObjectPools.Length];
        for(int i = 0; i < theObjectPools.Length; i++)
        {
            platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }
        minHeight = transform.position.y;
        maxHeight = heightLimit.position.y;
        gemGenerator = FindObjectOfType<GemGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < generationPoint.position.x)
        {
            distanceBetween = Random.Range(minDistance, maxDistance);
            platformIndex = Random.Range(0, theObjectPools.Length);
            heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);

            if(heightChange > maxHeight)
            {
                heightChange = maxHeight;
            }
            else if (heightChange < minHeight)
            {
                heightChange = minHeight;
            }
            if(Random.Range(0f, 100f) < powerUpLimit)
            {
                GameObject powerUp = powerUpPool.GetPooledObject();
                powerUp.transform.position = transform.position + new Vector3(distanceBetween / 2f, powerUpHeight, 0f);
                powerUp.SetActive(true);
            }

            transform.position = new Vector3(transform.position.x + (platformWidths[platformIndex] / 2) + distanceBetween, heightChange, transform.position.z);
            
            GameObject newPlatform = theObjectPools[platformIndex].GetPooledObject();
            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

            //Coin generator for platforms
            if (Random.Range(0f, 100f) < gemLimit)
            {
                gemGenerator.CreateGems(new Vector3(transform.position.x, transform.position.y + 3f, transform.position.z));
            }

            //Spike generator for platforms
        
            if (Random.Range(0f, 100f) < spikeLimit)
            {
                GameObject aSpike = spikePooler.GetPooledObject();
                float xPosition = Random.Range(-4f, platformWidths[platformIndex] / 2f - 1f);
                Vector3 spikePosition = new Vector3(xPosition, 2f, transform.position.z);
                aSpike.transform.position = transform.position + spikePosition;
                aSpike.transform.rotation = transform.rotation;
                aSpike.SetActive(true);
               
            }
            


            transform.position = new Vector3(transform.position.x + (platformWidths[platformIndex] / 2), transform.position.y, transform.position.z);

            

        }
        
        
    }
}
