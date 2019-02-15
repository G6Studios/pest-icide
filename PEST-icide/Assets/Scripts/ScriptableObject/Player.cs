using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Internal variables
    private int resources;
    private float health;
    public float maxHealth;
    public int playerNum;
    public Vector3 spawnPoint;

    void Start()
    {
        health = maxHealth;
        resources = 0;
        spawnPoint = gameObject.transform.position;
        
    }

    void Update()
    {
        
    }

    
    public void TakeDamage(float dmg)
    {
        health -= dmg;
    }

    public void Death()
    { 
        
    }

    public void Respawn()
    {

    }

}
