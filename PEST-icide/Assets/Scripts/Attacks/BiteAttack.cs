using UnityEngine;
using UnityEngine.Events;

public class BiteAttack : MonoBehaviour
{

    private void Start()
    {
        gameObject.GetComponent<ParticleSystem>().Play();
    }

    private void OnTriggerEnter(Collider hit)
    {
        if (hit.gameObject.tag == "Player1")
        {
            hit.gameObject.GetComponent<Player>().TakeDamage(2);
        }
        else if (hit.gameObject.tag == "Player2")
        {
            hit.gameObject.GetComponent<Player>().TakeDamage(2);
            Debug.Log("Player2 hit!");
        }
        else if (hit.gameObject.tag == "Player3")
        {
            hit.gameObject.GetComponent<Player>().TakeDamage(2);
            Debug.Log("Player3 hit!");

        }
        else if (hit.gameObject.tag == "Player4")
        {
            hit.gameObject.GetComponent<Player>().TakeDamage(2);
            Debug.Log("Player4 hit!");
        }

    }
}
