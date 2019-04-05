using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkFood : NetworkBehaviour
{
    //public GameObject crunch;

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            if (coll.gameObject.GetComponent<NetworkedPlayer>().died == false)
            {
                coll.gameObject.GetComponent<NetworkedPlayer>().resources++;
                //Instantiate(crunch);
                gameObject.GetComponent<ObjectTimer>().SetDeactivatedTime();
                //gameObject.SetActive(false);
                Destroy(gameObject);

            }
        }
    }

}
