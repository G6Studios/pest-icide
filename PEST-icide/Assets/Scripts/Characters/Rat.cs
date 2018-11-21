using UnityEngine;

public class Rat : MonoBehaviour {
    // Data members
    private float r_resources;
    private float r_speed;
    private float r_jumpHeight;
    private float r_jumpLength;
    private float r_invuln;
    private Vector3 r_movementVector;
    Collider r_collider;
    private float r_distToGround;
    Rigidbody r_rigidBody;

    public static Rat instance;

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
        // Individual statistics
        Resources = 0.0f;
        Speed = 7.0f;
        JumpHeight = 5.0f;
        JumpLength = 1.0f;
        Invulnerable = 0.0f;

        // Components
        r_rigidBody = gameObject.GetComponent<Rigidbody>();
        r_collider = gameObject.GetComponent<Collider>();

        r_distToGround = r_collider.bounds.extents.y;

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
        if (Input.GetButtonDown("A_P1"))
        {
            if (IsGrounded())
                r_rigidBody.AddForce(0.0f, r_jumpHeight, 0.0f, ForceMode.Impulse);
        }
    }

    // Scratch attack
    private void RatScratch()
    {
        GameObject tempAttack = Instantiate(scratch, attackPosition.position, attackPosition.rotation);
        Destroy(tempAttack, 0.20f);
        

    }

    private void RatBite()
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

    private bool IsGrounded() 
    {
        return Physics.Raycast(transform.position, -Vector3.up, r_distToGround + 0.1f);
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

    public float Invulnerable
    {
        get { return r_invuln; }
        set { r_invuln = value; }
    }

    
	
}
