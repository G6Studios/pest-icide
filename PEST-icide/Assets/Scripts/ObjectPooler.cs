using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectPooler : MonoBehaviour {

    //public static ObjectPooler current;
    public GameObject pooledObject; //gameobject we want pooled
    public int poolSize = 25;
    public bool growPool = true;  //if we want to grow our pool or not if it ends up full
    public bool DynamicPoolShrinking = false;
    public float DeletionTimeInSeconds = 15.0f;

    List<GameObject> objectPool;


    // Use this for initialization
    void Awake ()
    {
        objectPool = new List<GameObject>();

        for (uint i = 0; i < poolSize; i++)
        {
            GameObject ourObject = Instantiate(pooledObject);
            ourObject.SetActive(false);
            ourObject.GetComponent<ObjectTimer>().SetDeactivatedTime();
            objectPool.Add(ourObject);
            

        }

	}
    private void Start()
    {
        if (DynamicPoolShrinking)
        {
            InvokeRepeating("DeleteUselessPoolObj", DeletionTimeInSeconds + 1.0f, DeletionTimeInSeconds);
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
                ourObject.GetComponent<ObjectTimer>().SetDeactivatedTime();
                objectPool.Add(ourObject);
            }
            return objectPool[objectPool.Count - 1];
        }
        Debug.Log("No objects in pool available");
        return null;
    }

    private void DeleteUselessPoolObj()
    {

        for (int i = 0; i < objectPool.Count; i++)
        {
            if (!objectPool[i].activeInHierarchy) // We only want to check inactive pool objects
            {
                float deactivatedTime = objectPool[i].GetComponent<ObjectTimer>().GetDeactivatedTime();
                if ((Time.time - deactivatedTime) >= DeletionTimeInSeconds)
                {
                    Destroy(objectPool[i]);
                    objectPool.RemoveAt(i);
                    i--; // Since our object pool size just got reduced, we need to reduce our i value to accomodate or else we wont delete correctly
                    Debug.Log("Removed Object from pool from being inactive too long");
                }
            }

        }


    }
	

}
