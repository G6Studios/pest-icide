using UnityEngine;
using UnityEngine.Events;
using System.Runtime.InteropServices;

public class ScratchAttack : MonoBehaviour
{


    private void Start()
    {
        gameObject.GetComponent<ParticleSystem>().Play();
    }

    private void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "Player1")
        {
            hit.gameObject.GetComponent<Player>().TakeDamage(1);
            Debug.Log("Player1 hit!");
        }
        else if (hit.gameObject.tag == "Player2")
        {
            hit.gameObject.GetComponent<Player>().TakeDamage(1);
            Debug.Log("Player2 hit!");

        }
        else if (hit.gameObject.tag == "Player3")
        {
            hit.gameObject.GetComponent<Player>().TakeDamage(1);
            Debug.Log("Player3 hit!");

        }
        else if (hit.gameObject.tag == "Player4")
        {
            hit.gameObject.GetComponent<Player>().TakeDamage(1);
            Debug.Log("Player4 hit!");

        }

    }

}
