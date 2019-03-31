using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSound : MonoBehaviour
{
    AudioSource sound; // Resource collection audio clip

    // Start is called before the first frame update
    void Start()
    {
        sound = gameObject.GetComponent<AudioSource>(); // Defining the gameobject's audio source

        sound.Play(); // Playing the sound

        Destroy(gameObject, 1f); // Destroying the object after 1 second
    }


}
