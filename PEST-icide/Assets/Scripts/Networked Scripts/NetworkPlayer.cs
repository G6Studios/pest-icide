﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkPlayer : NetworkBehaviour
{
    // Internal variables
    public float speed;
    public GameObject foodPrefab;
    [SyncVar]
    public int resources;
    [SyncVar]
    public float health;
    public float maxHealth;
    public int playerNum;
    public bool died;
    public Vector3 spawnPoint;
    public GameObject playerIndicator;
    public Material p1Indicator;
    public Material p2Indicator;
    public Material p3Indicator;
    public Material p4Indicator;

    private int connectionId;
 

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        resources = 0;
        spawnPoint = gameObject.transform.position;
        Debug.Log(gameObject.GetComponent<NetworkIdentity>().connectionToClient);
        connectionId = gameObject.GetComponent<NetworkIdentity>().connectionToClient.connectionId;
        died = false;
        SetIndicator();
    }


    // Update is called once per frame
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
    }

    // Debugging command
    void HurtSelf()
    {
        if (Input.GetButtonDown("Y_P" + playerNum))
        {
            TakeDamage(1);
        }
    }

    // Debugging command
    void GiveBarrels()
    {
        if (Input.GetButtonDown("B_P" + playerNum))
        {
            resources += 5;
        }
    }

    // Setting player indicator
    void SetIndicator()
    {
        if (connectionId == 0)
        {
            playerIndicator.GetComponent<Renderer>().material = p1Indicator;
        }
        else if (connectionId == 1)
        {
            playerIndicator.GetComponent<Renderer>().material = p2Indicator;
        }
        else if (connectionId == 2)
        {
            playerIndicator.GetComponent<Renderer>().material = p3Indicator;
        }
        else if (connectionId == 3)
        {
            playerIndicator.GetComponent<Renderer>().material = p4Indicator;
        }
    }

    public void TakeDamage(float dmg)
    {
        if (!isServer)
            return;
        health -= dmg;
    }


    public void Death()
    {
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
        for (int i = 0; i < resources; i++)
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