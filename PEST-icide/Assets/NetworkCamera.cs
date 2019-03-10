using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkCamera : NetworkBehaviour
{
    //public GameObject player; // For getting the joystick numbers easily
    public Transform target; // What the camera will be looking at
    //float xm = 0.0f; // For mouse
    //float ym = 0.0f; // For mouse
    float xj = 0.0f; // For joystick
    public float xSensitivity = 5.0f;
    public int joystickNumber;
    public float currentDistance = 3.0f;
    public float maxDistance = 5.0f;
    public float minDistance = 1.0f;
    public NetCameraHelper helper;
    public GameObject character;


    // Use this for initialization
    void Start()
    {
        character = this.transform.parent.gameObject;
        Vector3 angles = transform.eulerAngles; // Getting the angles of the attached object (camera)
        // Value flipped for later in the process
        xj = angles.y;

        joystickNumber = character.GetComponentInParent<Player>().playerNum;


    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (joystickNumber != 0)
        {
            if (target && !GetComponentInParent<Player>().died) // Making sure the camera has something to look at
            {
                // Update x and y for the mouse
                xj += Input.GetAxis("RightJoystickX_P" + joystickNumber) * xSensitivity;

                // Updating the rotation quaternion
                Quaternion currentRotation = Quaternion.Euler(22, xj, 0); // Due to Unity calculating the rotation values in order of Z, X, Y, we need to trick it a bit

                // Defining the distance from the target in reverse and setting the camera position
                Vector3 reverseDistance = new Vector3(0.0f, 0.0f, -currentDistance);
                Vector3 currentPosition = currentRotation * reverseDistance + target.position;

                transform.rotation = currentRotation;
                transform.position = currentPosition;
                character.transform.localRotation = Quaternion.AngleAxis(xj, character.transform.up);

                currentDistance = Mathf.Clamp(helper.oldDistance, minDistance, maxDistance);


            }
        }
    }

}
