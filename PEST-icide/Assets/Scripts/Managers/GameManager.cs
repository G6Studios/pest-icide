using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;
    public GameObject Player4;

    public GameObject GasTrap;
    public GameObject MouseTrap;

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

    private float startTime = 5 * 60; // Sixty seconds times five

	// Use this for initialization
	void Start () {
        TimeRemaining = startTime;
        Player1 = GameObject.FindGameObjectWithTag("Player1");
        Player2 = GameObject.FindGameObjectWithTag("Player2");
        Player3 = GameObject.FindGameObjectWithTag("Player3");
        Player4 = GameObject.FindGameObjectWithTag("Player4");
        
    }
	
	// Update is called once per frame
	void Update () {
        TimeRemaining -= Time.deltaTime;
        Player1Food = Player1.GetComponent<Player>().Resources;
        Player2Food = Player2.GetComponent<Player>().Resources;
        Player3Food = Player3.GetComponent<Player>().Resources;
        Player4Food = Player4.GetComponent<Player>().Resources;

        if(TimeRemaining <= 0.0f)
        {
            GameOver();
        }

        

    }

    // Function that will switch game scenes once the time has run out
    void GameOver()
    {

    }
}
