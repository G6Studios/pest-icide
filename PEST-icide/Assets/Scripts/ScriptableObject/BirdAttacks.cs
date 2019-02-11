using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdAttacks : MonoBehaviour
{
    // Animation
    Animator birdAttacksController;

    // Attack hitbox
    Collider attackHitbox;
    bool attackActive;

    // Initialization
    void Start()
    {
        // Setting up animator
        birdAttacksController = gameObject.GetComponent<Animator>();

        // Setting up collider
        attackHitbox = gameObject.GetComponent<BoxCollider>();

        // Setting the hitbox to start inactive
        attackActive = false;
    }

    private void Update()
    {
        Attack();
    }

    // Trigger attack animation
    public void Attack()
    {
        if(Input.GetButtonDown("X_P1"))
        birdAttacksController.SetTrigger("Attack");

    }

    // Hitbox toggling
    public void ToggleActive()
    {
        attackActive = !attackActive;
    }

    // Resolving hits
    private void OnTriggerEnter(Collider hit)
    {
        if (attackActive)
        {
            string target = hit.gameObject.tag;

            switch (target)
            {
                case "Dummy":
                    Debug.Log("Hit:" + target);
                    break;

                default:
                    Debug.Log("What the hell did I hit?");
                    break;
            }
        }

    }
}
