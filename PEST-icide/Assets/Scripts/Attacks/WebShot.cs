using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ## DEFUNCT SCRIPT - NO LONGER IN USE ##

public class WebShot : MonoBehaviour {

    Rigidbody web;

	// Use this for initialization
	void Start () {
        web = gameObject.GetComponent<Rigidbody>();

	}

    void FireWeb(Transform firePoint)
    {
        web.AddForce(firePoint.forward * 700.0f);
    }

    private void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "Player1")
        {
            Debug.Log("Player1 hit!");
            Spider.instance.SendMessage("takeDamage", 3.0f);
        }
        else if (hit.gameObject.tag == "Player3")
        {
            Debug.Log("Player3 hit!");
            Frog.instance.SendMessage("takeDamage", 3.0f);

        }
        else if (hit.gameObject.tag == "Player4")
        {
            Debug.Log("Player4 hit!");
            Snake.instance.SendMessage("takeDamage", 3.0f);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
