using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatController : MonoBehaviour
{
    // Movement
    private float moveSpeed;
    private Vector3 movementVector;
    private float xVel;
    private float yVel;

    // Movement animation
    private Animator ratAnimator;

    // Jumping
    private float fallMultiplier;
    private float lowJumpMultiplier;
    private float distToGround;
    private float jumpHeight;
    private Rigidbody _rigidbody;

    // Attacking
    private AttackController attacks;

    // Setup
    private int playerNumber;

    // Initialization
    void Start()
    {
        // Movement related
        moveSpeed = 8f;

        // Movement animation related
        ratAnimator = gameObject.GetComponent<Animator>();

        // Jump related
        fallMultiplier = 1.5f;
        lowJumpMultiplier = 2.0f;
        jumpHeight = 5.0f;
        _rigidbody = gameObject.GetComponent<Rigidbody>();

        // Attack related
        attacks = gameObject.GetComponentInChildren<AttackController>();

        // Setup
        distToGround = gameObject.GetComponent<Collider>().bounds.extents.y;
        playerNumber = gameObject.GetComponent<Player>().playerNum;
    }

    void FixedUpdate()
    {
        // Updating movement
        Movement();

        // Updating movement animation
        MovementAnim();

        // Updating jumping
        Jumping();

        // Updating attacks
        Attacks();
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

    // Movement animation function
    void MovementAnim()
    {
        float xVel = Input.GetAxis("LeftJoystickX_P" + playerNumber) * 5;
        float yVel = Input.GetAxis("LeftJoystickY_P" + playerNumber) * 5;

        ratAnimator.SetFloat("Movement_X", xVel);
        ratAnimator.SetFloat("Movement_Y", yVel);
    }


    // Jump function
    void Jumping()
    {
        // Waiting for jump button press
        if (Input.GetButtonDown("A_P" + playerNumber))
        {
            // Applying upward velocity if player is grounded
            if (IsGrounded())
            {
                _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, 0, _rigidbody.velocity.z);
                _rigidbody.velocity = Vector3.up * jumpHeight;
            }
        }


        if (_rigidbody.velocity.y < 0)
        {
            // Causes the player's jump to be higher and more floaty if they hold the button down
            _rigidbody.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (_rigidbody.velocity.y > 0 && !Input.GetButton("A_P" + playerNumber))
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
        if (Input.GetButtonDown("X_P" + playerNumber))
        {
            ratAnimator.SetTrigger("Punch");
        }
    }

    // Attack hitbox toggling function
    void ToggleActive()
    {
        attacks.attackActive = !attacks.attackActive;
    }
}
