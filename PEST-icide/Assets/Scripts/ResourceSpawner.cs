using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;



public class ResourceSpawner : MonoBehaviour {

    public GameObject plane;
    public GameObject ExcludePlane1;
    public GameObject ExcludePlane2;

    public ObjectPooler ResourcePool;
    public float SpawnTimer;

    private List<Vector3> VectorList;
    private int VectorListItr = 0;

    struct ObjectArea
    {
        public float minX, minZ, maxX, maxZ;

        public ObjectArea(float minimumX, float minimumZ, float maximumX, float maximumZ)
        {
            minX = minimumX;
            minZ = minimumZ;
            maxX = maximumX;
            maxZ = maximumZ;

        }
    }
    /*
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
    */

    private void Start()
    {
        float minX = plane.GetComponent<MeshRenderer>().bounds.min.x;
        float maxX = plane.GetComponent<MeshRenderer>().bounds.max.x;

        float minZ = plane.GetComponent<MeshRenderer>().bounds.min.z;
        float maxZ = plane.GetComponent<MeshRenderer>().bounds.max.z;


        float Ex1MinX = ExcludePlane1.GetComponent<MeshRenderer>().bounds.min.x;
        float Ex1MinZ = ExcludePlane1.GetComponent<MeshRenderer>().bounds.min.z;
        float Ex1MaxX = ExcludePlane1.GetComponent<MeshRenderer>().bounds.max.x;
        float Ex1MaxZ = ExcludePlane1.GetComponent<MeshRenderer>().bounds.max.z;

        float Ex2MinX = ExcludePlane2.GetComponent<MeshRenderer>().bounds.min.x;
        float Ex2MinZ = ExcludePlane2.GetComponent<MeshRenderer>().bounds.min.z;
        float Ex2MaxX = ExcludePlane2.GetComponent<MeshRenderer>().bounds.max.x;
        float Ex2MaxZ = ExcludePlane2.GetComponent<MeshRenderer>().bounds.max.z;
        

        ObjectArea ExclusionPlane1 = new ObjectArea(Ex1MinX, Ex1MinZ, Ex1MaxX, Ex1MaxZ);
        ObjectArea ExclusionPlane2 = new ObjectArea(Ex2MinX, Ex2MinZ, Ex2MaxX, Ex2MaxZ);
        VectorList = new List<Vector3>();



        //CreatePool(100); // this is our pool for our vectors

        for (int i = 0; i < 100; i++)
        {
            RandomizeVectorPool(minX,maxX,minZ,maxZ,ExclusionPlane1,ExclusionPlane2);
        }

        for (int i = 0; i < 20; i++)
        {
            SpawnResources();
        }

        InvokeRepeating("SpawnResources", SpawnTimer, SpawnTimer);

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

        //IntPtr ourVectorInPool = GetFromPool(); //pointer to a vector in our pool which we can use
        //obj.transform.position.Set(GetX(ourVectorInPool), GetY(ourVectorInPool), GetZ(ourVectorInPool));
        //obj.transform.position = new Vector3(GetX(ourVectorInPool), GetY(ourVectorInPool), GetZ(ourVectorInPool));
        obj.transform.position = VectorList[VectorListItr];
        obj.transform.rotation = transform.rotation;
        obj.SetActive(true);
        obj.GetComponent<ObjectTimer>().ResetDeactiveTime();
        VectorListItr++;

        if (VectorListItr == VectorList.Count - 1)
        {
            VectorListItr = 0;
        }

        //SetUsed(ourVectorInPool);
        Debug.Log("spawned resource");
        // Instantiate(foodPrefab, gameObject.transform.position + randomized, gameObject.transform.rotation);

    }

    void RandomizeVectorPool(float minX, float maxX, float minZ, float maxZ, ObjectArea ExclusionPlane1, ObjectArea ExclusionPlane2)
    {


        float RandomX = UnityEngine.Random.Range(minX, maxX);
        float RandomZ = UnityEngine.Random.Range(minZ, maxZ);
        Vector3 RandomLocation = new Vector3(RandomX, 2, RandomZ);
        while (Physics.CheckSphere(RandomLocation, 0.5f) || isInExclusionZone(RandomLocation,ExclusionPlane1) || isInExclusionZone(RandomLocation,ExclusionPlane2)) // This line will break the spawning if it ends up coliding with the floor (Make sure radius will not collide with the floor).
        {
            RandomX = UnityEngine.Random.Range(minX, maxX);
            RandomZ = UnityEngine.Random.Range(minZ, maxZ);
            RandomLocation.x = RandomX;
            RandomLocation.z = RandomZ;
        }
        //Vector3 randomized = new Vector3(UnityEngine.Random.Range(minX, maxX), 1, UnityEngine.Random.Range(minZ, maxZ));
        
        //AddToPool(UnityEngine.Random.Range(minX, maxX), 1, UnityEngine.Random.Range(minZ, maxZ));
        //AddToPool(RandomLocation.x, 1.5f, RandomLocation.z);
        RandomLocation.y = 1.5f;
        VectorList.Add(RandomLocation);


    }

    bool isInExclusionZone(Vector3 Object, ObjectArea plane)
    {
        //if ((RandomLocation.x > ExclusionPlane1.minX) && (RandomLocation.x < ExclusionPlane1.maxX)
        // && (RandomLocation.z > ExclusionPlane1.minZ) && (RandomLocation.z < ExclusionPlane1.maxZ))

        if ((Object.x > plane.minX) && (Object.x < plane.maxX) &&
       (Object.z > plane.minZ) && (Object.z < plane.maxZ))
        {
            return true;
        }
        else
            return false;

    }


}
