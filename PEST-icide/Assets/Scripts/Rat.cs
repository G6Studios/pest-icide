using UnityEngine;
using UnityEngine.Events;

public class Rat : MonoBehaviour {
    // Data members
    private float r_resources;
    private float r_speed;
    private float r_jumpHeight;
    private float r_jumpLength;
    private Vector3 r_movementVector;
    Collider r_collider;
    private float r_distToGround;
    Rigidbody r_rigidBody;

    // Attacks
    GameObject scratch;

    // For events
    private UnityAction ratMoveEvent;
    private UnityAction ratJumpEvent;
    private UnityAction ratScratch;

    // Use this for initialization
    void Start ()
    {
        // Individual statistics
        Resources = 0.0f;
        Speed = 7.0f;
        JumpHeight = 0.5f;
        JumpLength = 1.0f;

        // Components
        r_rigidBody = gameObject.GetComponent<Rigidbody>();

        // Enables the listeners for rat-related events
        EventManager.instance.StartListening("ratMoveEvent", ratMoveEvent);
        EventManager.instance.StartListening("ratJumpEvent", ratJumpEvent);
        EventManager.instance.StartListening("ratScratch", ratScratch);

        // Attacks
        scratch = GameObject.Find("scratchAttack");
    }

    // Cleans up after we disable its gameobject
    public void OnDisable()
    {
        EventManager.instance.StopListening("ratMoveEvent", ratMoveEvent);
        EventManager.instance.StopListening("ratJumpEvent", ratJumpEvent);
        EventManager.instance.StopListening("ratScratch", ratScratch);
    }

    // Movement for the rat
    private void ratMovement()
    {
        r_movementVector.x = Input.GetAxis("LeftJoystickX_P1");
        r_movementVector.z = Input.GetAxis("LeftJoystickY_P1");

        r_movementVector = r_movementVector.normalized * Speed * Time.deltaTime;

        transform.Translate(r_movementVector.x, 0, r_movementVector.z);
    }

    // Jumping for the rat
    private void ratJump()
    {
        r_rigidBody.AddForce(0.0f, r_jumpHeight, 0.0f, ForceMode.Impulse);

    }

    // Attack
    private void attack()
    {
        scratch.SetActive(true);
        EventManager.instance.TriggerEvent("ScratchAttack");
    }


    private void Awake()
    {
        ratMoveEvent = new UnityAction(ratMovement);
        ratJumpEvent = new UnityAction(ratJump);
        ratScratch = new UnityAction(attack);
    }

    // Getters and setters
    public float Resources
    {
        get { return r_resources; }
        set { r_resources = value; }
    }

    public float Speed
    {
        get { return r_speed; }
        set { r_speed = value; }
    }

    public float JumpHeight
    {
        get { return r_jumpHeight; }
        set { r_jumpHeight = value; }
    }

    public float JumpLength
    {
        get { return r_jumpLength; }
        set { r_jumpLength = value; }
    }

    
	
}
