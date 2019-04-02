using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Internal variables
    public float speed;
    public GameObject foodPrefab;
    public int resources;
    public int depositedResources;
    public float health;
    public float maxHealth;
    public int playerNum;
    public bool died;
    public Vector3 spawnPoint;
    public GameObject playerIndicator;
    private Material setIndicator;
    private Material setLeaderIndicator;
    public Material p1Indicator;
    public Material p2Indicator;
    public Material p3Indicator;
    public Material p4Indicator;
    public Material p1LeaderIndicator;
    public Material p2LeaderIndicator;
    public Material p3LeaderIndicator;
    public Material p4LeaderIndicator;
    public AudioClip death;
    public bool leader;
    private AudioSource sounds;

    [SerializeField]
    private GameObject depositSound;

    void Start()
    {
        health = maxHealth; // Setting health to full
        resources = 0; // Making sure everyone starts with 0 resources
        spawnPoint = gameObject.transform.position; // Setting their initial spawn position as where they will respawn
        died = false; // Don't want players spawning in dead
        leader = false; // Everyone starts equal

        SetIndicator(); // Setting player indicators initially

        sounds = gameObject.GetComponent<AudioSource>();
        
    }

    void Update()
    {
        // Checking if the player's health drops below 0
        if (health <= 0.0f && died == false)
        {
            Death();
            died = true;
            DropResources();
        }

        //HurtSelf();

        //GiveBarrels();

        UpdateIndicator(); // Updating the player's indicator if they become the leader

        

    }

    // Debugging command
    void HurtSelf()
    {
        if(Input.GetButtonDown("Y_P" + playerNum))
        {
            TakeDamage(1);
        }
    }

    // Debugging command
    void GiveBarrels()
    {
        if(Input.GetButtonDown("B_P" + playerNum))
        {
            resources += 5;
        }
    }

    // Setting leader icon
    void UpdateIndicator()
    {
        if(leader == true)
        {
            playerIndicator.GetComponent<Renderer>().material = setLeaderIndicator;
        }
        else
        {
            playerIndicator.GetComponent<Renderer>().material = setIndicator;
        }
    }

    // Deposit sound playing
    public void DepositSound()
    {
        depositSound.GetComponent<AudioSource>().Play();
    }

    // Setting player indicator
    void SetIndicator()
    {
        if(playerNum == 1)
        {
            setIndicator = p1Indicator;
            setLeaderIndicator = p1LeaderIndicator;
        }
        else if (playerNum == 2)
        {
            setIndicator = p2Indicator;
            setLeaderIndicator = p2LeaderIndicator;
        }
        else if (playerNum == 3)
        {
            setIndicator = p3Indicator;
            setLeaderIndicator = p3LeaderIndicator;
        }
        else if (playerNum == 4)
        {
            setIndicator = p4Indicator;
            setLeaderIndicator = p4LeaderIndicator;
        }
    }
    
    // Called when an attack connects with a player
    public void TakeDamage(float dmg)
    {
        health -= dmg;
    }

    // Called when the player's health drops to 0
    public void Death()
    {
        sounds.clip = death;
        sounds.Play();
        gameObject.GetComponent<Rigidbody>().freezeRotation = true; // Stops players from spinning when they die
        Invoke("Respawn", 5.0f); // Player set to respawn 5 seconds later
        GetComponentInParent<Animator>().SetBool("Dead", true); // Tells animation controller to play death animation

    }

    // Invoked from death after respawn timer
    public void Respawn()
    {
        GetComponentInParent<Animator>().SetBool("Dead", false);
        gameObject.GetComponent<Rigidbody>().freezeRotation = false; // Unfreeze rigidbody rotation
        health = maxHealth; // Refill the player's health
        gameObject.transform.position = spawnPoint; // Set the player back to their initial spawnpoint
        died = false;
    }

    public void DropResources()
    {
        // With the help of another function, causes player's resources to drop around them randomly, disappearing after 5 seconds
        for(int i = 0; i < resources; i++)
        {
            Vector3 center = transform.position + new Vector3(0f, 3f, 0f);
            Vector3 spawnPos = RandomCircle(center, 3f);
            GameObject temp = Instantiate(foodPrefab, spawnPos, Quaternion.FromToRotation(Vector3.forward, center - spawnPos));
            Destroy(temp, 5f);
        }
        resources = 0;
    }

    // Code from stackexchange to spawn objects randomly in a circle around the player
    Vector3 RandomCircle(Vector3 center, float radius)
    {
        // Value will be randomized each time the for loop executes
        float ang = Random.value * 360;
        Vector3 pos;
        // X and Z positions are set to the radius multiplied by the sin or cos of the randomized angle
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y;
        pos.z = center.z + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        return pos;
    }

}
