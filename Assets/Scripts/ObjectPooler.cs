using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectPooler : MonoBehaviour
{
    public GameObject pooledObject;
    public int pooledAmount;
    List<GameObject> poolObjects;

    // Start is called before the first frame update
    void Start()
    {
        poolObjects = new List<GameObject>();
        for(int i = 0; i < pooledAmount; i++)
        {
            GameObject gobj = (GameObject)Instantiate(pooledObject);
            gobj.SetActive(false);
            poolObjects.Add(gobj);
        }
    }
 
    public GameObject GetPooledObject()
    {
        for(int i = 0; i < poolObjects.Count; i++)
        {
            if (!poolObjects[i].activeInHierarchy)
            {
                return poolObjects[i];
            }
        }

        GameObject gobj = (GameObject)Instantiate(pooledObject);
        gobj.SetActive(false);
        poolObjects.Add(gobj);
        return gobj;
    }
    
}
