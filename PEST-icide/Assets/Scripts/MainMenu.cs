using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void startGame()
    {
        SceneManager.LoadScene("CharacterSelect");
    }

    public void viewCinematic()
    {
        SceneManager.LoadScene("Cinematic");
    }

    public void exitGame()
    {
        Debug.Log("Exit Game");
        Application.Quit();
    }

}
