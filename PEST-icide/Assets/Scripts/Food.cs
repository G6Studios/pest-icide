using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public GameObject crunch; // The invisible game object that will play the sound

    void OnCollisionEnter(Collision coll)
    {
        if(coll.gameObject.CompareTag("Player")) // Is the colliding object a player?
        {
            if(coll.gameObject.GetComponent<Player>().died == false) // Dead players should not collect resources
            {
                coll.gameObject.GetComponent<Player>().resources++; // Increase the carried resources of that player
                Instantiate(crunch); // Create the sound object
                gameObject.SetActive(false); // Deactivate the gameobject
                gameObject.GetComponent<ObjectTimer>().SetDeactivatedTime(); // Set the gameobject to reactivate after a time

            }
        }

    }

}
