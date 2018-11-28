using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasTrap : MonoBehaviour {

    private IEnumerator gas;
    private bool isActive;

    private void Start()
    {
        isActive = false;
    }

    private void Update()
    {
        if(isActive)
        {
            gameObject.GetComponent<ParticleSystem>().Play();
        }
        else
        {
            gameObject.GetComponent<ParticleSystem>().Stop();
        }
    }

    private void OnTriggerEnter(Collider coll)
    {
        if(isActive)
        {
            gas = GasHurt(coll.gameObject);
            StartCoroutine(gas);
        }
    }

    private void OnTriggerExit(Collider coll)
    {
        if(isActive)
        {
            StopCoroutine(gas);
        }
    }

    IEnumerator GasHurt(GameObject player)
    {
        if(player.tag == "Player1")
        {
            player.gameObject.GetComponent<Player>().TakeDamage(5);

        }

        if (player.tag == "Player2")
        {
            player.gameObject.GetComponent<Player>().TakeDamage(5);
        }

        if (player.tag == "Player3")
        {
            player.gameObject.GetComponent<Player>().TakeDamage(5);
        }

        if (player.tag == "Player4")
        {
            player.gameObject.GetComponent<Player>().TakeDamage(5);
        }

        yield return new WaitForSeconds(0.3f);
    }


    public bool IsActive
    {
        set { isActive = value; }
        get { return isActive; }
    }
}
