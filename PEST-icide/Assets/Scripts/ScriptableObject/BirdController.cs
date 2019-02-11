using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    // Statistics
    int resources;
    int health;

    // Movement
    private float moveSpeed;
    private Vector3 movementVector;
    private float xVel;
    private float yVel;

    // Jumping
    private float fallMultiplier;
    private float lowJumpMultiplier;
    private float distToGround;
    private float jumpHeight;
    private Rigidbody _rigidbody;
    private bool doubleJump;

    // Attacking
    private BirdAttacks attacks;

    // Setup
    public int playerNumber;

    // Initialization
    void Start()
    {
        // Movement related
        moveSpeed = 10f;

        // Jump related
        fallMultiplier = 1.5f;
        lowJumpMultiplier = 2.0f;
        jumpHeight = 6.0f;
        _rigidbody = gameObject.GetComponent<Rigidbody>();
        doubleJump = true;

        // Attack related
        attacks = gameObject.GetComponentInChildren<BirdAttacks>();

        playerNumber = 1;
        distToGround = gameObject.GetComponent<Collider>().bounds.extents.y;
    }

    void Update()
    {
        // Updating movement
        Movement();

        // Updating jumping
        Jumping();
    }

    // Movement function
    void Movement()
    {
        // Getting input from controller
        movementVector.x = Input.GetAxis("LeftJoystickX_P" + playerNumber);
        movementVector.z = Input.GetAxis("LeftJoystickY_P" + playerNumber);

        // Updating the movement vector
        movementVector = movementVector * moveSpeed * Time.deltaTime;

        // Applying the translation from the movement vector
        transform.Translate(movementVector.x, 0, movementVector.z);
    }


    // Jump function
    void Jumping()
    {
        // Waiting for jump button press
        if(Input.GetButtonDown("A_P" + playerNumber))
        {
            // Applying upward velocity if player is grounded
            if (IsGrounded())
            {
                _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, 0, _rigidbody.velocity.z);
                _rigidbody.velocity = Vector3.up * jumpHeight;
                doubleJump = true;
            }
            else
            {
                if(doubleJump)
                {
                    doubleJump = false;
                    _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, 0, _rigidbody.velocity.z);
                    _rigidbody.velocity = Vector3.up * jumpHeight;
                }
            }
        }
        

        if(_rigidbody.velocity.y < 0)
        {
            // Causes the player's jump to be higher and more floaty if they hold the button down
            _rigidbody.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if(_rigidbody.velocity.y > 0 && !Input.GetButton("A_P" + playerNumber))
        {
            // Causes the player to fall faster and not jump as high if they tap the button
            _rigidbody.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }

    }

    // Checking if player is on the ground
    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround);
    }

    // Attack function
    void Attacks()
    {
        if(Input.GetButtonDown("X_P" + playerNumber))
        {
            attacks.Attack();
        }
    }

}
