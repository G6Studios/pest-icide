using UnityEngine;
using UnityEngine.Events;

public class Frog : MonoBehaviour {
    // Data members
    private float f_resources;
    private float f_speed;
    private float f_jumpHeight;
    private float f_jumpLength;
    private Vector3 f_movementVector;
    Collider f_collider;
    private float f_distToGround;
    Rigidbody f_rigidBody;

    // For events
    private UnityAction frogMoveEvent;
    private UnityAction frogJumpEvent;

	// Use this for initialization
	void Start () {
        Resources = 0.0f;
        Speed = 3.0f;
        JumpHeight = 5.0f;
        JumpLength = 5.0f;

        // Components
        f_rigidBody = gameObject.GetComponent<Rigidbody>();

        // Enables the listeners for frog-related events
        EventManager.instance.StartListening("frogMoveEvent", frogMoveEvent);
        EventManager.instance.StartListening("frogJumpEvent", frogJumpEvent);

	}

    // Movement for the frog
    private void frogMovement()
    {
        f_movementVector.x = Input.GetAxis("Horizontal");
        f_movementVector.z = Input.GetAxis("Vertical");

        f_movementVector = f_movementVector.normalized * Speed * Time.deltaTime;

        transform.Translate(f_movementVector.x, 0, f_movementVector.z);
    }

    // Jumping for the frog
    private void frogJump()
    {
        f_rigidBody.AddForce(0.0f, f_jumpHeight, 0.0f, ForceMode.Impulse);
    }


    private void Awake()
    {
        frogMoveEvent = new UnityAction(frogMovement);
        frogJumpEvent = new UnityAction(frogJump);
    }

    // Setters and getters
    public float Resources
    {
        get { return f_resources; }
        set { f_resources = value; }
    }

    public float Speed
    {
        get { return f_speed; }
        set { f_speed = value; }
    }

    public float JumpHeight
    {
        get { return f_jumpHeight; }
        set { f_jumpHeight = value; }
    }

    public float JumpLength
    {
        get { return f_jumpLength; }
        set { f_jumpLength = value; }
    }
	

}
