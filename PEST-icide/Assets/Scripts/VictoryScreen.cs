using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    }
}
