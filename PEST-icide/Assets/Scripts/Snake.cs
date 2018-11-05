using UnityEngine;
using UnityEngine.Events;

public class Snake : MonoBehaviour {
    // Data members
    private float sn_resources;
    private float sn_speed;
    private float sn_jumpHeight;
    private float sn_jumpLength;
    private Vector3 sn_movementVector;
    Collider sn_collider;
    private float sn_distToGround;
    Rigidbody sn_rigidBody;

    // For events
    private UnityAction snakeMoveEvent;
    private UnityAction snakeJumpEvent;

	// Use this for initialization
	void Start ()
    {
        Resources = 0.0f;
        Speed = 3.0f;
        JumpHeight = 2.0f;
        JumpLength = 5.0f;

        // Components
        sn_rigidBody = gameObject.GetComponent<Rigidbody>();

        // Enables the listeners for snake-related events
        EventManager.instance.StartListening("snakeMoveEvent", snakeMoveEvent);
        EventManager.instance.StartListening("snakeJumpEvent", snakeJumpEvent);

	}

    // Movement for the snake
    private void snakeMovement()
    {
        sn_movementVector.x = Input.GetAxis("Horizontal");
        sn_movementVector.z = Input.GetAxis("Vertical");

        sn_movementVector = sn_movementVector.normalized * Speed * Time.deltaTime;

        transform.Translate(sn_movementVector.x, 0, sn_movementVector.z);
    }

    // Jumping for the snake
    private void snakeJump()
    {
        sn_rigidBody.AddForce(0.0f, sn_jumpHeight, 0.0f, ForceMode.Impulse);
    }
	
    // Setters and getters
    public float Resources
    {
        get { return sn_resources; }
        set { sn_resources = value; }
    }

    public float Speed
    {
        get { return sn_speed; }
        set { sn_speed = value; }
    }

    public float JumpHeight
    {
        get { return sn_jumpHeight; }
        set { sn_jumpHeight = value; }
    }

    public float JumpLength
    {
        get { return sn_jumpLength; }
        set { sn_jumpLength = value; }
    }
}
