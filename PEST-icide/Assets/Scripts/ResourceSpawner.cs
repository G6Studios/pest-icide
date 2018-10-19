using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ResourceSpawner : MonoBehaviour {
    public GameObject foodPrefab;

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
        for(int i = 0; i < 4; i++)
        {
            Vector3 randomized = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
            Instantiate(foodPrefab, gameObject.transform.position + randomized, gameObject.transform.rotation);
        }

    }

}
