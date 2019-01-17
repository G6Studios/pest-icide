using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHelper : MonoBehaviour {

    public GameObject camera;

    public float maxDistance = 5.0f; // Max camera distance
    public float minDistance = 2.0f; // Min camera distance



    RaycastHit hit;

    // Update is called once per frame
    void Update () {
        this.transform.LookAt(camera.transform);


        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), maxDistance))
        {
            camera.GetComponent<camMouseLook>().distance = hit.distance;
        }

        if (camera.GetComponent<camMouseLook>().distance > 2.0f)
        {
            camera.GetComponent<camMouseLook>().distance = 2.0f;

        }

    }
}
