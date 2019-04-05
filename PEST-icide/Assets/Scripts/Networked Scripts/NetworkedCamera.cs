using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkedCamera : NetworkBehaviour
{
    public Transform target; // What the camera will be looking at
    float xj = 0.0f; // Joystick x
    public float xSensitivity = 5.0f; // How sensitive the x movement will be
    public int joystickNumber; // Tied to the player number
    public float currentDistance = 3.0f; // Camera's starting distance
    public float maxDistance = 5.0f; // The furthest the camera will move away from the player
    public float minDistance = 1.0f; // The closest the camera will move to the player
    public NetworkedCameraHelper helper; // Helper for making the camera move forward and back dynamically
    public GameObject character; // For character rotation


    // Use this for initialization
    void Start()
    {
        character = this.transform.parent.gameObject; // The character the player is currently playing
        Vector3 angles = transform.eulerAngles; // Getting the angles of the attached object (camera)
        // Value flipped for later in the process
        xj = angles.y;

        joystickNumber = character.GetComponentInParent<NetworkedPlayer>().playerNum;


    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (joystickNumber != 0) // Making sure the joystick number is not 0, and therefore not a bot
        {
            if (target && !GetComponentInParent<NetworkedPlayer>().died) // Making sure the camera has something to look at
            {
                xj += Input.GetAxis("RightJoystickX_P" + joystickNumber) * xSensitivity; // Update x and y for the mouse

                // Updating the rotation quaternion
                Quaternion currentRotation = Quaternion.Euler(22, xj, 0); // Due to Unity calculating the rotation values in order of Z, X, Y, we need to trick it a bit, the x value is how much the camera is looking downward

                // Getting the camera's resting position from behind for the target and setting the camera position
                Vector3 reverseDistance = new Vector3(0.0f, 0.0f, -currentDistance);
                Vector3 currentPosition = currentRotation * reverseDistance + target.position;

                // Updating the transformation and rotation of the camera, as well as the rotation of the player character
                transform.rotation = currentRotation;
                transform.position = currentPosition;
                character.transform.localRotation = Quaternion.AngleAxis(xj, Vector3.up);

                // Setting the camera's current distance from the player
                currentDistance = Mathf.Clamp(helper.helperDistance, minDistance, maxDistance);


            }
        }

    }
}
