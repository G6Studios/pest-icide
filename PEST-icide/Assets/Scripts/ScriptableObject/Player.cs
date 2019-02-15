using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Internal variables
    private int resources;
    public float health;
    public float maxHealth;
    public int playerNum;
    private bool died;
    public Vector3 spawnPoint;

    void Start()
    {
        health = maxHealth;
        resources = 0;
        spawnPoint = gameObject.transform.position;
        died = false;
        
    }

    void Update()
    {
        if (health < 0.0f && died == false)
        {
            Death();
            died = true;
        }

    }

    
    public void TakeDamage(float dmg)
    {
        health -= dmg;
    }

    public void Death()
    {
        Invoke("Respawn", 5.0f);
    }

    public void Respawn()
    {
        health = maxHealth;
        gameObject.transform.position = spawnPoint;
        died = false;
    }

}
