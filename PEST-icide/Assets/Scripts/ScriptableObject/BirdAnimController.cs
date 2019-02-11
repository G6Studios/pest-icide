using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdAnimController : MonoBehaviour {

    private Animator birdAnimator;

    private Vector3 movementVector;

    private float speed = 10;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 3.0f;

    // Use this for initialization
    void Start () {
        birdAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        float xVel = Input.GetAxis("LeftJoystickX_P1") * 5;
        float yVel = Input.GetAxis("LeftJoystickY_P1") * 5;

        birdAnimator.SetFloat("Horizontal_V", xVel);
        birdAnimator.SetFloat("Vertical_V", yVel);

        if(Input.GetButtonDown("X_P1"))
        {
            birdAnimator.SetTrigger("Attack");
        }

        movementVector.x = Input.GetAxis("LeftJoystickX_P1");
        movementVector.z = Input.GetAxis("LeftJoystickY_P1");

        // Updating the movement vector by multiplying the normalized vector by its speed vector and delta time
        movementVector = movementVector * speed * Time.deltaTime;

        // Translating the attached gameobject by the above movementvector
        transform.Translate(movementVector.x, 0, movementVector.z);

    }

}
