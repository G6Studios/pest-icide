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
        gameManager = GameObject.Find("Game");
    }

    // Use this for initialization
    void Start () {

        if (playerNumber == 1)
            text.text = "Player " + playerNumber.ToString() + ": " + gameManager.GetComponent<GameManager>().Player1DepositedRes;
        else if (playerNumber == 2)
            text.text = "Player " + playerNumber.ToString() + ": " + gameManager.GetComponent<GameManager>().Player2DepositedRes;
        else if (playerNumber == 3)
            text.text = "Player " + playerNumber.ToString() + ": " + gameManager.GetComponent<GameManager>().Player3DepositedRes;
        else if (playerNumber == 4)
            text.text = "Player " + playerNumber.ToString() + ": " + gameManager.GetComponent<GameManager>().Player4DepositedRes;
        else if (playerNumber == 1337)
        {
            text.text = "Winner: " + "Player " + gameManager.GetComponent<GameManager>().winner;

        }


    }
	

}
