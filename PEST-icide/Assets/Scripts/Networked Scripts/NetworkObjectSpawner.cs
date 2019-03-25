using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkObjectSpawner : NetworkBehaviour
{
    public int initialSpawnAmount; // Initial amount to spawn
    public GameObject spawnObject; // Object to spawn
    public GameObject SpawnLoc; // Parent game object containing all spawn locations as children
    public float spawnRate; // In seconds
    private List<GameObject> spawnLocations; // list of all our spawn location gameobjects
    private float objectHeight;
    private GameObject m_instantiated;

    private void Awake()
    {
        objectHeight = spawnObject.GetComponent<Collider>().bounds.size.y;
        spawnLocations = new List<GameObject>(); // Initialize our list
        foreach (Transform child in SpawnLoc.transform)
        {
            spawnLocations.Add(child.gameObject); //Add all spawn locations into list
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (initialSpawnAmount != 0)
        {
            for (int i = 0; i < initialSpawnAmount; i++)
                Spawn();
        }
        InvokeRepeating("Spawn", spawnRate, spawnRate);
    }

    GameObject GetRandomSpawnLocation()
    {
        int RandIndex = Random.Range(0, spawnLocations.Count - 1); // A random index in spawnlocation list
        return spawnLocations[RandIndex]; // Return a random spawn location from our list
    }

    void Spawn()
    {
        GameObject spawnLocation = GetRandomSpawnLocation();
        float minX, minZ, maxX, maxZ, y;
        minX = spawnLocation.GetComponent<MeshRenderer>().bounds.min.x;
        minZ = spawnLocation.GetComponent<MeshRenderer>().bounds.min.z;
        maxX = spawnLocation.GetComponent<MeshRenderer>().bounds.max.x;
        maxZ = spawnLocation.GetComponent<MeshRenderer>().bounds.max.z;
        y = spawnLocation.transform.position.y + (objectHeight / 2);

        Vector3 spawnPos = new Vector3(Random.Range(minX, maxX), y, Random.Range(minZ, maxZ));

        m_instantiated = Instantiate(spawnObject, spawnPos, Quaternion.identity); //instantiate the object

        NetworkServer.Spawn(m_instantiated); //spawn the object on the server
    }

}
