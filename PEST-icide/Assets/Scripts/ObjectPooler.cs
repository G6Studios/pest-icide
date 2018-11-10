using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour {

    public static ObjectPooler current;
    public GameObject pooledObject; //gameobject we want pooled
    public int poolSize = 25;
    public bool growPool = true;  //if we want to grow our pool or not if it ends up full

    List<GameObject> objectPool;

    private void Awake()
    {
        current = this;
    }

    // Use this for initialization
    void Start ()
    {
        objectPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject ourObject = Instantiate(pooledObject);
            ourObject.SetActive(false);
            objectPool.Add(ourObject);
        }

	}

    //Method to get an inactive gameobject in our pool.
    public GameObject GetPooledObject()
    {
        for (int i = 0; i < objectPool.Count; i++)
        {
            if (!objectPool[i].activeInHierarchy)
            {
                return objectPool[i];
            }

        }
        if (growPool) //if we are growing our pool
        {
            for (int i = 0; i < poolSize / 2; i++)
            {
            GameObject ourObject = Instantiate(pooledObject);
                ourObject.SetActive(false);
             objectPool.Add(ourObject);
            }
            return objectPool[objectPool.Count - 1];
        }
        Debug.Log("No objects in pool available");
        return null;
    }
	

}
