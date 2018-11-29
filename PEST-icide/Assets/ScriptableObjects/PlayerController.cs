using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public int controllerNumber;

	// Use this for initialization
	void Start () {
        controllerNumber = gameObject.GetComponent<Player>().playerNumber;

	}
	
	// FixedUpdate is best used for physics calculations
    void FixedUpdate()
    {
        getCharacterMovement(controllerNumber);
    }
	
    void getCharacterMovement(int controller)
    {
        // Movement processing
        if (Input.GetAxis("LeftJoystickX_P" + controller) != 0 || Input.GetAxis("LeftJoystickY_P" + controller) != 0)
        {
            gameObject.GetComponent<Player>().Movement(controller);
        }

        // Jump processing
        if(Input.GetButtonDown("A_P" + controller))
        {
            gameObject.GetComponent<Player>().Jump();
        }

        if(Input.GetButtonDown("X_P" + controller))
        {
            gameObject.GetComponent<Player>().PrimaryAttack();
        }

        if(Input.GetButtonDown("Y_P" + controller))
        {
            gameObject.GetComponent<Player>().SecondaryAttack();
        }





    }
}
