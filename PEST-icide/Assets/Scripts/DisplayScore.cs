using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour {

    Text text;
    public int playerNumber;
    GameObject gameManager;



    private void Awake()
    {
        text = GetComponent<Text>();
    }

    // Use this for initialization
    void Start () {

        if (playerNumber == 1)
            text.text = "Player " + playerNumber.ToString() + ": " + GameManager.instance.player1DResource;
        else if (playerNumber == 2)
            text.text = "Player " + playerNumber.ToString() + ": " + GameManager.instance.player2DResource;
        else if (playerNumber == 3)
            text.text = "Player " + playerNumber.ToString() + ": " + GameManager.instance.player3DResource;
        else if (playerNumber == 4)
            text.text = "Player " + playerNumber.ToString() + ": " + GameManager.instance.player4DResource;
        else if (playerNumber == 1337)
        {
            text.text = "Winner: " + "Player " + gameManager.GetComponent<GameManager>().winner;
        
        }


    }
	

}
