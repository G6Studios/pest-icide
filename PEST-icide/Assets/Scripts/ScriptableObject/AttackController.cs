using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    // Attack hitbox
    Collider attackHitbox;
    [HideInInspector]
    public bool attackActive;

    // Values read by the UI manager
    [HideInInspector]
    public float cooldownProxy;
    [HideInInspector]
    public float cooldownTimerProxy;

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

                case "Player":
                    Debug.Log("Hit:" + hit.name);
                    hit.GetComponent<Player>().TakeDamage(4.0f);
                    break;

                default:
                    Debug.Log("What the hell did I hit?");
                    break;
            }
        }

    }
}
