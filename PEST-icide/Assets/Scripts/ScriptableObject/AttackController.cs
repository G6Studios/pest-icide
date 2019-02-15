using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    // Attack hitbox
    Collider attackHitbox;
    [HideInInspector]
    public bool attackActive;

    // Initialization
    void Start()
    {
        // Setting up collider
        attackHitbox = gameObject.GetComponent<BoxCollider>();

        // Setting the hitbox to start inactive
        attackActive = false;
    }

    private void Update()
    {

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
