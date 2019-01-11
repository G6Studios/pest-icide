using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {

    public static GameManager instance = null;

    // Awake() runs before any Start() calls
    // Enforces the singleton pattern
    private void Awake()
    {
        // Check if instance exists
        if(instance == null)
        {
            // If not, set the game manager to this
            instance = this;
        }

        else if(instance != this)
        {
            Destroy(gameObject);
        }

        // Ensures that this persists between scenes
        DontDestroyOnLoad(gameObject);
    }

    // For internal use
    private float timeRemaining;
    private uint player1Food;
    private uint player2Food;
    private uint player3Food;
    private uint player4Food;

    //The sources the players depositied
    private uint player1DepositedRes;
    private uint player2DepositedRes;
    private uint player3DepositedRes;
    private uint player4DepositedRes;

    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;
    public GameObject Player4;

    public GameObject GasTrap;
    public GameObject MouseTrap;
    public string winner;


    // Quick way to do get and set functions for variables
    public float TimeRemaining
    {
        get { return timeRemaining; }
        set { timeRemaining = value; }
    }

    public uint Player1Food
    {
        get { return player1Food; }
        set { player1Food = value; }
    }

    public uint Player2Food
    {
        get { return player2Food; }
        set { player2Food = value; }
    }

    public uint Player3Food
    {
        get { return player3Food; }
        set { player3Food = value; }
    }

    public uint Player4Food
    {
        get { return player4Food; }
        set { player4Food = value; }
    }

    public uint Player1DepositedRes
    {
        get { return player1DepositedRes;}
     
    }
    public uint Player2DepositedRes
    {
        get { return player2DepositedRes; }

    }
    public uint Player3DepositedRes
    {
        get { return player3DepositedRes; }

    }
    public uint Player4DepositedRes
    {
        get { return player4DepositedRes; }

    }

    private float startTime = 120; // Sixty seconds times five

	// Use this for initialization
	void Start () {
        TimeRemaining = startTime;
        Player1 = GameObject.FindGameObjectWithTag("Player1");
        Player2 = GameObject.FindGameObjectWithTag("Player2");
        Player3 = GameObject.FindGameObjectWithTag("Player3");
        Player4 = GameObject.FindGameObjectWithTag("Player4");
        
    }

    // Update is called once per frame
    void Update() {
        if (Player1 != null) //if the game is actually running and players exist
        {
            TimeRemaining -= Time.deltaTime;
            Player1Food = Player1.GetComponent<Player>().Resources;

            player1DepositedRes = Player1.GetComponent<Player>().depositedResources;

            if (TimeRemaining <= 0.0f)
            {
                GameOver();
            }

        

        }
    }

    // Function that will switch game scenes once the time has run out
    void GameOver()
    {
        if (CheckWinner() != null)
        {
            Debug.Log("Player " + CheckWinner().GetComponent<Player>().playerNumber + "is the winner!");
            winner = CheckWinner().GetComponent<Player>().playerNumber.ToString();
            SceneManager.LoadScene("Victory");
      
            //end our scene 
            //in the next scene we read the data from the game manager and then we display it
            //When we are done displaying the data, we reset it back to default values when they hit play again or we destory everything if they go back to main menu
        }
        else
        {
            Debug.Log("No winner");
            //end our scene
        }

    }

    public GameObject CheckWinner()
    {
        if (player1DepositedRes > player2DepositedRes && player1DepositedRes > player3DepositedRes && player1DepositedRes > player4DepositedRes)
            return Player1;
        else if (player2DepositedRes > player1DepositedRes && player2DepositedRes > player3DepositedRes && player2DepositedRes > player4DepositedRes)
            return Player2;
        else if (player3DepositedRes > player1DepositedRes && player3DepositedRes > player2DepositedRes && player3DepositedRes > player4DepositedRes)
            return Player3;
        else if (player4DepositedRes > player1DepositedRes && player4DepositedRes > player2DepositedRes && player4DepositedRes > player3DepositedRes)
            return Player4;
        else
            return null;
    }
}
