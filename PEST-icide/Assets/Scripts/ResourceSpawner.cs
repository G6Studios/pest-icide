using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ResourceSpawner : MonoBehaviour {

    public GameObject plane;


    private void Start()
    {
      
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
        GameObject obj = ObjectPooler.current.GetPooledObject();

        if (obj == null)
            return;

        float minX = plane.GetComponent<MeshRenderer>().bounds.min.x;
        float maxX = plane.GetComponent<MeshRenderer>().bounds.max.x;

        float minZ = plane.GetComponent<MeshRenderer>().bounds.min.z;
        float maxZ = plane.GetComponent<MeshRenderer>().bounds.max.z;

        Vector3 randomized = new Vector3(Random.Range(minX, maxX), 1, Random.Range(minZ, maxZ));
        obj.transform.position = randomized;
        obj.transform.rotation = transform.rotation;
        obj.SetActive(true);
        Debug.Log("spawned resource");
        // Instantiate(foodPrefab, gameObject.transform.position + randomized, gameObject.transform.rotation);

    }

}
