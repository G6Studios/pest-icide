using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    public Character character; // The character scriptedobject

    [SerializeField]
    public int playerNumber; // The controller number that will be passed to the charactercontroller

    // Variables handled by ScriptedObject
    private string playerName;
    private float speed;
    private float jumpHeight;
    private float jumpLength;
    private Collider playerCollider;
    private Rigidbody playerRigidbody;
    private Mesh playerMesh;
    private Material playerMaterial;
    private Vector3 colliderOffset;
    private Vector3 colliderSize;

    // Internal variables
    private float resources;
    private float invuln;
    private Vector3 movementVector;
    private float distToGround;

	// Use this for initialization
	void Start () {
        loadCharacter();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void loadCharacter()
    {
        // Assigning values from scriptableobject
        playerName = character.characterName;
        speed = character.speed;
        jumpHeight = character.jumpHeight;
        jumpLength = character.jumpLength;
        playerCollider = character.collider;
        playerRigidbody = character.rigidbody;
        playerMesh = character.mesh;
        playerMaterial = character.material;
        colliderOffset = character.colliderOffset;
        colliderSize = character.colliderSize;

        // Assigning values to gameobject components where necessary
        gameObject.GetComponent<MeshFilter>().mesh = playerMesh;
        gameObject.GetComponent<MeshRenderer>().material = playerMaterial;
        gameObject.AddComponent<BoxCollider>();
        gameObject.GetComponent<BoxCollider>().center = colliderOffset;
        gameObject.GetComponent<BoxCollider>().size = colliderSize;

    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }

    void Movement(int playerNumber)
    {
        movementVector.x = Input.GetAxis("LeftJoystickX_P" + playerNumber);
        movementVector.z = Input.GetAxis("LeftJoystickY_P" + playerNumber);

        movementVector = movementVector.normalized * speed * Time.deltaTime;

        transform.Translate(movementVector.x, 0, movementVector.z);
    }

    void Jump(int playerNumber)
    {
        if(Input.GetButtonDown("A_P" + playerNumber))
        {
            if (IsGrounded())
                playerRigidbody.AddForce(0.0f, jumpHeight, 0.0f, ForceMode.Impulse);
        }
    }

    void PrimaryAttack(GameObject attack1)
    {

    }

    void SecondaryAttack(GameObject attack2)
    {

    }

}
