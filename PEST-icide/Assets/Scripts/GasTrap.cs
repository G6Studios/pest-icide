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
            Rat.instance.SendMessage("takeDamage", 5.0f);
        }

        if (player.tag == "Player2")
        {
            Spider.instance.SendMessage("takeDamage", 5.0f);
        }
        if (player.tag == "Player3")
        {
            Frog.instance.SendMessage("takeDamage", 5.0f);
        }
        if (player.tag == "Player4")
        {
            Snake.instance.SendMessage("takeDamage", 5.0f);
        }

        yield return new WaitForSeconds(0.3f);
    }


    public bool IsActive
    {
        set { isActive = value; }
        get { return isActive; }
    }
}
