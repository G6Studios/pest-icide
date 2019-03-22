using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    // Attack hitbox
    Collider attackHitbox;
    [HideInInspector]
    public bool attackActive;

    // Attack sprite
    public GameObject attackSprite;

    // Values read by the UI manager
    [HideInInspector]
    public float cooldownProxy;
    [HideInInspector]
    public float cooldownTimerProxy;

    public float attackDamage;

    Vector3 offset;

    // Initialization
    void Start()
    {
        // Setting up collider
        attackHitbox = gameObject.GetComponent<BoxCollider>();

        // Setting the hitbox to start inactive
        attackActive = false;

        // Setting attack sprite offset
        offset = new Vector3(0f, 1.0f, 0f);
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
                    hit.GetComponent<Player>().TakeDamage(attackDamage);
                    GameObject instance = Instantiate(attackSprite, hit.transform.position + offset, Quaternion.identity);
                    attackSprite.GetComponent<ParticleSystem>().Play();
                    Destroy(instance, 1.0f);
                    break;

                default:
                    Debug.Log("What the hell did I hit?");
                    break;
            }
        }

    }
}
