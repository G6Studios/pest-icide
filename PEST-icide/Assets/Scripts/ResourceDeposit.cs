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
            float food1 = GameManager.instance.Player1Food;
            float food2 = GameManager.instance.Player2Food;
            float food3 = GameManager.instance.Player3Food;
            float food4 = GameManager.instance.Player4Food;

            if(player.tag == "Player1" && food1 > 0)
            {
                GameManager.instance.Player1Food--;
            }
            else if(player.tag == "Player2" && food2 > 0)
            {
                GameManager.instance.Player2Food--;
            }
            else if(player.tag == "Player3" && food3 > 0)
            {
                GameManager.instance.Player3Food--;
            }
            else if(player.tag == "Player4" && food4 > 0)
            {
                GameManager.instance.Player4Food--;
            }

            yield return new WaitForSeconds(0.5f);
        }

    }

}
