using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundTrigger : MonoBehaviour {

    bool enteredTrigger = false;

    void onTriggerEnter(Collider coll)
    {
        AudioSource audio = GetComponent<AudioSource>();
        MeshRenderer mesh = GetComponent<MeshRenderer>();
        if(coll.gameObject.tag == "player" && enteredTrigger == false)
        {
            audio.Play();
            enteredTrigger = true;
            mesh.enabled = false;
            coll.enabled = false;
        }
    }
}
