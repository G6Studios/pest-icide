using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkBirdController : NetworkBehaviour
{

    // Movement
    private float moveSpeed;
    private Vector3 movementVector;
    private float xVel;
    private float yVel;

    // Movement animation
    private Animator birdAnimator;

    // Jumping
    private float fallMultiplier;
    private float lowJumpMultiplier;
    private float distToGround;
    private float jumpHeight;
    private Rigidbody _rigidbody;
    private bool doubleJump;

    // Attacking
    private AttackController attacks;
    private float cooldown;
    private float cooldownTimer;
    private bool canAttack;

    // Setup
    private int playerNumber;
    public Camera cam;


    // Initialization
    void Start()
    {
        // Movement related
        moveSpeed = gameObject.GetComponent<Player>().speed;


        // Movement animation related
        birdAnimator = gameObject.GetComponent<Animator>();

        // Jump related
        fallMultiplier = 1.5f;
        lowJumpMultiplier = 2.0f;
        jumpHeight = 6.0f;
        _rigidbody = gameObject.GetComponent<Rigidbody>();
        doubleJump = true;

        // Attack related
        attacks = gameObject.GetComponentInChildren<AttackController>();
        cooldown = 1.5f;
        cooldownTimer = 0.0f;


        // Setup
        distToGround = gameObject.GetComponent<Collider>().bounds.extents.y;
        playerNumber = gameObject.GetComponent<Player>().playerNum;

        if (isLocalPlayer)
            return;
        cam.enabled = false;
    }

    void FixedUpdate()
    {
        if (!isLocalPlayer)
            return;
        //Debug.DrawRay(transform.position + new Vector3(0f, 0.8f, 0f), -Vector3.up * (0.9f), Color.green);
        // Player shouldn't be able to do any of these things if they are dead
        if (!GetComponent<Player>().died)
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

        // Updating cooldowns
        Cooldowns();
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

        birdAnimator.SetFloat("Movement_X", xVel);
        birdAnimator.SetFloat("Movement_Y", yVel);
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
                doubleJump = true;
            }
            else
            {
                if (doubleJump)
                {
                    doubleJump = false;
                    _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, 0, _rigidbody.velocity.z);
                    _rigidbody.velocity = Vector3.up * jumpHeight;
                }
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
        return Physics.Raycast(transform.position + new Vector3(0, 0.8f, 0f), -Vector3.up, 0.9f);
    }

    // Attack function
    void Attacks()
    {
        if (Input.GetButtonDown("X_P" + playerNumber))
        {
            if (canAttack == true)
            {
                birdAnimator.SetTrigger("Punch");
                cooldownTimer = 0.0f;
            }

            else
            {
                Debug.Log("Bird attack on cooldown!");
            }

        }
    }

    // Attack hitbox toggling function
    void ToggleActive()
    {
        attacks.attackActive = !attacks.attackActive;
    }

    // Processing attack cooldowns
    void Cooldowns()
    {
        // Offloading this information to the attackcontroller so it can be easily accessed by the UI manager
        GetComponentInChildren<AttackController>().cooldownProxy = cooldown;
        GetComponentInChildren<AttackController>().cooldownTimerProxy = cooldownTimer;
        if (cooldownTimer < cooldown)
        {
            cooldownTimer += Time.deltaTime;
            canAttack = false;
        }

        else
        {
            canAttack = true;
        }

    }

}
