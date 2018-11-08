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
       
    }

}
