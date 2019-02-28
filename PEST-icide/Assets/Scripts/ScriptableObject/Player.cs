using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Internal variables
    [SerializeField]
    public float speed;
    public int resources;
    public float health;
    public float maxHealth;
    public int playerNum;
    public bool died;
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
        if (health <= 0.0f && died == false)
        {
            Death();
            died = true;
        }

        HurtSelf();

    }

    // Debugging command
    void HurtSelf()
    {
        if(Input.GetButtonDown("Y_P" + playerNum))
        {
            TakeDamage(1);
        }
    }
    
    public void TakeDamage(float dmg)
    {
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

}
