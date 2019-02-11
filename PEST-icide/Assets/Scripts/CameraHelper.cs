using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHelper : MonoBehaviour {

    public Transform camera;
    public float oldDistance;
    float maxDistance;
    RaycastHit hit;

    // Use this for initialization
    void Start () {
        maxDistance = camera.GetComponent<NewCamera>().maxDistance;

    }
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(camera);

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
        {
            oldDistance = hit.distance;
        }
        else
        {
            oldDistance = maxDistance;
        }

	}
}
