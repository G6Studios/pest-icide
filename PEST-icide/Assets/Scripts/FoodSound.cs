using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSound : MonoBehaviour
{
    AudioSource sound;

    // Start is called before the first frame update
    void Start()
    {
        sound = gameObject.GetComponent<AudioSource>();

        sound.Play();

        Destroy(gameObject, 1f);
    }


}
