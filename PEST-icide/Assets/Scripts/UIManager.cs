using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public static UIManager instance = null;

    // Awake() runs before any Start() calls
    // Enforces the singleton pattern
    private void Awake()
    {
        // Check if instance exists
        if (instance == null)
        {
            // If not, set the game manager to this
            instance = this;
        }

        else if (instance != this)
        {
            Destroy(gameObject);
        }

        // Ensures that this persists between scenes
        DontDestroyOnLoad(gameObject);
    }

    // SerializeField allows private/protected variables to show up in the inspector
    [SerializeField]
    private Text timeText;

    [SerializeField]
    private Text foodText1;

    [SerializeField]
    private Text foodText2;

    [SerializeField]
    private Text foodText3;

    [SerializeField]
    private Text foodText4;


    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        timeText.text = formatText(GameManager.instance.TimeRemaining);
        foodText1.text = GameManager.instance.Player1Food.ToString();
        foodText2.text = GameManager.instance.Player2Food.ToString();
        foodText3.text = GameManager.instance.Player3Food.ToString();
        foodText4.text = GameManager.instance.Player4Food.ToString();
    }

    private string formatText(float time)
    {
        // Uses string.Format to display the time as minutes and seconds with a colon in the middle
        return string.Format("{0}:{1:00}", ((int)time / 60), ((int)time % 60));
    }

}
