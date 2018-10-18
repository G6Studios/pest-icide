using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager> {

    // For internal use
    private float timeRemaining;
    private float player1Food;
    private float player2Food;
    private float player3Food;
    private float player4Food;

    // Quick way to do get and set functions for variables
    public float TimeRemaining
    {
        get { return timeRemaining; }
        set { timeRemaining = value; }
    }

    public float Player1Food
    {
        get { return player1Food; }
        set { player1Food = value; }
    }

    public float Player2Food
    {
        get { return player2Food; }
        set { player2Food = value; }
    }

    public float Player3Food
    {
        get { return player3Food; }
        set { player3Food = value; }
    }

    public float Player4Food
    {
        get { return player4Food; }
        set { player4Food = value; }
    }



    private float startTime = 5 * 60; // Sixty seconds times five

	// Use this for initialization
	void Start () {
        TimeRemaining = startTime;
	}
	
	// Update is called once per frame
	void Update () {
        TimeRemaining -= Time.deltaTime;
	}
}
