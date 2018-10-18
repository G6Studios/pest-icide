using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceDeposit : MonoBehaviour {

	
    void OnTriggerEnter(Collider coll)
    {
        StartCoroutine(DrainResource(coll.gameObject));

    }

    void OnTriggerExit(Collider coll)
    {
        StopAllCoroutines();
    }

    IEnumerator DrainResource(GameObject player)
    {
        while (true)
        {
            float food1 = GameManager.publicInstance.Player1Food;
            float food2 = GameManager.publicInstance.Player2Food;
            float food3 = GameManager.publicInstance.Player3Food;
            float food4 = GameManager.publicInstance.Player4Food;

            if(player.tag == "Player1" && food1 > 0)
            {
                GameManager.publicInstance.Player1Food--;
            }
            else if(player.tag == "Player2" && food2 > 0)
            {
                GameManager.publicInstance.Player2Food--;
            }
            else if(player.tag == "Player3" && food3 > 0)
            {
                GameManager.publicInstance.Player3Food--;
            }
            else if(player.tag == "Player4" && food4 > 0)
            {
                GameManager.publicInstance.Player4Food--;
            }

            yield return new WaitForSeconds(0.5f);
        }

    }

}
