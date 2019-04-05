using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;
using UnityEngine.SceneManagement;
using TMPro;

public class UIManager : MonoBehaviour
{
    // Health pools
    public GameObject player1HealthImage;
    public GameObject player2HealthImage;
    public GameObject player3HealthImage;
    public GameObject player4HealthImage;

    // Health pool fills
    public Image player1HealthFill;
    public Image player2HealthFill;
    public Image player3HealthFill;
    public Image player4HealthFill;

    // Health pool numbers
    public TextMeshProUGUI player1HealthNumber;
    public TextMeshProUGUI player2HealthNumber;
    public TextMeshProUGUI player3HealthNumber;
    public TextMeshProUGUI player4HealthNumber;

    // Resource numbers
    public GameObject player1Resource;
    public GameObject player2Resource;
    public GameObject player3Resource;
    public GameObject player4Resource;

    // Attack cooldown indicators
    public Image player1AttackImage;
    public Image player2AttackImage;
    public Image player3AttackImage;
    public Image player4AttackImage;

    // HUD damage indicator
    public Image player1Hurt;
    public Image player2Hurt;
    public Image player3Hurt;
    public Image player4Hurt;

    // Death indicators
    public GameObject player1Dead;
    public GameObject player2Dead;
    public GameObject player3Dead;
    public GameObject player4Dead;

    // Sudden death text
    public GameObject suddenDeath;

    // Health percent holding variable
    float player1HealthPercent;
    float player2HealthPercent;
    float player3HealthPercent;
    float player4HealthPercent;

    // Character slots for convenience
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;

    public TextMeshProUGUI timerText; // Game timer element

    Scene currentScene; // To store the current scene

    bool initialized = false;

    private void Start()
    {
        
    }

    void Update()
    {
        currentScene = SceneManager.GetActiveScene();
        // Checking for if players are active
        if(currentScene.name == "Main Quinn Version" && initialized == false)
        {
            if(GameManager.instance.player1Active)
            {
                player1 = GameManager.instance.playerList[0];
            }   

            if (GameManager.instance.player2Active)
            {
                player2 = GameManager.instance.playerList[1];
            }
                
            if (GameManager.instance.player3Active)
            {
                player3 = GameManager.instance.playerList[2];
            }
                
            if (GameManager.instance.player4Active)
            {
                player4 = GameManager.instance.playerList[3];
            }
                
            
            initialized = true;
        }

        // Updating timer
        int minutes = Mathf.FloorToInt(GameManager.instance.timer / 60F);
        int seconds = Mathf.FloorToInt(GameManager.instance.timer - minutes * 60);
        string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);
        timerText.text = niceTime;

        // Formatting timer to 00:00
        if(GameManager.instance.timer < 0)
        {
            timerText.text = string.Format("{0:0}:{1:00}", 0, 0);
        }

        if(GameManager.instance.suddenDeath == true)
        {
            suddenDeath.SetActive(true);
        }
        else
        {
            suddenDeath.SetActive(false);
        }

        // Managing elements for player 1
        if (GameManager.instance.player1Active)
        {
            player1HealthImage.SetActive(true); // Image for displaying health
            player1HealthNumber.gameObject.SetActive(true); // Number for displaying health
            player1AttackImage.gameObject.SetActive(true); // Attack cooldown image
            player1Resource.SetActive(true); // Resource counter image

            // Retrieving quantities for elements from player script
            player1HealthPercent = player1.GetComponent<Player>().health / player1.GetComponent<Player>().maxHealth;
            player1HealthFill.fillAmount = player1HealthPercent;
            Color tempColor = player1Hurt.color;
            if(player1HealthPercent > 0.50f)
            {
                tempColor.a = 0f;
            }
            else if (player1HealthPercent > 0.30f)
            {
                tempColor.a = 0.2f;
            }
            else if(player1HealthPercent < 0.30f)
            {
                tempColor.a = 0.5f;
            }
            player1Hurt.color = tempColor;
            player1HealthNumber.text = player1.GetComponent<Player>().health.ToString();
            player1AttackImage.fillAmount = player1.GetComponentInChildren<AttackController>().cooldownTimerProxy / player1.GetComponentInChildren<AttackController>().cooldownProxy;
            player1Resource.GetComponentInChildren<TextMeshProUGUI>().text = player1.GetComponent<Player>().resources.ToString();
            if(player1HealthPercent <= 0)
            {
                player1Dead.SetActive(true);
            }
            else
            {
                player1Dead.SetActive(false);
            }

        }
        else
        {
            player1HealthImage.SetActive(false);
            player1Hurt.gameObject.SetActive(false);
            player1HealthNumber.gameObject.SetActive(false);
            player1AttackImage.gameObject.SetActive(false);
            player1Resource.SetActive(false);
        }

        // Managing elements for player 2
        if(GameManager.instance.player2Active)
        {
            player2HealthImage.SetActive(true);
            player2HealthNumber.gameObject.SetActive(true);
            player2AttackImage.gameObject.SetActive(true);
            player2Resource.SetActive(true);

            player2HealthPercent = player2.GetComponent<Player>().health / player2.GetComponent<Player>().maxHealth;
            player2HealthFill.fillAmount = player2HealthPercent;
            Color tempColor = player2Hurt.color;
            if(player2HealthPercent <= 0.50f)
            {
                tempColor.a = 0.2f;
            }
            else if (player2HealthPercent <= 0.30f)
            {
                tempColor.a = 0.5f;
            }
            else
            {
                tempColor.a = 0f;
            }

            
            player2Hurt.color = tempColor;
            player2HealthNumber.text = player2.GetComponent<Player>().health.ToString();
            player2AttackImage.fillAmount = player2.GetComponentInChildren<AttackController>().cooldownTimerProxy / player2.GetComponentInChildren<AttackController>().cooldownProxy;
            player2Resource.GetComponentInChildren<TextMeshProUGUI>().text = player2.GetComponent<Player>().resources.ToString();
            if (player2HealthPercent <= 0)
            {
                player2Dead.SetActive(true);
            }
            else
            {
                player2Dead.SetActive(false);
            }
        }
        else
        {
            player2HealthImage.SetActive(false);
            player2Hurt.gameObject.SetActive(false);
            player2HealthNumber.gameObject.SetActive(false);
            player2AttackImage.gameObject.SetActive(false);
            player2Resource.SetActive(false);
        }

        // Managing elements for player 3
        if(GameManager.instance.player3Active)
        {
            player3HealthImage.SetActive(true);
            player3HealthNumber.gameObject.SetActive(true);
            player3AttackImage.gameObject.SetActive(true);
            player3Resource.SetActive(true);


            player3HealthPercent = player3.GetComponent<Player>().health / player3.GetComponent<Player>().maxHealth;
            player3HealthFill.fillAmount = player3HealthPercent;
            Color tempColor = player3Hurt.color;
            if(player3HealthPercent <= 0.50f)
            {
                tempColor.a = 0.2f;
            }
            else if (player3HealthPercent <= 0.30f)
            {
                tempColor.a = 0.5f;
            }
            else
            {
                tempColor.a = 0f;
            }
            player3Hurt.color = tempColor;
            player3HealthNumber.text = player3.GetComponent<Player>().health.ToString();
            player3AttackImage.fillAmount = player3.GetComponentInChildren<AttackController>().cooldownTimerProxy / player3.GetComponentInChildren<AttackController>().cooldownProxy;
            player3Resource.GetComponentInChildren<TextMeshProUGUI>().text = player3.GetComponent<Player>().resources.ToString();
            if (player3HealthPercent <= 0)
            {
                player3Dead.SetActive(true);
            }
            else
            {
                player3Dead.SetActive(false);
            }
        }
        else
        {
            player3HealthImage.SetActive(false);
            player3Hurt.gameObject.SetActive(false);
            player3HealthNumber.gameObject.SetActive(false);
            player3AttackImage.gameObject.SetActive(false);
            player3Resource.SetActive(false);
        }

        // Managing elements for player 4
        if(GameManager.instance.player4Active)
        {
            player4HealthImage.SetActive(true);
            player4HealthNumber.gameObject.SetActive(true);
            player4AttackImage.gameObject.SetActive(true);
            player4Resource.SetActive(true);

            player4HealthPercent = player4.GetComponent<Player>().health / player4.GetComponent<Player>().maxHealth;
            player4HealthFill.fillAmount = player4HealthPercent;
            Color tempColor = player4Hurt.color;
            if(player4HealthPercent <= 0.50f)
            {
                tempColor.a = 0.2f;
            }
            else if(player4HealthPercent <= 0.30f)
            {
                tempColor.a = 0.5f;
            }
            else
            {
                tempColor.a = 0f;
            }
            player4Hurt.color = tempColor;
            player4HealthNumber.text = player4.GetComponent<Player>().health.ToString();
            player4AttackImage.fillAmount = player4.GetComponentInChildren<AttackController>().cooldownTimerProxy / player4.GetComponentInChildren<AttackController>().cooldownProxy;
            player4Resource.GetComponentInChildren<TextMeshProUGUI>().text = player4.GetComponent<Player>().resources.ToString();
            if (player4HealthPercent <= 0)
            {
                player4Dead.SetActive(true);
            }
            else
            {
                player4Dead.SetActive(false);
            }
        }
        else
        {
            player4HealthImage.SetActive(false);
            player4Hurt.gameObject.SetActive(false);
            player4HealthNumber.gameObject.SetActive(false);
            player4AttackImage.gameObject.SetActive(false);
            player4Resource.SetActive(false);
        }

    }

}
