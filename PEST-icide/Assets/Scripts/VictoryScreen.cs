using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class VictoryScreen : MonoBehaviour
{
    public TextMeshProUGUI player1Score;
    public TextMeshProUGUI player2Score;
    public TextMeshProUGUI player3Score;
    public TextMeshProUGUI player4Score;
    public TextMeshProUGUI winnerText;

    // Start is called before the first frame update
    void Start()
    {
        SceneReset();
    }

    // Update is called once per frame
    void Update()
    {
        // Setting player scores
        player1Score.text = GameManager.instance.player1DResource.ToString();
        player2Score.text = GameManager.instance.player2DResource.ToString();
        player3Score.text = GameManager.instance.player3DResource.ToString();
        player4Score.text = GameManager.instance.player4DResource.ToString();

        winnerText.text = "Player " + GameManager.instance.winner;

        if(Input.GetButtonDown("A_P1"))
        {
            SceneManager.LoadScene("CharacterSelect");
            GameManager.instance.player1DResource = 0;
            GameManager.instance.player2DResource = 0;
            GameManager.instance.player3DResource = 0;
            GameManager.instance.player4DResource = 0;
        }

        else if(Input.GetButtonDown("B_P1"))
        {
            SceneManager.LoadScene("Main Menu");
            GameManager.instance.player1DResource = 0;
            GameManager.instance.player2DResource = 0;
            GameManager.instance.player3DResource = 0;
            GameManager.instance.player4DResource = 0;
        }
    }

    // Resetting the main scene for if the players want to play another round
    void SceneReset()
    {
        GameManager.instance.gameSceneInitialized = false;
        GameManager.instance.playerList.Clear();
        GameManager.instance.timer = GameManager.instance.startTime;
        
    }
}
