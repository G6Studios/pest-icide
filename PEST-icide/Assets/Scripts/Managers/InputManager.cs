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
            Debug.Log("Rat Jump");
        }

        if (Input.GetButtonDown("A_P2"))
        {
            EventManager.instance.TriggerEvent("spiderJumpEvent");
            Debug.Log("Spider Jump");
        }

        if (Input.GetButtonDown("A_P3"))
        {
            EventManager.instance.TriggerEvent("frogJumpEvent");
            Debug.Log("Frog Jump");
        }

        if (Input.GetButtonDown("A_P4"))
        {
            EventManager.instance.TriggerEvent("snakeJumpEvent");
            Debug.Log("Snake Jump");
        }

        // Attacks

        if(Input.GetButtonDown("X_P1"))
        {
            EventManager.instance.TriggerEvent("ratScratch");
        }

        if(Input.GetButton("Y_P1"))
        {
            EventManager.instance.TriggerEvent("ratBite");
        }

        if (Input.GetButtonDown("X_P2"))
        {
            EventManager.instance.TriggerEvent("spiderScratch");
        }

        if (Input.GetButton("Y_P2"))
        {
            EventManager.instance.TriggerEvent("spiderBite");
        }

        if (Input.GetButtonDown("X_P3"))
        {
            EventManager.instance.TriggerEvent("frogScratch");
        }

        if (Input.GetButton("Y_P3"))
        {
            EventManager.instance.TriggerEvent("frogBite");
        }

        if (Input.GetButtonDown("X_P4"))
        {
            EventManager.instance.TriggerEvent("snakeScratch");
        }

        if (Input.GetButton("Y_P4"))
        {
            EventManager.instance.TriggerEvent("snakeBite");
        }

    }

}
