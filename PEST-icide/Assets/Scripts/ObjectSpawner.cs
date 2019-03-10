using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject spawnObject;
    public GameObject SpawnLoc;
    public float spawnDelay; // Time between each spawn
    private List<GameObject> spawnLocations;

    private void Awake()
    {
        spawnLocations = new List<GameObject>(); // Initialize our list
        foreach (Transform child in SpawnLoc.transform)
        {
            spawnLocations.Add(child.gameObject); //Add all spawn locations into list
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 25; i++)
            Spawn();
        InvokeRepeating("Spawn", spawnDelay, spawnDelay);
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
        y = spawnLocation.transform.position.y;

        Vector3 spawnPos = new Vector3(Random.Range(minX, maxX), y, Random.Range(minZ, maxZ));

        Instantiate(spawnObject, spawnPos, Quaternion.identity);
    }

}
