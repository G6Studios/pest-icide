using UnityEngine;

public class Spider : MonoBehaviour {
    // Data members
    private float sp_resources;
    private float sp_speed;
    private float sp_jumpHeight;
    private float sp_jumpLength;
    private float sp_invuln;
    private Vector3 sp_movementVector;
    Collider sp_collider;
    private float sp_distToGround;
    Rigidbody sp_rigidBody;

    public static Spider instance;

    // Attacks
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
        Speed = 7.0f;
        JumpHeight = 3.0f;
        JumpLength = 1.5f;

        // Components
        sp_rigidBody = gameObject.GetComponent<Rigidbody>();
        sp_collider = gameObject.GetComponent<Collider>();

        sp_distToGround = sp_collider.bounds.extents.y;

	}

    private bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, sp_distToGround + 0.1f);
    }

    private void spiderMovement()
    {
        sp_movementVector.x = Input.GetAxis("LeftJoystickX_P2");
        sp_movementVector.z = Input.GetAxis("LeftJoystickY_P2");

        sp_movementVector = sp_movementVector.normalized * Speed * Time.deltaTime;

        transform.Translate(sp_movementVector.x, 0, sp_movementVector.z);
    }

    private void spiderJump()
    {
        if (Input.GetButtonDown("A_P2"))
        {
            if (IsGrounded())
                sp_rigidBody.AddForce(0.0f, sp_jumpHeight, 0.0f, ForceMode.Impulse);
        }
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

    // Getters and setters
    public float Resources
    {
        get { return sp_resources; }
        set { sp_resources = value; }
    }

    public float Speed
    {
        get { return sp_speed; }
        set { sp_speed = value; }
    }

    public float JumpHeight
    {
        get { return sp_jumpHeight; }
        set { sp_jumpHeight = value; }
    }

    public float JumpLength
    {
        get { return sp_jumpLength; }
        set { sp_jumpLength = value; }
    }

    public float Invulnerable
    {
        get { return sp_invuln; }
        set { sp_invuln = value; }
    }
	
}
