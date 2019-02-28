using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthOrb : MonoBehaviour, IPowerUp
{
    private void OnTriggerEnter(Collider other)
    {
        // If a player collides with the health orb
        if (other.CompareTag("Player")) 
        {
            PickUp(other);
        }
    }

    // This function is responsible for what happens to the player when they pickup the power up
   public void PickUp(Collider player) 
    {
        // Give the player some HP
        player.GetComponent<Player>().health += 25;
        // Destroy Health Orb
        Destroy(gameObject);
        // If we have a particle effect on pickup
        // Destory that particle system effect here.
    }


}
