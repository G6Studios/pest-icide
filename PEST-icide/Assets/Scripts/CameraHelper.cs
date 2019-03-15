using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHelper : MonoBehaviour {

    public Transform parentCamera;
    public float oldDistance;
    float maxDistance;
    RaycastHit hit;

    int layerMask = 1 << 17;

    // Use this for initialization
    void Start () {
        maxDistance = parentCamera.GetComponent<NewCamera>().maxDistance;
        layerMask = ~layerMask;

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.LookAt(parentCamera);

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, maxDistance, layerMask))
        {
            oldDistance = hit.distance;
        }
        else
        {
            oldDistance = maxDistance;
        }

	}
}
