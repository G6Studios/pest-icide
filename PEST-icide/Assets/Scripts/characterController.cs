using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class characterController : MonoBehaviour
{

    private Vector3 m_movementVector; //Movement vector for the player
    Collider m_collider;
    //private float m_gravity = 1;
    private float m_distToGround;
    Rigidbody playerRigidbody;

    public float jump = 0.5f; //Players jump value
    public float jumpLength = 1.0f;
    public float speed = 10.0f; // Variable controlling how fast the player moves
    public int joystickNumber; // public variable to which we can assign the player to the controller number

    //initializes regardless if script is active or not
    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Use this for initialization 
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        m_collider = GetComponent<Collider>();
        m_distToGround = m_collider.bounds.extents.y; //grab the players distance to the ground based on the collider

    }

    void FixedUpdate()
    {
        characterMovement(); // gets input and moves character

    }

    // Update is called once per frame
    void Update()
    {
        // Pressing escape will unlock the cursor
        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }

    }

    bool IsGrounded() // checks if our player is grounded
    {
        return Physics.Raycast(transform.position, -Vector3.up, m_distToGround+0.1f); 
    }

    void characterMovement()
    {

        //float translation = Input.GetAxis("Vertical") * speed;
        //  float strafe = Input.GetAxis("Horizontal") * speed;
        // translation *= Time.deltaTime;
        // strafe *= Time.deltaTime;

        // transform.Translate(strafe, 0, translation);



        string joystickString = joystickNumber.ToString(); // converts the controller number to string


        if (IsGrounded())
        {

            if (Input.GetButton("B_P" + joystickString))
            {
                playerRigidbody.AddForce(0.0f, jump, 0.0f, ForceMode.Impulse);
            }
            else if (Input.GetKey(KeyCode.Space) && joystickNumber == 1)
            {
                // playerRigidbody.AddForce(0.0f, jump, 0.0f,ForceMode.Impulse);
                EventManager.instance.TriggerEvent("ratJumpEvent");
                Debug.Log("Space pressed");
            }
        }

       // movementVector.y -= (m_gravity * Time.deltaTime);

        if(Input.GetKey("h"))
        {
            EventManager.instance.TriggerEvent("ratScratch");
        }

        if ((Input.GetKey("d") || Input.GetKey("a") || Input.GetKey("w") || Input.GetKey("s")) && joystickNumber == 1)
        {
            EventManager.instance.TriggerEvent("ratMoveEvent");
            //m_movementVector.x = Input.GetAxis("Horizontal");// * speed;
            //m_movementVector.z = Input.GetAxis("Vertical");// * speed;

            //m_movementVector = m_movementVector.normalized * speed * Time.deltaTime;

            //movementVector.x *= Time.deltaTime;
            //movementVector.z *= Time.deltaTime;

            //playerRigidbody.MovePosition(transform.position + movementVector);

            //transform.Translate(m_movementVector.x, 0, m_movementVector.z);

        }
        else
        {
            EventManager.instance.TriggerEvent("spiderMoveEvent");
            m_movementVector.x = Input.GetAxis("LeftJoystickX_P" + joystickString) * speed; // gets axis depending on which controller is using the input
            m_movementVector.z = Input.GetAxis("LeftJoystickY_P" + joystickString) * speed;

            m_movementVector = m_movementVector.normalized * speed * Time.deltaTime;


            //playerRigidbody.MovePosition(transform.position + movementVector);

            transform.Translate(m_movementVector.x, 0, m_movementVector.z);



        }
    }

}
