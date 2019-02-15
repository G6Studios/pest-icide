using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class CheckReady : MonoBehaviour
{
    string[] controllers;

    public CharDisplay player1;
    public CharDisplay player2;
    public CharDisplay player3;
    public CharDisplay player4;

    public GameObject player1Ready;
    public GameObject player2Ready;
    public GameObject player3Ready;
    public GameObject player4Ready;

    public GameObject timerObject;
    TextMeshProUGUI timerText;

    private float timer;
    private bool timerActive;
    private bool triggerOnce;

    bool allReady;

    // Start is called before the first frame update
    void Start()
    {
        timerText = timerObject.GetComponent<TextMeshProUGUI>();
        allReady = false;
        timer = 5.0f;
        controllers = Input.GetJoystickNames();
       for(int i = 0; i < controllers.Length; i++)
        {
            Debug.Log(controllers[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Checking if each player is ready
        ReadyStatus();
        ReadyTimer();
        if(player1.selected && player2.selected && player3.selected && player4.selected)
        {
            timerObject.SetActive(true);
            timerActive = true;
        }
        else
        {
            timer = 5.0f;
            timerText.text = timer.ToString("F");
            timerObject.SetActive(false);
        }
    }

    void ReadyTimer()
    {
        // Checking if the timer is greater than 0 and should be counting
        if(timer > 0.0f && timerActive)
        {
            timer -= Time.deltaTime;
            timerText.text = timer.ToString("F");
        }

        // Making sure the timer doesn't count below 0, and fixing it if it does
        else if(timer <= 0.0f && !triggerOnce)
        {
            timerActive = false;
            triggerOnce = true;
            timerText.text = "0.00";
            timer = 0.0f;
            SceneManager.LoadScene("Main Quinn Version");
        }
    }

    void ReadyStatus()
    {
        // Checking to see if the players have selected a character and setting their ready status
        if(player1.selected == true)
        {
            player1Ready.SetActive(true);
        }

        else
        {
            player1Ready.SetActive(false);
        }


        if (player2.selected == true)
        {
            player2Ready.SetActive(true);
        }

        else
        {
            player2Ready.SetActive(false);
        }


        if (player3.selected == true)
        {
            player3Ready.SetActive(true);
        }

        else
        {
            player3Ready.SetActive(false);
        }


        if (player4.selected == true)
        {
            player4Ready.SetActive(true);
        }

        else
        {
            player4Ready.SetActive(false);
        }
    }
}
