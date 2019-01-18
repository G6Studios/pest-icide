using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCamera : MonoBehaviour
{

    //public GameObject player; // For getting the joystick numbers easily
    public Transform target; // What the camera will be looking at
    float xm = 0.0f; // For mouse
    float ym = 0.0f; // For mouse
    float xj = 0.0f; // For joystick
    float yj = 0.0f; // For joystick
    public float xSensitivity = 5.0f;
    public float ySensitivity = 5.0f;
    public int joystickNumber;
    public float currentDistance = 3.0f;
    public float maxDistance = 5.0f;
    public float minDistance = 1.0f;
    public CameraHelper helper;
    public GameObject character;


    // Use this for initialization
    void Start()
    {
        character = this.transform.parent.gameObject;
        Vector3 angles = transform.eulerAngles; // Getting the angles of the attached object (camera)
        // These are flipped for later in the process
        xm = angles.y;
        ym = angles.x;
        xj = angles.y;
        yj = angles.x;

        //joystickNumber = player.GetComponent<Player>().playerNumber; // Getting the joystick number
        string joystickString = joystickNumber.ToString(); // Converting to string when getting axis input

    }

    private void Update()
    {
        currentDistance = helper.oldDistance;

        if(currentDistance > 3)
        {
            currentDistance = 3;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (joystickNumber != 0) // Making sure the joystick number is not 0, and therefore not a bot
        {
            string joystickString = joystickNumber.ToString();
            if (target) // Making sure the camera has something to look at
            {
                // Update x and y for the mouse
                xj += Input.GetAxis("RightJoystickX_P" + joystickString) * xSensitivity * currentDistance;
                yj -= Input.GetAxis("RightJoystickY_P" + joystickString) * ySensitivity;

                // Clamp y so that the player cannot roll the camera over its axis
                yj = Mathf.Clamp(ym, -5.0f, 0.0f);

                // Updating the rotation quaternion
                Quaternion currentRotation = Quaternion.Euler(yj, xj, 0); // Due to Unity calculating the rotation values in order of Z, X, Y, we need to trick it a bit

                // Defining the distance from the target in reverse and setting the camera position
                Vector3 reverseDistance = new Vector3(0.0f, 0.0f, -currentDistance);
                Vector3 currentPosition = currentRotation * reverseDistance + target.position;

                transform.rotation = currentRotation;
                transform.position = currentPosition;
                character.transform.localRotation = Quaternion.AngleAxis(xj, character.transform.up);


            }
        }

    }
}
