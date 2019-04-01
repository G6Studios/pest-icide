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

    // Since the collider nows works by OnTriggerStay, this timer is necessary so the player can shred people's health in an instant
    public float dmgCooldown;
    private float dmgTimer;

    public float attackDamage;

    Vector3 offset;

    // Attack sounds
    AudioSource sounds;
    public AudioClip attackHitSound;

    // Initialization
    void Start()
    {
        // Setting up collider
        attackHitbox = gameObject.GetComponent<BoxCollider>();

        // Setting the hitbox to start inactive
        attackActive = false;

        // Setting attack sprite offset
        offset = new Vector3(0f, 1.0f, 0f);

        // Setting sound player
        sounds = gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(dmgTimer < dmgCooldown)
        {
            dmgTimer += 0.01f;
        }
    }

    // Resolving hits
    private void OnTriggerStay(Collider hit)
    {
        if (attackActive && dmgTimer > dmgCooldown)
        {
            string target = hit.gameObject.tag;

            switch (target)
            {
                case "Dummy":
                    Debug.Log("Hit:" + target);
                    break;

                case "Player":
                    dmgTimer = 0.0f;
                    Debug.Log("Hit:" + hit.name);
                    hit.GetComponent<Player>().TakeDamage(attackDamage);
                    GameObject instance = Instantiate(attackSprite, hit.transform.position + offset, Quaternion.identity);
                    sounds.Play();
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
