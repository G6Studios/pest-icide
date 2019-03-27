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
            if (coll.gameObject.GetComponent<NetworkPlayer>().died == false)
            {
                coll.gameObject.GetComponent<NetworkPlayer>().resources++;
                //Instantiate(crunch);
                gameObject.SetActive(false);
                gameObject.GetComponent<ObjectTimer>().SetDeactivatedTime();

            }
        }
    }

}
