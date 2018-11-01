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

    // For events
    private UnityAction rat;

    // Use this for initialization
    void Start ()
    {
        Resources = 0.0f;
        Speed = 7.0f;
        JumpHeight = 0.5f;
        JumpLength = 1.0f;

	}

    public void OnEnable()
    {
        EventManager.StartListening("rat", rat);
    }

    public void OnDisable()
    {
        EventManager.StopListening("rat", rat);
    }

    public void ratMovement()
    {
        r_movementVector.x = Input.GetAxis("Horizontal");
        r_movementVector.z = Input.GetAxis("Vertical");

        r_movementVector = r_movementVector.normalized * Speed * Time.deltaTime;

        transform.Translate(r_movementVector.x, 0, r_movementVector.z);
    }

    private void Awake()
    {
        rat = new UnityAction(ratMovement);
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
