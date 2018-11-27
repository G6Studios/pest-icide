using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour {

    public AudioClip crunch;


	void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "Player1")
        {
            GameManager.instance.Player1Food++;
            GameObject.FindGameObjectWithTag("Player1").GetComponent<AudioSource>().PlayOneShot(crunch);
            gameObject.SetActive(false);
            gameObject.GetComponent<ObjectTimer>().SetDeactivatedTime();

        }
        else if (coll.gameObject.tag == "Player2")
        {
            GameManager.instance.Player2Food++;
            GameObject.FindGameObjectWithTag("Player2").GetComponent<AudioSource>().PlayOneShot(crunch);
            gameObject.SetActive(false);
            gameObject.GetComponent<ObjectTimer>().SetDeactivatedTime();
        }
        else if (coll.gameObject.tag == "Player3")
        {
            GameManager.instance.Player3Food++;
            GameObject.FindGameObjectWithTag("Player3").GetComponent<AudioSource>().PlayOneShot(crunch);
            gameObject.SetActive(false);
            gameObject.GetComponent<ObjectTimer>().SetDeactivatedTime();
        }
        else if(coll.gameObject.tag == "Player4")
        {
            GameManager.instance.Player4Food++;
            GameObject.FindGameObjectWithTag("Player4").GetComponent<AudioSource>().PlayOneShot(crunch);
            gameObject.SetActive(false);
            gameObject.GetComponent<ObjectTimer>().SetDeactivatedTime();
        }

    }

    
}
