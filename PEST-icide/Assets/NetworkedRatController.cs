using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkedRatController : NetworkBehaviour
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
    private float airTimer;
    private float airTimerLimit;

    // Attacking
    private NetworkAttackController attacks;
    private float cooldown;
    private float cooldownTimer;
    private bool canAttack;

    // Setup
    private int playerNumber;
    private AudioSource sounds;
    public AudioClip attack;
    public Camera cam;


    // Initialization
    void Start()
    {
        // Movement related
        moveSpeed = gameObject.GetComponent<NetworkedPlayer>().speed;

        // Movement animation related
        ratAnimator = gameObject.GetComponent<Animator>();

        // Jump related
        fallMultiplier = 1.5f;
        lowJumpMultiplier = 2.0f;
        jumpHeight = 5.0f;
        _rigidbody = gameObject.GetComponent<Rigidbody>();
        airTimerLimit = 0.25f;

        // Attack related
        attacks = gameObject.GetComponentInChildren<NetworkAttackController>();
        cooldown = 2.0f;
        cooldownTimer = 0.0f;

        // Setup
        distToGround = gameObject.GetComponent<Collider>().bounds.extents.y;
        playerNumber = gameObject.GetComponent<NetworkedPlayer>().playerNum;
        sounds = gameObject.GetComponent<AudioSource>();

        if (isLocalPlayer)
            return;
        cam.enabled = false;
    }

    void FixedUpdate()
    {
        if (!isLocalPlayer)
            return;
        // Debug.DrawRay(transform.position + new Vector3(0f, 0.8f, 0f), -Vector3.up * (0.9f), Color.green);
        // Player shouldn't be able to do any of these things if they are dead
        if (!GetComponent<NetworkedPlayer>().died)
        {
            // Updating movement
            Movement();

            // Updating movement animation
            MovementAnim();

            // Updating jumping
            // Waiting for jump button press
            if (Input.GetButton("A_P" + playerNumber))
            {
                Jumping();
            }

            // Updating jump animation
            JumpAnim();

            // Dynamic jump processing
            JumpProcessing();

            // Updating attacks
            if (Input.GetButton("X_P" + playerNumber))
            {
                Attacks();
            }
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

        ratAnimator.SetFloat("Movement_X", xVel);
        ratAnimator.SetFloat("Movement_Y", yVel);
    }


    // Jump function
    void Jumping()
    {
        // Applying upward velocity if player is grounded
        if (IsGrounded())
        {
            _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, 0, _rigidbody.velocity.z);
            _rigidbody.velocity = Vector3.up * jumpHeight;
        }

    }

    // Jump animation
    void JumpAnim()
    {
        if (!IsGrounded())
        {
            airTimer += Time.deltaTime;
            if (airTimer > airTimerLimit)
            {
                ratAnimator.SetBool("isGrounded", false);
            }

        }

        else
        {
            ratAnimator.SetBool("isGrounded", true);
            airTimer = 0.0f;
        }
    }

    void JumpProcessing()
    {
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
        return Physics.Raycast(transform.position + new Vector3(0f, 0.8f, 0f), -Vector3.up, 0.9f);
    }

    // Attack function
    void Attacks()
    {

        if (canAttack == true && IsGrounded())
        {
            sounds.clip = attack;
            sounds.Play();
            ratAnimator.SetTrigger("Punch");
            cooldownTimer = 0.0f;
        }

        else
        {
            Debug.Log("Rat attack on cooldown!");
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
        GetComponentInChildren<NetworkAttackController>().cooldownProxy = cooldown;
        GetComponentInChildren<NetworkAttackController>().cooldownTimerProxy = cooldownTimer;
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
