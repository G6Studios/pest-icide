using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;



public class ResourceSpawner : MonoBehaviour {

    public GameObject plane;
    public ObjectPooler ResourcePool;

    [DllImport("MemoryManagementPlugin")]
    public static extern void CreatePool(uint size); //create our pool with our size

    [DllImport("MemoryManagementPlugin")]
    public static extern void AddToPool(float x, float y, float z); // add to our pool

    [DllImport("MemoryManagementPlugin")]
    public static extern IntPtr GetFromPool(); // get from our pool

    [DllImport("MemoryManagementPlugin")]
    public static extern float GetX(IntPtr vec); // get our vector x value

    [DllImport("MemoryManagementPlugin")]
    public static extern float GetY(IntPtr vec); //get out vector y value

    [DllImport("MemoryManagementPlugin")]
    public static extern float GetZ(IntPtr vec); // get our vector z value

    [DllImport("MemoryManagementPlugin")]
    public static extern void SetUsed(IntPtr vec); // set vector in pool to used (meaning its been used already, we are free to reuse that data for another vector)

    [DllImport("MemoryManagementPlugin")]
    public static extern void DeletePool(); //deletes everything in our pool, call this when we are done with our pool.


    private void Start()
    {
        float minX = plane.GetComponent<MeshRenderer>().bounds.min.x;
        float maxX = plane.GetComponent<MeshRenderer>().bounds.max.x;

        float minZ = plane.GetComponent<MeshRenderer>().bounds.min.z;
        float maxZ = plane.GetComponent<MeshRenderer>().bounds.max.z;

        CreatePool(100); // this is our pool for our vectors

        for (int i = 0; i < 100; i++)
        {
            RandomizeVectorPool(minX,maxX,minZ,maxZ);
        }

        for (int i = 0; i < 20; i++)
        {
            SpawnResources();
        }

    }

    void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "Poison")
        {
            Destroy(coll.gameObject);
            SpawnResources();
        }
    }

    void SpawnResources()
    {
        GameObject obj = ResourcePool.GetPooledObject();

        if (obj == null)
            return;

        IntPtr ourVectorInPool = GetFromPool(); //pointer to a vector in our pool which we can use
        //obj.transform.position.Set(GetX(ourVectorInPool), GetY(ourVectorInPool), GetZ(ourVectorInPool));
        obj.transform.position = new Vector3(GetX(ourVectorInPool), GetY(ourVectorInPool), GetZ(ourVectorInPool));
        obj.transform.rotation = transform.rotation;
        obj.SetActive(true); //set this position to used, so it can be overwritten
        SetUsed(ourVectorInPool);
        Debug.Log("spawned resource");
        // Instantiate(foodPrefab, gameObject.transform.position + randomized, gameObject.transform.rotation);

    }

    void RandomizeVectorPool(float minX, float maxX, float minZ, float maxZ)
    {

        //Vector3 randomized = new Vector3(UnityEngine.Random.Range(minX, maxX), 1, UnityEngine.Random.Range(minZ, maxZ));
        AddToPool(UnityEngine.Random.Range(minX, maxX), 1, UnityEngine.Random.Range(minZ, maxZ));
        
    }

}
