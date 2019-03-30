using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceDeposit : MonoBehaviour
{
    // List to hold players currently in the radius
    public List<GameObject> playersInRadius;

    // Variables controlling deposit rate
    private float depositInterval;
    private float timer;

    private IEnumerator coroutine;


    private void Start()
    {
        timer = 0.0f;
        depositInterval = 1.0f;
    }

    void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag.Equals("Player"))
        {
            playersInRadius.Add(coll.gameObject);
        }
        
    }

    void Update()
    {
        // Incrementing timer every frame
        timer += Time.deltaTime;

        // Deposit interval of 0.5 seconds
        if (timer > depositInterval)
        {
            // If there is at least 1 player in the radius
            if (playersInRadius.Count > -1)
            {
                // For every player that is in the radius
                for (int i = 0; i < playersInRadius.Count; i++)
                {
                    // Making sure they don't end up in debt resources
                    if (playersInRadius[i].GetComponent<Player>().resources > 0)
                    {
                        playersInRadius[i].GetComponent<Player>().resources--; // Taking one resource from their person at a time
                        playersInRadius[i].GetComponent<Player>().depositedResources++; // Adding it to their deposited resources
                    }
                }
            }
            timer = 0.0f;
        }
    }

    void OnTriggerExit(Collider coll)
    {
        // Checking that the object exiting is a player (and not a barrel or something else)
        if (coll.gameObject.tag.Equals("Player"))
        {
            // Remove gameobject from list
            if (playersInRadius.IndexOf(coll.gameObject) > -1)
            {
                playersInRadius.Remove(coll.gameObject);
            }
        }
    }

}
