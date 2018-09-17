using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyOnTouch : MonoBehaviour {

    bool enteredTrigger = false;
    
    void OnTriggerEnter(Collider coll)
    {
        AudioSource audio = GetComponent<AudioSource>();
        MeshRenderer mesh = GetComponent<MeshRenderer>();

        if(coll.gameObject.tag == "player" && enteredTrigger == false)
        {
            audio.Play();
            mesh.enabled = false;
            enteredTrigger = true;
        }
    }
}
