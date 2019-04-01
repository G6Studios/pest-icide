using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHelper : MonoBehaviour {

    public Transform parentCamera; // The player camera
    public float helperDistance; // Value for storing the raycast hit distance
    float maxDistance; // The fallback distance if the raycast doesn't hit anything
    RaycastHit hit;

    int layerMask = 1 << 17; // Defining collision layer mask for the raycast

    // Use this for initialization
    void Start () {
        maxDistance = parentCamera.GetComponent<NewCamera>().maxDistance;
        layerMask = ~layerMask; // Inverting the layer mask will cause the raycast to hit everything but the resource barrels

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.LookAt(parentCamera); // Makes the helper look at the camera before raycasting

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, maxDistance, layerMask))
        {
            helperDistance = hit.distance; // If the raycast hits anything but a barrel, set the helper distance to the hit distance
        }
        else
        {
            helperDistance = maxDistance; // If nothing is hit, the camera will stay at the defined max distance
        }

	}
}
