using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{

    [SerializeField]
    public Character character; // The character scriptedobject


    [SerializeField]
    public int playerNumber; // The controller number that will be passed to the charactercontroller

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 3.0f;


    // Variables handled by ScriptedObject
    private string playerName;
    public float speed;
    private float jumpHeight;
    private float jumpLength;
    private GameObject animated;
    private Collider playerCollider;
    private Rigidbody playerRigidbody;
    private Material playerMaterial;
    private Vector3 colliderOffset;
    private Vector3 colliderSize;
    private GameObject attack1;
    private GameObject attack2;
    public int hp;
    private Sprite crosshair;
    private bool isAlive;

    private AudioSource player_move;
    private AudioClip Move;

    private Animator animController;

    // Internal variables
    public uint resources;
    public uint depositedResources;
    private Vector3 originalPosition;
    private float invuln;
    private float respawnTimer;
    private Vector3 movementVector;
    private float distToGround;
    private Transform attackPosition;
    private bool Move_Toggle = false;
    private float startingHP;

    private TextMesh text;

    [SerializeField]
    public GameObject resource;
    public Image HealthBar;

    // Use this for initialization
    void Start()
    {
        loadCharacter();
        player_move = GetComponent<AudioSource>();
        startingHP = hp;

    }

    void loadCharacter()
    {
        // Assigning values from scriptableobject
        playerName = character.characterName;
        speed = character.speed;
        jumpHeight = character.jumpHeight;
        jumpLength = character.jumpLength;
        playerCollider = character.collider;
        playerRigidbody = gameObject.GetComponent<Rigidbody>();
        playerMaterial = character.material;
        colliderOffset = character.colliderOffset;
        colliderSize = character.colliderSize;
        attack1 = character.attack1.prefab;
        attack2 = character.attack2.prefab;
        Move = character.MovementSFX;
        animated = character.animatedCharacter;
        Instantiate(animated, gameObject.transform.position, animated.transform.rotation, gameObject.transform);
        hp = character.health;
        crosshair = character.reticle;
        isAlive = true;

        animController = gameObject.GetComponentInChildren<Animator>();



        // Assigning values to gameobject components where necessary
        gameObject.GetComponent<MeshRenderer>().material = playerMaterial;
        gameObject.AddComponent<BoxCollider>();
        gameObject.GetComponent<BoxCollider>().center = colliderOffset;
        gameObject.GetComponent<BoxCollider>().size = colliderSize;
        distToGround = gameObject.GetComponent<Collider>().bounds.extents.y;
        attackPosition = gameObject.transform.GetChild(1).gameObject.transform;

        text = gameObject.GetComponentInChildren<TextMesh>();

        // Setting up the camera viewspace
        //setCamera();

        // Setting player reticle
        gameObject.GetComponentInChildren<SpriteRenderer>().sprite = crosshair;

        // Recording original position for variable
        originalPosition = gameObject.transform.position;

    }

    // This sets up the part of the split-screen that this players camera will occupy
    // This function was only used in the local multiplayer version of the game, it is now defunct
    //void setCamera()
    //{
    //    // Top left
    //    if(playerNumber == 1)
    //    {
    //        Rect temp = Rect.zero;
    //        temp.Set(0.0f, 0.5f, 0.5f, 0.5f);
    //        gameObject.GetComponentInChildren<Camera>().rect = temp;
    //    }
    //
    //    // Top right
    //    else if (playerNumber == 2)
    //    {
    //        Rect temp = Rect.zero;
    //        temp.Set(0.5f, 0.5f, 0.5f, 0.5f);
    //        gameObject.GetComponentInChildren<Camera>().rect = temp;
    //    }
    //
    //    // Bottom left
    //    else if (playerNumber == 3)
    //    {
    //        Rect temp = Rect.zero;
    //        temp.Set(0.0f, 0.0f, 0.5f, 0.5f);
    //        gameObject.GetComponentInChildren<Camera>().rect = temp;
    //    }
    //
    //    // Bottom right
    //    else if (playerNumber == 4)
    //    {
    //        Rect temp = Rect.zero;
    //        temp.Set(0.5f, 0.0f, 0.5f, 0.5f);
    //        gameObject.GetComponentInChildren<Camera>().rect = temp;
    //    }
    //
    //    // In case something goes wrong
    //    else
    //    {
    //        Debug.Log("Error dividing screen");
    //    }
    //}

    // Checking if the player is grounded
    public bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround - 0.2f);
    }

    // Movement processing and updating
    public void Movement(int playerNumber)
    {
        animController.Play("Walk");

        // Getting the input of the Xbox controller left joystick on the X and Y axes
        movementVector.x = Input.GetAxis("LeftJoystickX_P" + playerNumber);
        movementVector.z = Input.GetAxis("LeftJoystickY_P" + playerNumber);

        // Updating the movement vector by multiplying the normalized vector by its speed vector and delta time
        movementVector = movementVector * speed * Time.deltaTime;

        // Translating the attached gameobject by the above movementvector
        transform.Translate(movementVector.x, 0, movementVector.z);
        if (movementVector.x != 0.0f || movementVector.z != 0.0f)
        {
            if (Move_Toggle == false)
            {
                Move_Toggle = true;

                if (IsGrounded())
                {
                    player_move.clip = Move;
                    player_move.loop = true;
                    player_move.Play();
                }
            }

        }
        else
        {
            Move_Toggle = false;
            player_move.Stop();
        }


    }

    // Jumping
    public void Jump()
    {
        // Making sure the player is grounded so they can't jump on thin air
        if (IsGrounded())
        {
            animController.Play("Jump");
            playerRigidbody.velocity = Vector3.up * jumpHeight;
        }
    }

    // Primary attack function
    public void PrimaryAttack()
    {
        animController.Play("Bite");
        GameObject tempAttack = Instantiate(attack1, attackPosition.position, attackPosition.rotation, attackPosition); // Setting the attack position as the parent of the 
        Destroy(tempAttack, 0.30f);

    }

    // Secondary attack function
    public void SecondaryAttack()
    {
        animController.Play("Scratch");
        GameObject tempAttack = Instantiate(attack2, attackPosition.position, attackPosition.rotation, attackPosition);
        Destroy(tempAttack, 0.20f);

    }

    // Invincibility
    private void Update()
    {
        if (invuln > 0.0f)
        {
            invuln -= Time.deltaTime;
        }

        text.text = hp.ToString();

        if (playerNumber != 0)
        {
            // Jump related
            if (playerRigidbody.velocity.y < 0)
            {
                // fallMultiplier is subtracted by 1 as Unity adds 1 by default
                playerRigidbody.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            }
            else if (playerRigidbody.velocity.y > 0 && !Input.GetButton("A_P" + playerNumber))
            {
                playerRigidbody.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            }
        }



    }

    // Function to handle taking damage
    public void TakeDamage(int dmg)
    {
        if (invuln <= 0.0f)
        {
            if (resources > 0)
            {
                hp -= dmg;
                //set our health bar to the amount of hp remaining
                HealthBar.fillAmount = hp / startingHP; // hp / starting hp to normalize hp
                invuln += 3.0f;
            }

            else
            {
                invuln += 3.0f;
            }

        }
        IsAlive();
    }

    // Function to handle whether the player is alive or not
    public bool IsAlive()
    {
        if(hp <= 0)
        {
            isAlive = false;
            Die();
            Invoke("Respawn", 5.0f);
        }

        return isAlive;
    }

    // Function to handle what happens to them when they die
    public void Die()
    {
        DropResources(resources); // Drops all the resources the player is carrying
        resources = 0;
    }

    // Function to respawn the player 
    public void Respawn()
    {
        hp = character.health; // Set player health back to original value
        gameObject.transform.position = originalPosition; // Return player to their original spawn point
        isAlive = true;


    }

    // Function to handle dropping of resources
    public void DropResources(uint r)
    {
        for (int i = 0; i < r; i++)
        {
            GameObject temp;
            temp = Instantiate(resource, gameObject.transform.position, gameObject.transform.rotation);
        }
    }

    // Public wrapper for resources
    public uint Resources
    {
        get { return resources; }
        set { value = resources; }
    }


}
