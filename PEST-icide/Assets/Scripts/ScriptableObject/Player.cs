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

    void Start()
    {
        health = maxHealth;
        resources = 0;
        spawnPoint = gameObject.transform.position;
        died = false;
        leader = false;

        SetIndicator();

        sounds = gameObject.GetComponent<AudioSource>();
        
    }

    void Update()
    {
        if (health <= 0.0f && died == false)
        {
            Death();
            died = true;
            DropResources();
        }

        HurtSelf();

        GiveBarrels();

        UpdateIndicator();

        

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
    
    public void TakeDamage(float dmg)
    {
        health -= dmg;
    }

    public void Death()
    {
        sounds.clip = death;
        sounds.Play();
        Invoke("Respawn", 5.0f);
        GetComponentInParent<Animator>().SetBool("Dead", true);

    }

    public void Respawn()
    {
        GetComponentInParent<Animator>().SetBool("Dead", false);
        health = maxHealth;
        gameObject.transform.position = spawnPoint;
        died = false;
    }

    public void DropResources()
    {
        for(int i = 0; i < resources; i++)
        {
            Vector3 center = transform.position + new Vector3(0f, 3f, 0f);
            Vector3 spawnPos = RandomCircle(center, 3f);
            GameObject temp = Instantiate(foodPrefab, spawnPos, Quaternion.FromToRotation(Vector3.forward, center - spawnPos));
            Destroy(temp, 3f);
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
