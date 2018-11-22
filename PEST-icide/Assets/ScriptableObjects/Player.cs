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

        // Assigning values to gameobject components where necessary
        gameObject.GetComponent<MeshFilter>().mesh = playerMesh;
        gameObject.GetComponent<MeshRenderer>().material = playerMaterial;
        gameObject.AddComponent<SphereCollider>();

    }
}
