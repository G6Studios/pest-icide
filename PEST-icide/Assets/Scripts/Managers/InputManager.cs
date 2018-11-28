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


}
