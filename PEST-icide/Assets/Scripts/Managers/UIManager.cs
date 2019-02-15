using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

public class UIManager : MonoBehaviour
{
    public Image player1HealthImage;
    public Image player2HealthImage;
    public Image player3HealthImage;
    public Image player4HealthImage;

    private float player1Health;
    private float player2Health;
    private float player3Health;
    private float player4Health;

    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;

    //public static UIManager instance = null;
    //
    //// Awake() runs before any Start() calls
    //// Enforces the singleton pattern
    //private void Awake()
    //{
    //    // Check if instance exists
    //    if (instance == null)
    //    {
    //        // If not, set the game manager to this
    //        instance = this;
    //    }
    //
    //    else if (instance != this)
    //    {
    //        Destroy(gameObject);
    //    }
    //
    //    // Ensures that this persists between scenes
    //    DontDestroyOnLoad(gameObject);
    //}
    //
    //string textFile;
    //string objectName;
    //string text;
    //Vector3 position;
    //Vector4 color;
    //int fontSize;
    //
    //Text[] list;
    //
    //[SerializeField]
    //Text textPrefab;
    //
    //[SerializeField]
    //Canvas canvas;
    //
    //Vector3 startingPosition = new Vector3(0.0f, 0.0f, 0.0f);
    //
    //// Importing functions from dll
    //[DllImport("UIManagerPlugin")]
    //public static extern void LoadDLL();
    //[DllImport("UIManagerPlugin")]
    //public static extern void ChangeState(int newState);
    //[DllImport("UIManagerPlugin")]
    //public static extern void LoadFile(string fileName);
    //[DllImport("UIManagerPlugin")]
    //public static extern void Compose(int index);
    //[DllImport("UIManagerPlugin", CallingConvention = CallingConvention.Cdecl)]
    //public static extern System.IntPtr ReturnName(int newState);
    //[DllImport("UIManagerPlugin", CallingConvention = CallingConvention.Cdecl)]
    //public static extern System.IntPtr ReturnText(int newState);
    //[DllImport("UIManagerPlugin")]
    //public static extern float ReturnPosX();
    //[DllImport("UIManagerPlugin")]
    //public static extern float ReturnPosY();
    //[DllImport("UIManagerPlugin")]
    //public static extern float ReturnPosZ();
    //[DllImport("UIManagerPlugin")]
    //public static extern float ReturnRed();
    //[DllImport("UIManagerPlugin")]
    //public static extern float ReturnGreen();
    //[DllImport("UIManagerPlugin")]
    //public static extern float ReturnBlue();
    //[DllImport("UIManagerPlugin")]
    //public static extern float ReturnAlpha();
    //[DllImport("UIManagerPlugin")]
    //public static extern int ReturnFontSize();
    //
    //// Text elements
    //Text timeText;
    //Text foodText1;
    //Text foodText2;
    //Text foodText3;
    //Text foodText4;
    //
    //Text timeCount;
    //Text foodCount1;
    //Text foodCount2;
    //Text foodCount3;
    //Text foodCount4;
    //
    //
    //// Use this for initialization
    //void Start()
    //{
    //    LoadDLL();
    //
    //    createStaticText();
    //
    //    list = GameObject.FindObjectsOfType<Text>(); // Get array of text elements in the game scene
    //
    //    LoadFile("UIElements"); // Load properties from text file
    //    for (int i = 0; i < list.Length; i++) // For each text element
    //    {
    //        PackData(i); // Compose and pack data for it
    //        SetData(list[i]); // Send the composed data to the text element
    //    }
    //
    //    createDynText();
    //
    //
    //}
    //
    //// Update is called once per frame
    //void Update()
    //{
    //    timeCount.text = formatText(GameManager.instance.TimeRemaining);
    //    foodCount1.text = GameManager.instance.Player1DepositedRes.ToString();
    //    foodCount2.text = GameManager.instance.Player2DepositedRes.ToString();
    //    foodCount3.text = GameManager.instance.Player3DepositedRes.ToString();
    //    foodCount4.text = GameManager.instance.Player4DepositedRes.ToString();
    //}
    //
    //private string formatText(float time)
    //{
    //    // Uses string.Format to display the time as minutes and seconds with a colon in the middle
    //    return string.Format("{0}:{1:00}", ((int)time / 60), ((int)time % 60));
    //}
    //
    //void createStaticText()
    //{
    //    timeText = Instantiate(textPrefab, startingPosition, textPrefab.transform.rotation) as Text;
    //    timeText.transform.SetParent(canvas.transform, false);
    //    foodText1 = Instantiate(textPrefab, startingPosition, textPrefab.transform.rotation) as Text;
    //    foodText1.transform.SetParent(canvas.transform, false);
    //    foodText2 = Instantiate(textPrefab, startingPosition, textPrefab.transform.rotation) as Text;
    //    foodText2.transform.SetParent(canvas.transform, false);
    //    foodText3 = Instantiate(textPrefab, startingPosition, textPrefab.transform.rotation) as Text;
    //    foodText3.transform.SetParent(canvas.transform, false);
    //    foodText4 = Instantiate(textPrefab, startingPosition, textPrefab.transform.rotation) as Text;
    //    foodText4.transform.SetParent(canvas.transform, false);
    //}
    //
    //void createDynText()
    //{
    //    timeCount = Instantiate(textPrefab, startingPosition, textPrefab.transform.rotation) as Text;
    //    timeCount.transform.SetParent(canvas.transform, false);
    //    timeCount.fontSize = 24;
    //    foodCount1 = Instantiate(textPrefab, startingPosition, textPrefab.transform.rotation) as Text;
    //    foodCount1.transform.SetParent(canvas.transform, false);
    //    foodCount1.fontSize = 24;
    //    foodCount2 = Instantiate(textPrefab, startingPosition, textPrefab.transform.rotation) as Text;
    //    foodCount2.transform.SetParent(canvas.transform, false);
    //    foodCount2.fontSize = 24;
    //    foodCount3 = Instantiate(textPrefab, startingPosition, textPrefab.transform.rotation) as Text;
    //    foodCount3.transform.SetParent(canvas.transform, false);
    //    foodCount3.fontSize = 24;
    //    foodCount4 = Instantiate(textPrefab, startingPosition, textPrefab.transform.rotation) as Text;
    //    foodCount4.transform.SetParent(canvas.transform, false);
    //    foodCount4.fontSize = 24;
    //
    //    timeCount.rectTransform.localPosition = new Vector3(220, 500, 0);
    //    foodCount1.rectTransform.localPosition = new Vector3(-571, 500, 0);
    //    foodCount2.rectTransform.localPosition = new Vector3(1050, 500, 0);
    //    foodCount3.rectTransform.localPosition = new Vector3(-571, -500, 0);
    //    foodCount4.rectTransform.localPosition = new Vector3(1062, -502, 0);
    //}
    //
    //void PackData(int index)
    //{
    //    Compose(index);
    //    objectName = Marshal.PtrToStringAnsi(ReturnName(0)); // Takes in char pointer and converts it into a string
    //    text = Marshal.PtrToStringAnsi(ReturnText(0)); // Takes in char pointer and converts it to a string
    //    position = new Vector3(ReturnPosX(), ReturnPosY(), ReturnPosZ());
    //    color = new Vector4(ReturnRed(), ReturnGreen(), ReturnBlue(), ReturnAlpha());
    //    fontSize = ReturnFontSize();
    //}
    //
    //void SetData(Text tempText)
    //{
    //    tempText.name = objectName;
    //    tempText.text = text;
    //    tempText.rectTransform.localPosition = position;
    //    tempText.color = color;
    //    tempText.fontSize = fontSize;
    //}

    void Update()
    {
        // Player health values
        player1Health = player1.GetComponent<Player>().health / player1.GetComponent<Player>().maxHealth;
        player2Health = player2.GetComponent<Player>().health / player2.GetComponent<Player>().maxHealth;
        player3Health = player3.GetComponent<Player>().health / player3.GetComponent<Player>().maxHealth;
        player4Health = player4.GetComponent<Player>().health / player4.GetComponent<Player>().maxHealth;

        // Updating UI elements
        player1HealthImage.fillAmount = player1Health;
        player2HealthImage.fillAmount = player2Health;
        player3HealthImage.fillAmount = player3Health;
        player4HealthImage.fillAmount = player4Health;

    }

}
