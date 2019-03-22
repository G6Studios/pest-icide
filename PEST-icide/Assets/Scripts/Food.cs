using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{

    public AudioClip crunch;


    void OnCollisionEnter(Collision coll)
    {
        if(coll.gameObject.CompareTag("Player"))
        {
            if(coll.gameObject.GetComponent<Player>().died == false)
            {
                coll.gameObject.GetComponent<Player>().resources++;
                gameObject.SetActive(false);
                gameObject.GetComponent<ObjectTimer>().SetDeactivatedTime();
                GetComponent<AudioSource>().Play();
            }
        }

    }


}
