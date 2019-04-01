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

    public GameObject menu;
    public GameObject progressBar;
    public GameObject tutorialScreen;
    public GameObject controlScreen;
    public GameObject prompt;

    private float timer;
    private bool timerActive;
    private bool triggerOnce;

    private float infoTimer;

    // Used for loading scene asynchronously
    AsyncOperation loading;

    bool allReady;

    // Start is called before the first frame update
    void Start()
    {
        timerText = timerObject.GetComponent<TextMeshProUGUI>();
        allReady = false;
        timer = 5.0f;
        menu.SetActive(true);
        progressBar.SetActive(false);
        tutorialScreen.SetActive(false);
        controlScreen.SetActive(false);
        prompt.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        // Checking if each player is ready
        ReadyStatus();
        ReadyTimer();
        //if(player1.selected && player2.selected && player3.selected && player4.selected)
        if(player1.selected)
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

        if(progressBar.activeInHierarchy)
        {
            infoTimer+=0.1f;
            if(infoTimer > 50f)
            {
                ChangeScreens();
                infoTimer = 0.0f;
            }
            prompt.SetActive(true);
            if(Input.GetButtonDown("A_P1") || Input.GetButtonDown("A_P2") || Input.GetButtonDown("A_P3") || Input.GetButtonDown("A_P4"))
            {
                loading.allowSceneActivation = true;
            }
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
            timer = 0.0f;
            GameManager.instance.charSelections[0] = player1.characterNum;
            GameManager.instance.charSelections[1] = player2.characterNum;
            GameManager.instance.charSelections[2] = player3.characterNum;
            GameManager.instance.charSelections[3] = player4.characterNum;
            StartCoroutine(LoadLevel(4)); // Since LoadSceneAsync returns an AsyncOption coroutine, we must use a coroutine to track loading progress
        }

        if(timer <= 0.0f)
        {
            timerText.text = "0.00";
        }
    }

    // Coroutine for LoadSceneAsync
    IEnumerator LoadLevel(int index) 
    {
        loading = SceneManager.LoadSceneAsync(index);

        loading.allowSceneActivation = false;

        menu.SetActive(false);
        progressBar.SetActive(true);
        tutorialScreen.SetActive(true);

        while(!loading.isDone)
        {
            float progress = Mathf.Clamp01(loading.progress / .9f);

            progressBar.GetComponent<Slider>().value = progress;

            yield return null;
        }

    }

    // Switching between information screens
    void ChangeScreens()
    {
        if(tutorialScreen.activeInHierarchy && !controlScreen.activeInHierarchy)
        {
            tutorialScreen.SetActive(false);
            controlScreen.SetActive(true);
        }
        else if(!tutorialScreen.activeInHierarchy && controlScreen.activeInHierarchy)
        {
            tutorialScreen.SetActive(true);
            controlScreen.SetActive(false);
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
