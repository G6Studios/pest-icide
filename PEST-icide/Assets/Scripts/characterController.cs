using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{

    private Vector3 movementVector; //Movement vector for the player
    public float speed = 10.0f; // Variable controlling how fast the player moves
    private float jump = 15; //Players jump value
    private float gravity = 40;

    // Use this for initialization
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        //float translation = Input.GetAxis("Vertical") * speed;
        //  float strafe = Input.GetAxis("Horizontal") * speed;
        // translation *= Time.deltaTime;
        // strafe *= Time.deltaTime;

        // transform.Translate(strafe, 0, translation);


        if (Input.GetKey("d") || Input.GetKey("a") || Input.GetKey("w") || Input.GetKey("s"))
        {
            movementVector.x = Input.GetAxis("Horizontal") * speed;
            movementVector.x *= Time.deltaTime;

            movementVector.z = Input.GetAxis("Vertical") * speed;
            movementVector.z *= Time.deltaTime;

            transform.Translate(movementVector.x, 0, movementVector.z);

        }
        else
        {
            movementVector.x = Input.GetAxis("LeftJoystickX") * speed;
            movementVector.x *= Time.deltaTime;

            movementVector.z = Input.GetAxis("LeftJoystickY") * speed;
            movementVector.z *= Time.deltaTime;

            transform.Translate(movementVector.x, 0, movementVector.z);

        }




        /* if (character isGrounded)
         
             movementVector.y = 0;

             if (Input.GetButtonDown("A"))
             {
                 movementVector.y = jump;
             }
         }

         movementVector.y -= (gravity * Time.deltaTime);
         */



        // Pressing escape will unlock the cursor
        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }

    }
}
