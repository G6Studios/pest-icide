using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceDeposit : MonoBehaviour
{

    private IEnumerator coroutine;

    void OnTriggerEnter(Collider coll)
    {
        // Starting coroutine for draining players resources
        coroutine = DrainResource(coll.gameObject);
        Coroutine co = StartCoroutine(coroutine);
        
    }

    void OnTriggerExit(Collider coll)
    {
        StopAllCoroutines();
    }


    IEnumerator DrainResource(GameObject player)
    {
        while (true)
        {
            // If a player is stepping on the pad
            if (player.CompareTag("Player"))
            {
                if (player.GetComponent<Player>().resources > 0)
                {
                    // Takes 1 resource per second from personal store
                    player.GetComponent<Player>().resources--;
                    int tempNum = player.GetComponent<Player>().playerNum;

                    if (tempNum == 1)
                    {
                        GameManager.instance.player1DResource++;
                    }

                    else if (tempNum == 2)
                    {
                        GameManager.instance.player2DResource++;
                    }

                    else if (tempNum == 3)
                    {
                        GameManager.instance.player3DResource++;
                    }

                    else if (tempNum == 4)
                    {
                        GameManager.instance.player4DResource++;
                    }
                }
            }

            yield return new WaitForSeconds(1.0f);
        }
    }


}
