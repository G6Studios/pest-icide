using UnityEngine;
using UnityEngine.Events;

public class InputManager : MonoBehaviour
{ 

    public static InputManager instance = null;

    // Awake() runs before any Start() calls
    // Enforces the singleton pattern
    private void Awake()
    {
        // Check if instance exists
        if (instance == null)
        {
            // If not, set the game manager to this
            instance = this;
        }

        else if (instance != this)
        {
            Destroy(gameObject);
        }

        // Ensures that this persists between scenes
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization 
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
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

    void characterMovement()
    {
        // Movement blocks
        EventManager.instance.TriggerEvent("ratMoveEvent");
        EventManager.instance.TriggerEvent("spiderMoveEvent");
        EventManager.instance.TriggerEvent("frogMoveEvent");
        EventManager.instance.TriggerEvent("snakeMoveEvent");


        // Jumping blocks
        if(Input.GetButtonDown("A_P1"))
        {
            EventManager.instance.TriggerEvent("ratJumpEvent");
        }

        if (Input.GetButtonDown("A_P2"))
        {
            EventManager.instance.TriggerEvent("spiderJumpEvent");
        }

        if (Input.GetButtonDown("A_P3"))
        {
            EventManager.instance.TriggerEvent("frogJumpEvent");
        }

        if (Input.GetButtonDown("A_P4"))
        {
            EventManager.instance.TriggerEvent("snakeJumpEvent");
        }

        // Attacks
        



        //if (Input.GetButtonDown("A_P1"))
        //{
        //    EventManager.instance.TriggerEvent("ratScratch");
        //}
        //
        //if(Input.GetButton("Y_P1"))
        //{
        //    EventManager.instance.TriggerEvent("ratBite");
        //}

        if ((Input.GetKey("d") || Input.GetKey("a") || Input.GetKey("w") || Input.GetKey("s")))
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
            //m_movementVector.x = Input.GetAxis("LeftJoystickX_P" + joystickString) * speed; // gets axis depending on which controller is using the input
            //m_movementVector.z = Input.GetAxis("LeftJoystickY_P" + joystickString) * speed;

            //m_movementVector = m_movementVector.normalized * speed * Time.deltaTime;


            //playerRigidbody.MovePosition(transform.position + movementVector);

            //transform.Translate(m_movementVector.x, 0, m_movementVector.z);



        }
    }

}
