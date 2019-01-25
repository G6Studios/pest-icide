using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHelper : MonoBehaviour {

    public Transform camera;
    public float oldDistance = 5.0f;
    RaycastHit hit;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(camera);

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            oldDistance = hit.distance;
        }

	}
}
