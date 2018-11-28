using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour {

    public AudioClip crunch;


	void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "Player1")
        {
            coll.gameObject.GetComponent<Player>().resources++;
            GameObject.FindGameObjectWithTag("Player1").GetComponent<AudioSource>().PlayOneShot(crunch);
            gameObject.SetActive(false);
            gameObject.GetComponent<ObjectTimer>().SetDeactivatedTime();

        }
        else if (coll.gameObject.tag == "Player2")
        {
            coll.gameObject.GetComponent<Player>().resources++;
            GameObject.FindGameObjectWithTag("Player2").GetComponent<AudioSource>().PlayOneShot(crunch);
            gameObject.SetActive(false);
            gameObject.GetComponent<ObjectTimer>().SetDeactivatedTime();
        }
        else if (coll.gameObject.tag == "Player3")
        {
            coll.gameObject.GetComponent<Player>().resources++;
            GameObject.FindGameObjectWithTag("Player3").GetComponent<AudioSource>().PlayOneShot(crunch);
            gameObject.SetActive(false);
            gameObject.GetComponent<ObjectTimer>().SetDeactivatedTime();
        }
        else if(coll.gameObject.tag == "Player4")
        {
            coll.gameObject.GetComponent<Player>().resources++;
            GameObject.FindGameObjectWithTag("Player4").GetComponent<AudioSource>().PlayOneShot(crunch);
            gameObject.SetActive(false);
            gameObject.GetComponent<ObjectTimer>().SetDeactivatedTime();
        }

    }

    
}
