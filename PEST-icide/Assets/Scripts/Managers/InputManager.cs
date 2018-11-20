using UnityEngine;

public class InputManager : MonoBehaviour
{ 

    public static InputManager instance = null;
    GameObject trap;

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
        trap = GameObject.FindGameObjectWithTag("Trap");
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

        if(Input.GetKeyDown("up"))
        {
            trap.GetComponent<GasTrap>().IsActive = true;
        }

    }

    void characterMovement()
    {
        // Movement blocks
        Rat.instance.SendMessage("ratMovement");
        Spider.instance.SendMessage("spiderMovement");
        Frog.instance.SendMessage("frogMovement");
        Snake.instance.SendMessage("snakeMovement");


        // Jumping blocks
        
        Rat.instance.SendMessage("ratJump");
        Spider.instance.SendMessage("spiderJump");

        if (Input.GetButtonDown("A_P3"))
        {
            Frog.instance.SendMessage("frogJump");
        }

        if (Input.GetButtonDown("A_P4"))
        {
            Snake.instance.SendMessage("snakeJump");
        }

        // Attacks

        if(Input.GetButtonDown("X_P1"))
        {
            Rat.instance.SendMessage("scratchAttack");
        }

        if(Input.GetButtonDown("Y_P1"))
        {
            Rat.instance.SendMessage("biteAttack");
        }

        if (Input.GetButtonDown("X_P2"))
        {
            EventManager.instance.TriggerEvent("spiderScratch");
        }

        if (Input.GetButtonDown("Y_P2"))
        {
            EventManager.instance.TriggerEvent("spiderBite");
        }

        if (Input.GetButtonDown("X_P3"))
        {
            EventManager.instance.TriggerEvent("frogScratch");
        }

        if (Input.GetButtonDown("Y_P3"))
        {
            EventManager.instance.TriggerEvent("frogBite");
        }

        if (Input.GetButtonDown("X_P4"))
        {
            EventManager.instance.TriggerEvent("snakeScratch");
        }

        if (Input.GetButtonDown("Y_P4"))
        {
            EventManager.instance.TriggerEvent("snakeBite");
        }

    }

}
