using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemGenerator : MonoBehaviour
{
    public ObjectPooler thepooler;
    public float gemSpace;

    public void CreateGems (Vector3 startPosition)
    {
        GameObject gem1 = thepooler.GetPooledObject();
        gem1.transform.position = startPosition;
        gem1.SetActive(true);

        GameObject gem2 = thepooler.GetPooledObject();
        gem2.transform.position = new Vector3(startPosition.x - gemSpace, startPosition.y, startPosition.z);
        gem2.SetActive(true);

        GameObject gem3 = thepooler.GetPooledObject();
        gem3.transform.position = new Vector3(startPosition.x + gemSpace, startPosition.y, startPosition.z);
        gem3.SetActive(true);
    }
}
