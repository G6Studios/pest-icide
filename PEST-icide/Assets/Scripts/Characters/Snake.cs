using UnityEngine;

public class Snake : MonoBehaviour {
    // Data members
    private float sn_resources;
    private float sn_speed;
    private float sn_jumpHeight;
    private float sn_jumpLength;
    private float sn_invuln;
    private Vector3 sn_movementVector;
    Collider sn_collider;
    private float sn_distToGround;
    Rigidbody sn_rigidBody;

    public static Snake instance;

    [SerializeField]
    Transform attackPosition;

    [SerializeField]
    GameObject scratch;

    [SerializeField]
    GameObject bite;

	// Use this for initialization
	void Start ()
    {
        Resources = 0.0f;
        Speed = 3.0f;
        JumpHeight = 2.0f;
        JumpLength = 5.0f;
        Invulnerable = 0.0f;

        // Components
        sn_rigidBody = gameObject.GetComponent<Rigidbody>();
        sn_collider = gameObject.GetComponent<Collider>();

        sn_distToGround = sn_collider.bounds.extents.y;

	}

    // Movement for the snake
    private void snakeMovement()
    {
        sn_movementVector.x = Input.GetAxis("LeftJoystickX_P4");
        sn_movementVector.z = Input.GetAxis("LeftJoystickY_P4");

        sn_movementVector = sn_movementVector.normalized * Speed * Time.deltaTime;

        transform.Translate(sn_movementVector.x, 0, sn_movementVector.z);
    }

    // Jumping for the snake
    private void snakeJump()
    {
        if(IsGrounded())
        sn_rigidBody.AddForce(0.0f, sn_jumpHeight, 0.0f, ForceMode.Impulse);
    }

    private void scratchAttack()
    {
        GameObject tempAttack = Instantiate(scratch, attackPosition.position, attackPosition.rotation);
        Destroy(tempAttack, 0.20f);


    }

    private void biteAttack()
    {
        GameObject tempAttack = Instantiate(bite, attackPosition.position, attackPosition.rotation);
        Destroy(tempAttack, 0.30f);
    }

    private void takeDamage(float dmg)
    {
        if(Invulnerable <= 0.0f)
        {
            Resources -= dmg;
            Invulnerable += 3.0f;
        }
    }

    private void Update()
    {
        if(Invulnerable > 0.0f)
        {
            Invulnerable -= Time.deltaTime;
        }
    }


    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, sn_distToGround + 0.1f);
    }

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

    public float Invulnerable
    {
        get { return sn_invuln; }
        set { sn_invuln = value; }
    }
}
