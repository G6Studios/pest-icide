using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceDeposit : MonoBehaviour {

    private IEnumerator coroutine;
	
    void OnTriggerEnter(Collider coll)
    {
        coroutine = DrainResource(coll.gameObject);
        StartCoroutine(coroutine);

    }

    void OnTriggerExit(Collider coll)
    {
        StopCoroutine(coroutine);
    }

    IEnumerator DrainResource(GameObject player)
    {
        while (true)
        {

            if(player.tag == "Player1" && player.GetComponent<Player>().resources > 0)
            {
                player.GetComponent<Player>().resources--;
            }
            else if(player.tag == "Player2" && player.GetComponent<Player>().resources > 0)
            {
                player.GetComponent<Player>().resources--;
            }
            else if(player.tag == "Player3" && player.GetComponent<Player>().resources > 0)
            {
                player.GetComponent<Player>().resources--;
            }
            else if(player.tag == "Player4" && player.GetComponent<Player>().resources > 0)
            {
                player.GetComponent<Player>().resources--;
            }

            yield return new WaitForSeconds(0.5f);
        }

    }

}
