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

    // Character slots for convenience
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;

    public TextMeshProUGUI timerText;

    Scene currentScene;

    bool initialized = false;

    private void Start()
    {
        
        //player2 = GameManager.instance.playerList[1];
        //player3 = GameManager.instance.playerList[2];
        //player4 = GameManager.instance.playerList[3];
    }

    void Update()
    {
        currentScene = SceneManager.GetActiveScene();
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

        if(GameManager.instance.timer < 0)
        {
            timerText.text = string.Format("{0:0}:{1:00}", 0, 0);
        }



        // Managing elements for player 1
        if (GameManager.instance.player1Active)
        {
            player1HealthImage.SetActive(true);
            player1HealthNumber.gameObject.SetActive(true);
            player1AttackImage.gameObject.SetActive(true);
            player1Resource.SetActive(true);

            player1HealthFill.fillAmount = player1.GetComponent<Player>().health / player1.GetComponent<Player>().maxHealth;
            player1HealthNumber.text = player1.GetComponent<Player>().health.ToString();
            player1AttackImage.fillAmount = player1.GetComponentInChildren<AttackController>().cooldownTimerProxy / player1.GetComponentInChildren<AttackController>().cooldownProxy;
            player1Resource.GetComponentInChildren<TextMeshProUGUI>().text = player1.GetComponent<Player>().resources.ToString();

        }
        else
        {
            player1HealthImage.SetActive(false);
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

            player2HealthFill.fillAmount = player2.GetComponent<Player>().health / player2.GetComponent<Player>().maxHealth;
            player2HealthNumber.text = player2.GetComponent<Player>().health.ToString();
            player2AttackImage.fillAmount = player2.GetComponentInChildren<AttackController>().cooldownTimerProxy / player2.GetComponentInChildren<AttackController>().cooldownProxy;
            player2Resource.GetComponentInChildren<TextMeshProUGUI>().text = player2.GetComponent<Player>().resources.ToString();
        }
        else
        {
            player2HealthImage.SetActive(false);
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

            player3HealthFill.fillAmount = player3.GetComponent<Player>().health / player3.GetComponent<Player>().maxHealth;
            player3HealthNumber.text = player3.GetComponent<Player>().health.ToString();
            player3AttackImage.fillAmount = player3.GetComponentInChildren<AttackController>().cooldownTimerProxy / player3.GetComponentInChildren<AttackController>().cooldownProxy;
            player3Resource.GetComponentInChildren<TextMeshProUGUI>().text = player3.GetComponent<Player>().resources.ToString();
        }
        else
        {
            player3HealthImage.SetActive(false);
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

            player4HealthFill.fillAmount = player4.GetComponent<Player>().health / player4.GetComponent<Player>().maxHealth;
            player4HealthNumber.text = player4.GetComponent<Player>().health.ToString();
            player4AttackImage.fillAmount = player4.GetComponentInChildren<AttackController>().cooldownTimerProxy / player4.GetComponentInChildren<AttackController>().cooldownProxy;
            player4Resource.GetComponentInChildren<TextMeshProUGUI>().text = player4.GetComponent<Player>().resources.ToString();
        }
        else
        {
            player4HealthImage.SetActive(false);
            player4HealthNumber.gameObject.SetActive(false);
            player4AttackImage.gameObject.SetActive(false);
            player4Resource.SetActive(false);
        }

    }

}
