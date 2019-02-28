using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This event modifies the players stats

public class StatEvent : MonoBehaviour
{
    private GameObject player1, player2, player3, player4;
    public float speedMod = 2.0f;
    public bool active = false;


    // Start is called before the first frame update
    void Start()
    {
        if(GameManager.instance.player1Active)
        {
            player1 = GameManager.instance.Player1;
        }

        if(GameManager.instance.player2Active)
        {
            player2 = GameManager.instance.Player2;
        }
        
        if(GameManager.instance.player3Active)
        {
            player3 = GameManager.instance.Player3;
        }
        
        if(GameManager.instance.player4Active)
        {
            player4 = GameManager.instance.Player4;
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        if (!active)
        {
            if (Input.GetKeyDown("h"))
                Activate();
        }
        else if (active)
        {
            if (Input.GetKeyDown("h"))
                Deactivate();
        }

    }


    void Activate()
    {
        active = true;
        if(player1 != null)
            player1.GetComponent<Player>().speed *= speedMod;
        if (player2 != null)
            player2.GetComponent<Player>().speed *= speedMod;
        if (player3 != null)
            player3.GetComponent<Player>().speed *= speedMod;
        if (player4 != null)
            player4.GetComponent<Player>().speed *= speedMod;
    }

    void Deactivate()
    {
        active = false;
        if (player1 != null)
            player1.GetComponent<Player>().speed /= speedMod;
        if (player2 != null)
            player2.GetComponent<Player>().speed /= speedMod;
        if (player3 != null)
            player3.GetComponent<Player>().speed /= speedMod;
        if (player4 != null)
            player4.GetComponent<Player>().speed /= speedMod;
    }


}

